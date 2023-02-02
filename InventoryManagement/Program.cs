using InventoryManagement.Data;
using InventoryManagement.Interfaces;
using InventoryManagement.Models;
using InventoryManagement.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<InventoryContext>(options =>
    options.UseSqlServer(connectionString));
// Add services to the container.



builder.Services.AddScoped<IUnit, UnitRepository>();
builder.Services.AddScoped<ISupplier, SupplierRepo>();
builder.Services.AddScoped<IBrand, BrandRepo>();
builder.Services.AddScoped<ICategory, CategoryRepo>();
builder.Services.AddScoped<ICurrency, CurrencyRepo>();
builder.Services.AddScoped<IPurchaseOrder, PurchaseOrderRepo>();
builder.Services.AddScoped<IProduct, ProductRepo>();
builder.Services.AddScoped<IProductGroup, ProductGroupRepo>();
builder.Services.AddScoped<IProductProfile, ProductProfileRepo>();


builder.Services.AddDbContext<InventoryContext>(options => options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings:dbconn").Value));

builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddDefaultTokenProviders().AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<InventoryContext>();

builder.Services.AddScoped<UserManager<IdentityUser>>();

builder.Services.AddControllersWithViews();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapRazorPages();

    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

});

app.Run();
