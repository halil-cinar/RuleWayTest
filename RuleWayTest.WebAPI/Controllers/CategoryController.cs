using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RuleWayTest.Business.Abstract;
using RuleWayTest.Dto.AddOrUpdateDto;
using RuleWayTest.Dto.Enum;
using RuleWayTest.Dto.Filter;

namespace RuleWayTest.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("GetCategories")]
        public async Task<IActionResult> GetCategories(CategoryFilter filter)
        {
            var result = await _categoryService.GetAll(filter);
            if (result.Status == EResultStatus.Success)
            {
                return Ok(result.Result);
            }
            return BadRequest(result.Errors);
        }

        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddCategory(CategoryDto category)
        {
            var result = await _categoryService.Add(category);
            if (result.Status == EResultStatus.Success)
            {
                return Ok(result.Result);
            }
            return BadRequest(result.Errors);
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _categoryService.Delete(id);
            if (result.Status == EResultStatus.Success)
            {
                return Ok(result.Result);
            }
            return BadRequest(result.Errors);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var result = await _categoryService.Get(id);
            if (result.Status == EResultStatus.Success)
            {
                return Ok(result.Result);
            }
            return BadRequest(result.Errors);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(CategoryDto category)
        {
            var result = await _categoryService.Update(category);
            if (result.Status == EResultStatus.Success)
            {
                return Ok(result.Result);
            }
            return BadRequest(result.Errors);
        }


    }
}
