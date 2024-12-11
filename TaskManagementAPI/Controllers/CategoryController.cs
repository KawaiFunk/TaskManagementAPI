using Microsoft.AspNetCore.Mvc;

namespace TaskManagementAPI.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
