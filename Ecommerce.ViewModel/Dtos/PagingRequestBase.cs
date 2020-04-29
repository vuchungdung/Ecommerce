using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.ViewModel.Dtos
{
    public class PagingRequestBase
    {
        public int PageId { set; get; }
        public int PageSize { set; get; }
    }
}
