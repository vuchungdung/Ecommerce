using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Data.EF;
using Ecommerce.ViewModel.Catalog.product.Dtos;
using Ecommerce.ViewModel.Dtos;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Service.Catalog.product
{
    public class PublicProductService : IPublicProductService
    {
        private readonly EcommerceDbContext _context;
        public PublicProductService(EcommerceDbContext context)
        {
            _context = context;
        }
        public async Task<PagedResult<ProductViewModel>> GetAllByCategoryId(PublicProductPagingRequest request)
        {
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _context.ProductInCategories on p.Id equals pic.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.Id
                        where pt.LanguageId == request.LanguageId
                        select new { p, pt, pic };
            if(request.CategoryId.HasValue && request.CategoryId > 0)
            {
                query = query.Where(x => x.pic.CategoryId == request.CategoryId);
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
    }
}
