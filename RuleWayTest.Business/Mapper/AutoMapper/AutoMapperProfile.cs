using AutoMapper;
using RuleWayTest.Dto.AddOrUpdateDto;
using RuleWayTest.Dto.ListDto;
using RuleWayTest.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleWayTest.Business.Mapper.AutoMapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProductEntity, ProductDto>().ReverseMap();
            CreateMap<ProductEntity, ProductListDto>().ReverseMap();

            CreateMap<CategoryEntity, CategoryDto>().ReverseMap();
            CreateMap<CategoryEntity, CategoryListDto>().ReverseMap();

            
        }
    }
}
