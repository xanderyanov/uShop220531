using MmxCMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace uShop;
{
    public class MenuItem
    {
        public MenuItem Parent;
        //public TCatalogPage Page;
        public string Text;
        //public Image Thumbnail;

        public MenuItem(string url)
        {
            Url = url;
            //string s = Mode == CatalogPageDisplayMode.Normal ? _p : Mode == CatalogPageDisplayMode.Brand ? _brand : _shop;
            //PURL = URL.Replace("$$$", s);
        }

        public string Url;
        public bool IsSelected;
        public bool IsHighlighted;
        public List<MenuItem> Children = new();

        public MenuItem AddItem(string text, string url, string selectedUrl)
        {
            var result = new MenuItem(url) {
                IsSelected = url == selectedUrl,
                Text = text,
                Parent = this,
            };
            Children.Add(result);
            return result;
        }

        public void WalkCategory(BtlCategory c, ModxPageResultDomainItem selectedObject, MLStringUse LC)
        {
            if (!c.Published) return;

            var item = AddItem(c, selectedObject, LC);
            item.IsHighlighted = c.IsHighlighted;
            
            foreach (var i in c.Children)
                item.WalkCategory(i, selectedObject, LC);
        }
    }
    
    public class Menu 
    {
        public MenuItem Level0;
        public List<MenuItem> Path = new();

        public static bool Walk(List<MenuItem> path, MenuItem I)
        {
            foreach (var i in I.Children) {
                if (i.IsSelected) {
                    var n = i;
                    while (n.Parent != null) {
                        path.Insert(0, n);
                        n = n.Parent;
                    }
                    return true;
                }
                if (Walk(path, i)) return true;
            }
            return false;
        }

        public static Menu Create(BtlDomain domain, ModxPageResultDomainItem selectedObject, string selectedUrl, MLStringUse LC)
        {
            MenuItem level0 = new(null);
            
            var main = level0.AddItem("Главная", "/", selectedUrl);
            
            foreach (var p in domain.BtlInfoPages.All.Where(x => x.Published).OrderBy(x => x.Position))
                main.AddItem(p, selectedObject, LC);
            
            foreach (var c in domain.BtlCategoryTree.Level0)
                level0.WalkCategory((BtlCategory)c, selectedObject, LC);

            main = level0.AddItem("Оборудование", "/allequipment", selectedUrl);
            //foreach (var e in Data.Equipment.All.Where(x => x.Published).OrderBy(x => x.Position))
            //    main.AddItem(e, selectedObject, LC);

            main = level0.AddItem("Специалисты", "/specialists", selectedUrl);
            //foreach (var s in Data.Employees.All.Where(x => x.Published).OrderBy(x => x.Position))
            //    main.AddItem(s, selectedObject, LC);

            BtlMenu result = new() { Level0 = level0 };
            Walk(result.Path, level0);
            return result;
        }

    }
}
