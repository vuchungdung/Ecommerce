using Ecommerce.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Data.Entities
{
    public class Promotion
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public DateTime FromDated { set; get; }
        public DateTime ToDated { set; get; }
        public bool? ApplyForAll { set; get; }
        public int? DiscountPercent { set; get; }
        public decimal? DiscountAmount { set; get; }
        public string ProductIds { set; get; }
        public string ProductCategoryIds { set; get; }
        public Status Status { set; get; }
    }
}
