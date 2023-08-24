using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class Activity
    {
        public int HistoryId { get; set; }
        public int UserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? Desc { get; set; }
        public bool? DeleteFlag { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
