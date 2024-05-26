using FiorelloFrontBackDB.Data;
using FiorelloFrontBackDB.Services;
using FiorelloFrontBackDB.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IProductService, ProductService>(); 
builder.Services.AddScoped<ICategoryService, CategoryService>(); 
builder.Services.AddScoped<IExpertService, ExpertService>(); 
builder.Services.AddScoped<ISliderInstaService, SliderInstaService>(); 
builder.Services.AddScoped<IBlogService, BlogService>(); 
builder.Services.AddScoped<ISettingService, SettingService>(); 
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); 

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




app.MapControllerRoute(
  name: "areas",
  pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
