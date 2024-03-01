using HotelManagementSystem.Data;
using HotelManagementSystem.Models;
using HotelManagementSystem.Service;
using HotelManagementSystem.Service.Impl;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddRazorPages();
builder.Services.AddScoped<IRepository<HotelRooms>, Repository<HotelRooms>>();
builder.Services.AddScoped<IRepository<Customers>, Repository<Customers>>();
builder.Services.AddScoped<IRepository<Reservations>, Repository<Reservations>>();
builder.Services.AddScoped<IRepository<Payments>, Repository<Payments>>();
var connectionString = builder.Configuration.
    GetConnectionString("HotelManagamentSystemContextConnection") ?? 
    throw
    new InvalidOperationException("Connection string 'HotelManagamentSystemContextConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
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
