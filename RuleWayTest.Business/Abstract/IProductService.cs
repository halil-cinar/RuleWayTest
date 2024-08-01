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
    public interface IProductService
    {
        public Task<BussinessLayerResult<ProductListDto>> Add(ProductDto product);
        public Task<BussinessLayerResult<ProductListDto>> Update(ProductDto product);
        public Task<BussinessLayerResult<ProductListDto>> Delete(int id);
        public Task<BussinessLayerResult<ProductListDto>> Get(int id);
        public Task<BussinessLayerResult<List<ProductListDto>>> GetAll(ProductFilter filter);
        
        


    }
}
