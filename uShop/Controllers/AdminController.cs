using Microsoft.AspNetCore.Mvc;

namespace uShop.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BlogEdit()
        {
            return View("BlogEdit", Data.ExistingPosts);
        }


    }
}
