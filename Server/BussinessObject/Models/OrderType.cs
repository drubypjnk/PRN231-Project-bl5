using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class OrderType
    {
        public int OrderTypeId { get; set; }
        public string? Name { get; set; }
        public string? Desc { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? DeleteFlag { get; set; }
    }
}
