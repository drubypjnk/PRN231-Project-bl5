using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class Order
    {
        public Order()
        {
            Notes = new HashSet<Note>();
        }

        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int OrderTypeId { get; set; }
        public DateTime? CreateDate { get; set; }
        public double? TotalPrice { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool? DeleteFlag { get; set; }

        public virtual OrderType OrderType { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<Note> Notes { get; set; }
    }
}
