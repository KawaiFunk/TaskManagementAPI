using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI.Services.Interfaces;

namespace TaskManagementAPI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


    }
}
