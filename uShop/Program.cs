using MmxCMS;
using MongoDB.Driver;
using uShop;

var builder = WebApplication.CreateBuilder(args);

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

    endpoints.MapControllerRoute("route2",
       "{controller}/{action}/{id?}",
       new { controller = "Home", action = "Index" });

    endpoints.MapDefaultControllerRoute();
});

app.Run();


