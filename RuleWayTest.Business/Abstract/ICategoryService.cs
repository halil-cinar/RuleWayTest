using RuleWayTest.Dto.AddOrUpdateDto;
using RuleWayTest.Dto.Filter;
using RuleWayTest.Dto.ListDto;
using RuleWayTest.Dto.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleWayTest.Business.Abstract
{
    public interface ICategoryService
    {
        public Task<BussinessLayerResult<CategoryListDto>> Add(CategoryDto category);
        public Task<BussinessLayerResult<CategoryListDto>> Update(CategoryDto category);
        public Task<BussinessLayerResult<CategoryListDto>> Delete(int id);
        public Task<BussinessLayerResult<CategoryListDto>> Get(int id);
        public Task<BussinessLayerResult<List<CategoryListDto>>> GetAll(CategoryFilter filter);
    }
}
