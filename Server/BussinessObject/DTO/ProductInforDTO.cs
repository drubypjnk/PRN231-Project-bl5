using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.DTO
{
    public class ProductInforDTO
    {
		public int ProductId { get; set; }
		public string? ProductName { get; set; }
		public string? Image { get; set; }
		public string Category { get; set; }
		public int Quantity { get; set; }
		public int UnitPrice { get; set; }
	}
}
