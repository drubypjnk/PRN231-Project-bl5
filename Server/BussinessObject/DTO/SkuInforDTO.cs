using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.DTO
{
    public class SkuInforDTO
    {
        public SkuInforDTO()
        {
           Products = new List<ProductInforDTO>();
        }

        public List<ProductInforDTO> Products { get; set; }
        public string? Name { get; set; }
        public string? Desc { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
