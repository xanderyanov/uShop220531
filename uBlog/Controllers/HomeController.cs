using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using uBlog.Domain;
using uBlog.Models;

namespace uBlog.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(Data.ExistingPosts);
        }
    }
}