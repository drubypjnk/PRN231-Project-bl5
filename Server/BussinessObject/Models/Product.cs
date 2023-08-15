using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductVariants = new HashSet<ProductVariant>();
        }

        public int ProductId { get; set; }
        public int? CategoryId { get; set; }
        public bool? DeleteFlag { get; set; }
        public string? ProductName { get; set; }

        public virtual Category? Category { get; set; }
        public virtual ICollection<ProductVariant> ProductVariants { get; set; }
    }
}
