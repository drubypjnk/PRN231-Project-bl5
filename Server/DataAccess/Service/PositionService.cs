using AutoMapper;
using BussinessObject.DTO;
using BussinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Service
{
    public class PositionService
    {
        private IMapper mapper;
        private PRN231_BL5Context context=new PRN231_BL5Context();

        public PositionService(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public  List<ProductVariantsSubPositionRelation> GetAllProductSubPosition(int categoryID, int status)
        {
            IQueryable<ProductVariantsSubPositionRelation> query = context.ProductVariantsSubPositionRelations
                   .Include(p => p.SubPosition.Position)
                   .Include(v => v.ProductVariant.Product);

            if (categoryID != 0)
            {
                query = query.Where(p => p.ProductVariant.Product.CategoryId == categoryID);
            }

            if (status == 1)
            {
                query = query.Where(p => p.SubPosition.AvailSeat < p.SubPosition.Seat);
            }
            else if (status == 2)
            {
                query = query.Where(p => p.SubPosition.AvailSeat == p.SubPosition.Seat);
            }

            List<ProductVariantsSubPositionRelation> list = query.ToList();
            return list;
        }
    }
}
