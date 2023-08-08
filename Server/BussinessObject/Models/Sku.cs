using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class Sku
    {
        public Sku()
        {
            ProductVariants = new HashSet<ProductVariant>();
        }

        public int SkuId { get; set; }
        public string? Desc { get; set; }
        public double? TotalPrice { get; set; }
        public DateTime? ApproveDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool? DeleteFlag { get; set; }

        public virtual ICollection<ProductVariant> ProductVariants { get; set; }
    }
}
