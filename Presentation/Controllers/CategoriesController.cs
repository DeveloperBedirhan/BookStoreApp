using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly IServiceManager _services;
        public CategoriesController(IServiceManager services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            var categories = await _services.CategoryService.GetAllCategoriesAsync(false);
            return Ok(categories);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneCategoriesByIdAsync([FromRoute] int id)
        {
            var category = await _services.CategoryService.GetOneCategoryByIdAsync(id, false);
            return Ok(category);
        }
    }
}
