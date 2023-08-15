using BussinessObject.DTO;
using System;

public class SkuDTO
{
        public int SkuId { get; set; }
        public string? Name { get; set; }
        public string? Desc { get; set; }
        public double? TotalPrice { get; set; }
        public DateTime? ApproveDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public List<ProductDTO> products { get; set; }
}
