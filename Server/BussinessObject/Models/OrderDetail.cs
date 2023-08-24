using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class OrderDetail
    {
        public int? OrderId { get; set; }
        public int? ProductVariantId { get; set; }
        public int? Quantity { get; set; }
        public double? Price { get; set; }
        public bool? IsDelete { get; set; }

        public virtual Order? Order { get; set; }
        public virtual ProductVariant? ProductVariant { get; set; }
    }
}
