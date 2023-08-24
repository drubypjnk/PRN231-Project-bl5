using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.DTO
{
	public class ProductFilterDTO
	{
		public int ProductId { get; set; }
		public string? ProductName { get; set; }
		public string? Img { get; set; }
		public string CategoryName { get; set; }
		public string CategoryId { get; set; }
		public  int Total { get; set; }
		public  int LastTestPrice { get; set; }
		public bool? DeleteFlag { get; set; }
	}
}
