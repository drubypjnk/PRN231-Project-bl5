using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class ProductVariantsSubPositionRelation
    {
        public ProductVariantsSubPositionRelation(int subPositionId, int productVariantId, bool? deleteFlag)
        {
            SubPositionId = subPositionId;
            ProductVariantId = productVariantId;
            DeleteFlag = deleteFlag;
        }

        public int SubPositionId { get; set; }
        public int ProductVariantId { get; set; }
        public bool? DeleteFlag { get; set; }

        public virtual ProductVariant ProductVariant { get; set; } = null!;
        public virtual SubPosition SubPosition { get; set; } = null!;
    }
}
