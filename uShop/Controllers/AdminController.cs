using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using uShop.Models;
using System.Diagnostics;
using System.Linq;
using uShop.Models.ViewModels;


namespace uShop.Controllers;

public class AdminController : BaseController
{


    #region BlogPost
    public ActionResult BtlBlogPostList()
    {
        List<BtlBlogPost> Result = domain.BtlBlogPosts.All.OrderBy(x => x.Position).ToList();
        return View(Result);
    }

    public ActionResult BtlBlogPostEdit(string id = null)
    {
        return LoadOrCreate(domain.BtlBlogPosts, id, mangleItem: (x, m) => { if (m == ItemMangleMode.New) x.PostDate = DateTime.Now; });
    }

    [HttpPost]
    public ActionResult BtlBlogPostEdit(BtlBlogPost X)
    {
        domain.BtlBlogPosts.Bind(X);
        return SaveOrUpdate(domain.BtlBlogPosts, X, autoUpdateSlug: true);
    }

    [HttpPost]
    [Authorize(Roles = RoleNames.Content)]
    public ActionResult BtlBlogPostDelete(string id = null)
    {
        return Delete(domain.BtlBlogPosts, id);
    }
    #endregion


    public IActionResult Index()
    {
        return View(Data.ExistingTovars);
    }


}
