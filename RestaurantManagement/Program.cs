using Microsoft.EntityFrameworkCore;
using RestaurantManagement.service.DependencyInjection;
using RestaurantManagement.Service.Interfaces;
using RestaurantManagement.Service.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IRestaurantService, RestaurantService>();

builder.Services.AddRestaurantManagmentService(builder.Configuration);

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
    pattern: "{controller=Restaurant}/{action=Index}/{id?}");

app.Run();
