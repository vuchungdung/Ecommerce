using Ecommerce.ViewModel.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.ViewModel.Catalog.product.Dtos
{
    public class ManageProductPagingRequest : PagingRequestBase
    {
        public string KeyWord { set; get; }
        public List<int> CategoryId { set; get; }
    }
}
