using Furnish.WebUI.Dtos.CategoryDtos;
using Furnish.WebUI.Services.CategoryServices;
using Microsoft.AspNetCore.Mvc;

namespace Furnish.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();
            return View(categories);
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            await _categoryService.CreateAsync(createCategoryDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateCategory(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            await _categoryService.UpdateAsync(updateCategoryDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        

    }
}
