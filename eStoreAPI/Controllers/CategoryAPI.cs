using BusinessObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryAPI : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryAPI(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        //GET: api/Category/GetAllCategories
        [HttpGet("GetAllCategories")]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();
            return Ok(categories);
        }
    }
}
