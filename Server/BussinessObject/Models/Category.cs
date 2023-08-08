﻿using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Desc { get; set; }
        public string? DeleteFlag { get; set; }
        public int PositionId { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
