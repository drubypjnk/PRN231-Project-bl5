using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class Note
    {
        public int NoteId { get; set; }
        public int CreateBy { get; set; }
        public int OrderId { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? Content { get; set; }
        public bool? DeleteFlag { get; set; }

        public virtual User CreateByNavigation { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
    }
}
