using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static uShop.BaseController;
using static uShop.Controllers.CatalogController;

namespace uShop.Models.ViewModels;

public class ProductsListViewModel
{
    public IEnumerable<Product> Products { get; set; }
    public PagingInfo PagingInfo { get; set; }
    public string CurrentCategory { get; set; }

    public ViewSettingsClass ViewSettings { get; set; }
}

