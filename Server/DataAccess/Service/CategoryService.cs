using AutoMapper;
using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Service
{
    public class CategoryService
    {
        private IMapper mapper;

        public CategoryService(IMapper mapper)
        {
            this.mapper = mapper;
        }
        public List<Category> getAll()
        {
            PRN231_BL5Context context = new PRN231_BL5Context();
            List<Category> categories = context.Categories.ToList();
            return categories;
        }
    }
}
