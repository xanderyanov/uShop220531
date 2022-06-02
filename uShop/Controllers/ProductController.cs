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
    public class ProductController : BaseController
    {

        public IActionResult Product(string id)
        {
            ObjectId Id = default; 
            try
            {
                Id = new ObjectId(id);
            }
            catch
            {
                return NotFound();
            }

            Product product = Data.Products.Find(x => x.Id == Id);

            return View("Product", product);
        }

        

    }
}
