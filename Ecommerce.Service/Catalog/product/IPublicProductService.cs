using Ecommerce.ViewModel.Catalog.product.Dtos;
using Ecommerce.ViewModel.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.Catalog.product
{
    public interface IPublicProductService
    {
        Task<PagedResult<ProductViewModel>> GetAllByCategoryId(PublicProductPagingRequest request);
    }
}
