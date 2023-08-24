using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class OrderType
    {
        public OrderType()
        {
            Orders = new HashSet<Order>();
        }

        public int OrderTypeId { get; set; }
        public string? Name { get; set; }
        public string? Desc { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? DeleteFlag { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
