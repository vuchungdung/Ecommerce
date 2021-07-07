using Ecommerce.ViewModel.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.ViewModel.Catalog.product.Dtos
{
    public class PublicProductPagingRequest : PagingRequestBase
    {
        public string LanguageId { set; get; }
        public int? CategoryId { set; get; }
    }
}
