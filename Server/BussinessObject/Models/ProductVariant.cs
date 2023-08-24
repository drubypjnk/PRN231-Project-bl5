using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class ProductVariant
    {
        public ProductVariant()
        {
            OrderDetails = new HashSet<OrderDetail>();
            ProductVariantsSubPositionRelations = new HashSet<ProductVariantsSubPositionRelation>();
        }

        public int ProductVariantId { get; set; }
        public int ProductId { get; set; }
        public int? UnitPrice { get; set; }
        public int? Quality { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? CreateBy { get; set; }
        public int? UnitInStock { get; set; }
        public int? UnitInOrder { get; set; }
        public bool? DeleteFlag { get; set; }
        public int SkuId { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual Sku Sku { get; set; } = null!;
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<ProductVariantsSubPositionRelation> ProductVariantsSubPositionRelations { get; set; }
    }
}
