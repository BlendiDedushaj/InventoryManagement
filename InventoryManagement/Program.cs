using InventoryManagement.Data;
using InventoryManagement.Interfaces;
using InventoryManagement.Models;
using InventoryManagement.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<InventoryContext>(options =>
    options.UseSqlServer(connectionString));
// Add services to the container.

builder.Services.AddScoped<IUnit, UnitRepository>();
builder.Services.AddScoped<IBrand, BrandRepo>();

builder.Services.AddDbContext<InventoryContext>(options => options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings:dbconn").Value));

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
