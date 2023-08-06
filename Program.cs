using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UberEats.Models;
using UberEats.Models.DataLayer.Reporsitories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddMemoryCache();
builder.Services.AddSession();


builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<UberContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("UberContext")));

builder.Services.AddTransient<IMenuReporsitory, MenuReporsitory>();
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    
    options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<UberContext>()
.AddDefaultTokenProviders();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();


app.UseAuthentication();
app.UseAuthorization();


app.MapAreaControllerRoute(
    name: "admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}/{slug?}");

app.Run();
