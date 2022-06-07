using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using uShop.Models;
using System.Diagnostics;
using System.Linq;
using uShop.Models.ViewModels;


namespace uShop.Controllers
{
    public class CatalogController : BaseController
    {
        public int PageSize = 24;
              

        public IActionResult Brand(string id, int productPage = 1)
        {
            var products = Data.ExistingTovars;

            Bucket.SelectedCategory = id;
            Bucket.Title = $"Часы {id} в магазине Мир Часов XXL";

            return View("Catalog", new ProductsListViewModel
            {
                Products = products
                   .Where(p => id == null || p.BrandName == id)
                   //.OrderBy(p => p.Id)
                   .Skip((productPage - 1) * PageSize)
                   .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = id == null ?
                        products.Count() :
                        products.Where(e =>
                            e.BrandName == id).Count()

                },
                CurrentCategory = id
            });
        }

        public IActionResult Index(string id, int productPage = 1)
        {
            return View("Catalog", new ProductsListViewModel
            {
                Products = Data.ExistingTovars
                   //.OrderBy(p => p.Id)
                   .Skip((productPage - 1) * PageSize)
                   .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = Data.ExistingTovars.Count()
                },
                CurrentCategory = id
            });
        }

    }
}
