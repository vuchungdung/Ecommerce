using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Data.EF;
using Ecommerce.Data.Entities;
using Ecommerce.ViewModel.Catalog.product.Dtos;
using Ecommerce.ViewModel.Dtos;
using Ecommerce.Utilities.CustomException;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.IO;
using Ecommerce.Service.Common;

namespace Ecommerce.Service.Catalog.product
{
    public class ManageProductService : IManageProductService
    {
        private readonly EcommerceDbContext _context;
        private readonly IStorageService _storageService;
        public ManageProductService(EcommerceDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public Task<int> AddImage(int productId, List<IFormFile> list)
        {
            throw new NotImplementedException();
        }

        public async Task AddViewCount(int productId)
        {
            var product = _context.Products.Find(productId);
            product.ViewCount += 1;
            await _context.SaveChangesAsync();
        }

        public async Task<int> Create(ProductCreateRequest request)
        {
            var product = new Product()
            {
                Price = request.Price,
                OriginalPrice = request.OriginalPrice,
                Stock = request.Stock,
                ViewCount = 0,
                DateCreated = DateTime.Now,
                ProductTranslations = new List<ProductTranslation>()
                {
                    new ProductTranslation()
                    {
                        Name =  request.Name,
                        Description = request.Description,
                        Details = request.Details,
                        SeoDescription = request.SeoDescription,
                        SeoAlias = request.SeoAlias,
                        SeoTitle = request.SeoTitle,
                        LanguageId = request.LanguageId
                    }
                }
            };
            if(request.ThumbNailImage != null)
            {
                product.ProductImages = new List<ProductImage>()
                {
                    new ProductImage()
                    {
                        Caption = "Thumbnail image",
                        CreatedDate = DateTime.Now,
                        FileSize = request.ThumbNailImage.Length,
                        ImagePath = await this.SaveFile(request.ThumbNailImage),
                        IsDefault = true,
                        SortOrder = 1
                    }
                };
            }
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product.Id;
        }

        public async Task<bool> Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                var images = _context.ProductImages.Where(x => x.ProductId == product.Id);
                foreach (var item in images)
                {
                    await _storageService.DeleteFileAsync(item.ImagePath);
                }
                _context.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {               
                await _context.SaveChangesAsync();
                return false;
            }
        }

        public Task<List<ProductViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResult<ProductViewModel>> GetAllPaging(ManageProductPagingRequest request)
        {
            var query = from p in _context.Products 
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _context.ProductInCategories on p.Id equals pic.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.Id
                        select new { p,pt,pic};
            if (!string.IsNullOrEmpty(request.KeyWord))
            {
                query = query.Where(x => x.pt.Name.Contains(request.KeyWord));
            }
            if (request.CategoryId.Count > 0)
            {
                query = query.Where(x => request.CategoryId.Contains(x.pic.CategoryId));
            }
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageId - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(p => new ProductViewModel()
                {
                    Id = p.p.Id,
                    Name = p.pt.Name,
                    DateCreated = p.p.DateCreated,
                    Description = p.pt.Description,
                    Details = p.pt.Details,
                    LanguageId = p.pt.LanguageId,
                    OriginalPrice = p.p.OriginalPrice,
                    Price = p.p.Price,
                    SeoAlias = p.pt.SeoAlias,
                    SeoDescription = p.pt.SeoDescription,
                    SeoTitle = p.pt.SeoTitle,
                    Stock = p.p.Stock,
                    ViewCount = p.p.ViewCount

                }).ToListAsync();
            var pageresult = new PagedResult<ProductViewModel>()
            {
                TotalRecord = totalRow,
                Items = data
            };
            return pageresult;
        }

        public async Task<ProductViewModel> GetById(int id, string languageId)
        {
            var product = await _context.Products.FindAsync(id);
            var productTranslation = await _context.ProductTranslations.Where(x => x.LanguageId == languageId && x.ProductId == id).FirstOrDefaultAsync();
            var productResult = new ProductViewModel()
            {
                Id = product.Id,
                DateCreated = product.DateCreated,
                Description = productTranslation != null ? productTranslation.Description : null,
                LanguageId = productTranslation.LanguageId,
                Details = productTranslation != null ? productTranslation.Details : null,
                Name = productTranslation != null ? productTranslation.Name : null,
                OriginalPrice = product.OriginalPrice,
                Price = product.Price,
                SeoAlias = productTranslation != null ? productTranslation.SeoAlias : null,
                SeoDescription = productTranslation != null ? productTranslation.SeoDescription : null,
                SeoTitle = productTranslation != null ? productTranslation.SeoTitle : null,
                Stock = product.Stock,
                ViewCount = product.ViewCount
            };
            return productResult;
        }

        public Task<List<ProductImageViewModel>> GetListImage(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<int> RemoveImage(int imageId)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update(ProductUpdateRequest request)
        {
            var product = await _context.Products.FindAsync(request.Id);
            var productTranslation = await _context.ProductTranslations.FirstOrDefaultAsync(x => x.ProductId == request.Id);
            if(product == null || productTranslation == null)
            {
                throw new EcommerceException($"Can not find product with id : {request.Id}");
            }
            productTranslation.Name = request.Name;
            productTranslation.SeoAlias = request.SeoAlias;
            productTranslation.SeoDescription = request.SeoDescription;
            productTranslation.SeoTitle = request.SeoTitle;
            productTranslation.Description = request.Description;
            productTranslation.Details = request.Details;
            if(request.ThumbNailImage != null)
            {
                var thumb = _context.ProductImages.Where(x => x.ProductId == request.Id && x.IsDefault == true).FirstOrDefault();
                if (thumb != null)
                {
                    thumb.FileSize = request.ThumbNailImage.Length;
                    thumb.ImagePath = await this.SaveFile(request.ThumbNailImage);
                    _context.ProductImages.Update(thumb);
                }
            }
            return await _context.SaveChangesAsync();
        }

        public Task<int> UpdateImage(int imageId, string caption, bool isDefault)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdatePrice(int productId, decimal price)
        {
            var product = await _context.Products.FindAsync(productId);            
            if (product == null )
            {
                throw new EcommerceException($"Can not find product with id : {productId}");
            }
            product.Price = price;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateStock(int productId, int quantity)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                throw new EcommerceException($"Can not find product with id : {productId}");
            }
            product.Stock = quantity;
            return await _context.SaveChangesAsync() > 0;
        }
        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }
    }
}
