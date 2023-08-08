using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class Position
    {
        public Position()
        {
            SubPositions = new HashSet<SubPosition>();
        }

        public int PositionId { get; set; }
        public string? Address { get; set; }
        public string? Desc { get; set; }
        public bool? DeleteFlag { get; set; }

        public virtual ICollection<SubPosition> SubPositions { get; set; }
    }
}
