using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using uBlog.Domain;
using uBlog.Models;

namespace uBlog.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(SortState sortOrder = SortState.DateDesc)
        {

            ViewData["TitleSort"] = sortOrder == SortState.TitleAsc ? SortState.TitleDesc : SortState.TitleAsc;
            ViewData["DateSort"] = sortOrder == SortState.DateAsc ? SortState.DateDesc : SortState.DateAsc;

            var Model = Data.ExistingPosts;

            Model = sortOrder switch
            {
                SortState.TitleAsc => Model.OrderBy(s => s.Title).ToList(),
                SortState.TitleDesc => Model.OrderByDescending(s => s.Title).ToList(),
                SortState.DateAsc => Model.OrderBy(s => s.PostDate).ToList(),
                _ => Model.OrderByDescending(s => s.PostDate).ToList(),
            };

            return View(Model);
        }
    }
}