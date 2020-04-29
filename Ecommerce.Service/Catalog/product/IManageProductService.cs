using Ecommerce.ViewModel.Catalog.product.Dtos;
using Ecommerce.ViewModel.Dtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.Catalog.product
{
    public interface IManageProductService
    {
        Task<ProductViewModel> GetById(int id, string languageId);
        Task<int> Create(ProductCreateRequest request);
        Task<int> Update(ProductUpdateRequest request);
        Task<bool> UpdatePrice(int productId, decimal price);
        Task<bool> UpdateStock(int productId, int quantity);
        Task AddViewCount(int productId);
        Task<bool> Delete(int id);
        Task<List<ProductViewModel>> GetAll();
        Task<PagedResult<ProductViewModel>> GetAllPaging(ManageProductPagingRequest request);
        Task<int> AddImage(int productId, List<IFormFile> list);
        Task<int> RemoveImage(int imageId);
        Task<int> UpdateImage(int imageId, string caption, bool isDefault);
        Task<List<ProductImageViewModel>> GetListImage(int productId);
    }
}
