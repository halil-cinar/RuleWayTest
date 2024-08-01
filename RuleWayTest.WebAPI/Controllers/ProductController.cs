using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RuleWayTest.Business.Abstract;
using RuleWayTest.Dto.AddOrUpdateDto;
using RuleWayTest.Dto.Enum;
using RuleWayTest.Dto.Filter;
using RuleWayTest.Dto.ListDto;

namespace RuleWayTest.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("GetProducts")]
        public async Task<IActionResult> GetProducts(ProductFilter filter)
        {
            var result = await _productService.GetAll(filter);
            if (result.Status == EResultStatus.Success)
            {
                return Ok(result.Result);
            }
            return BadRequest(result.Errors);
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct(ProductDto product)
        {
            var result = await _productService.Add(product);
            if (result.Status == EResultStatus.Success)
            {
                return Ok(result.Result);
            }
            return BadRequest(result.Errors);
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productService.Delete(id);
            if (result.Status == EResultStatus.Success)
            {
                return Ok(result.Result);
            }
            return BadRequest(result.Errors);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var result = await _productService.Get(id);
            if (result.Status == EResultStatus.Success)
            {
                return Ok(result.Result);
            }
            return BadRequest(result.Errors);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(ProductDto product)
        {
            var result = await _productService.Update(product);
            if (result.Status == EResultStatus.Success)
            {
                return Ok(result.Result);
            }
            return BadRequest(result.Errors);
        }



    }
}
