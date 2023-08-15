using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class SubPosition
    {
        public int SubPositionId { get; set; }
        public string? Address { get; set; }
        public string? Desc { get; set; }
        public int PositionId { get; set; }
        public bool? DeleteFlag { get; set; }

        public virtual Position Position { get; set; } = null!;
    }
}
