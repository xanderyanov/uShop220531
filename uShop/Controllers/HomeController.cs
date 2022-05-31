using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using uShop.Models;
using System.Diagnostics;
using System.Linq;
using uShop.Models.ViewModels;


namespace uShop.Controllers;

public class HomeController : BaseController
{

    public IActionResult Index()
    {
        return View(Data.Products);
    }


}
