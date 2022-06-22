using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using uShop.Models;
using System.Diagnostics;
using System.Linq;
using uShop.Models.ViewModels;
using Newtonsoft.Json;
using System;
using System.Text;

namespace uShop.Controllers
{
    public class CatalogController : BaseController
    {
        public int PageSize = 8;
              

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


        public class ViewSettingsClass
        {
            public bool NewOnly { get; set; } = false;
            public bool SaleLeaderOnly { get; set; } = false;
            public string InexpensivePrice { get; set; }

        }


        public IActionResult Index(string id, int productPage = 1, string viewSettingsStr = null)
        {

            ViewSettingsClass viewSettings = null;
            try
            {
                viewSettings = JsonConvert.DeserializeObject<ViewSettingsClass>(Encoding.UTF8.GetString(Convert.FromBase64String(viewSettingsStr)));
            }
            catch
            {
                viewSettings = new();
            }

            ViewData["Booo"] = new[] { 10, 20, 30 };
            
            ViewBag.ViewBagData = new[] { 100, 200, 300 };

            ViewBag.ViewSettings = viewSettings;

            IEnumerable<Product> Products = Data.ExistingTovars;
            //.OrderBy(p => p.Id)
            //if (viewSettings.NewOnly) Products = Products.Where(p => p.FlagNew);
            //if (viewSettings.SaleLeaderOnly) Products = Products.Where(p => p.FlagSaleLeader);
            
            Products = Products.Where(p => 
                (!viewSettings.NewOnly || p.FlagNew) && 
                (!viewSettings.SaleLeaderOnly || p.FlagSaleLeader) &&
                (string.IsNullOrEmpty(viewSettings.InexpensivePrice) || p.DiscountPrice < Double.Parse(viewSettings.InexpensivePrice))
            );

            Products = Products
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize);

            return View("Catalog", new ProductsListViewModel
            {
                Products = Products,
                ViewSettings = viewSettings,
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
