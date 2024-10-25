
using CodeJay.DataAccess.Models.Domain;
using CodeJay.DataAccess.Models.DTO;
using CodeJay.DataAccess.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace CodeJay.API.Controllers
{
    //https://localhost:7163/api/categories
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequestDto request)
        { 
            var category = new Category
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle
            };

             await _categoryRepository.CreateAsync(category);

            var response = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            };

            return Ok(response);

        }
    }
}
