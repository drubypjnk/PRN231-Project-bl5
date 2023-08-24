using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.DTO
{
    public class SkuEditDTO
    {
        public int? skuId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public int? Price { get; set; }
    }
}
