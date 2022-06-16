using AppStore.Domain.Basket;
using AppStore.Domain.Categories;
using AppStore.Domain.Orders;
using AppStore.Domain.Products;
using AppStore.Infra.Data.Sql.Categories;
using AppStore.Infra.Data.Sql.Common;
using AppStore.Infra.Data.Sql.Orders;
using AppStore.Infra.Data.Sql.Products;
using AppStore.ShopProjectUI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var cnnString = builder.Configuration.GetConnectionString("StoreCnn");
builder.Services.AddDbContext<StoreDbContext>(options => options.UseSqlServer(cnnString));
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IProductRepository, EFProductRepository>();
builder.Services.AddScoped<Basket>(c => SessionBasket.GetBasket(c));
builder.Services.AddScoped<IOrderRepository, EFOrderRepository>();
builder.Services.AddScoped<ICategoryRepository, EFCategoryRepository>();

var app = builder.Build();
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    //app.UseHsts();
//}

app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
//app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("pagination", "/{controller=home}/{action=index}/{category}/Page{PageNumber}");
    endpoints.MapControllerRoute("pagination", "/{controller=home}/{action=index}/Page{PageNumber}");
    endpoints.MapControllerRoute("pagination", "/{controller=home}/{action=index}/{category}");
    endpoints.MapDefaultControllerRoute();
}
    );

app.Run();
