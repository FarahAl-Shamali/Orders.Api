using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Orders.Core.Dtos;
using Orders.Core.ViewModels;
using Orders.Infrastructure.Services.Categories;

namespace Orders.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll(string serachkey)
        {
            var categories =await _categoryService.GetAll(serachkey);
            return Ok(GetResponse(categories));
        }

        [HttpGet]
        public async Task<ActionResult> Get(int id)
        {
            var category =await _categoryService.Get(id);
            return Ok(GetResponse(category));
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateCategoryDto dto)
        {
            var savedId =await _categoryService.Create(dto);
            return Ok(GetResponse(savedId));
        }

        [HttpPut]
        public async Task<ActionResult> Update(UpdateCategoryDto dto)
        {
            var savedId =await _categoryService.Update(dto);
            return Ok(GetResponse(savedId));
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var deletedId = await _categoryService.Delete(id);
            return Ok(GetResponse(deletedId));
        }

    }
}
