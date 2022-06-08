using MmxCMS;
using MongoDB.Driver;
using uShop;
//using uShop.Domain;

//CSVtoDB CSVtoDBexport = new CSVtoDB();


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

Data.InitData(builder.Configuration);

//Data.ImportCSV();     //Обновление товаров

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthorization();

app.UseEndpoints(endpoints =>
{

    endpoints.MapControllerRoute("route1",
       "Product/{id?}",
       new { controller = "Product", action = "Product" });

    //endpoints.MapControllerRoute(
    //    name: "brand",
    //    pattern: "Catalog/{id}",
    //    defaults: new { area = "Btl", controller = "Catalog", action = "Brand", lang = "ru" }
    //).WithDisplayName("Btl5");

    endpoints.MapControllerRoute("route2",
       "{controller}/{action}/{id?}",
       new { controller = "Home", action = "Index" });

    endpoints.MapDefaultControllerRoute();
});

app.Run();


