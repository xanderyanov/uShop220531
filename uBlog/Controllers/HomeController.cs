using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using uBlog.Domain;
using uBlog.Models;

namespace uBlog.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index(string? topic, SortState sortOrder = SortState.DateDesc, int page = 1)
        {

            var Model = Data.ExistingPosts;

            



            //фильтрация





            Model = sortOrder switch
            {
                SortState.TitleAsc => Model.OrderBy(s => s.Title).ToList(),
                SortState.TitleDesc => Model.OrderByDescending(s => s.Title).ToList(),
                SortState.DateAsc => Model.OrderBy(s => s.PostDate).ToList(),
                _ => Model.OrderByDescending(s => s.PostDate).ToList(),
            };

            int pageSize = 4;

            var count = Model.Count();
            var items = Model.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            pageViewModel.Sort = sortOrder;
            
            ComplexModel viewModel = new ComplexModel(
                items,
                //new FilteredViewModel(Posts, Topics),
                new PageViewModel(count, page, pageSize),
                new SortViewModel(sortOrder)
            );

            return View(viewModel);
        }
    }
}