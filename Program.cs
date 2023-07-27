using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UberEats.Models;

var builder = WebApplication.CreateBuilder(args);

// Add session services
builder.Services.AddMemoryCache();
builder.Services.AddSession();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<UberContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("UberContext")));

// Add Identity services
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    // User settings
    options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<UberContext>()
.AddDefaultTokenProviders();

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

app.UseSession();

// Add authentication and authorization middleware
app.UseAuthentication();
app.UseAuthorization();

// map route for Admin area
app.MapAreaControllerRoute(
    name: "admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

// map default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}/{slug?}");

app.Run();
