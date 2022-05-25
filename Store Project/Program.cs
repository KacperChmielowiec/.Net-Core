using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;


builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<StoreDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("StoreConn")));
builder.Services.AddScoped<IRepository<Product>, StoreRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddDbContext<IdentityDbContext>(optrion => optrion.UseSqlServer(configuration.GetConnectionString("Identity")));
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
 .AddEntityFrameworkStores<IdentityDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddSession();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddServerSideBlazor();

var app = builder.Build();
IWebHostEnvironment env = app.Environment;
if (env.IsProduction())
{
    app.UseExceptionHandler("/error");
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseStatusCodePages();
}
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute("catpage",
                  "{category}/Page{productPage:int}",
              new { Controller = "Home", action = "Index" });

app.MapControllerRoute("page", "Page{productPage:int}",
new { Controller = "Home", action = "Index", productPage = 1 });

app.MapControllerRoute("category", "{category}",
new { Controller = "Home", action = "Index", productPage = 1 });
app.MapControllerRoute("pagination",
"Products/Page{productPage}",
new { Controller = "Home", action = "Index", productPage = 1 });


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapDefaultControllerRoute();
app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/admin/{*catchall}","/Admin/Index");
app.StorePopulateData();
app.EnsurePopulateUser();
app.Run();
