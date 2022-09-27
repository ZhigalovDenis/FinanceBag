using FinanceBag.Data;
using FinanceBag.Models;
using FinanceBag.Repositories;
using FinanceBag.Services;
using FinanceBag.ViewModel;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));
builder.Services.AddScoped<IBaseRepository<Active, string>, ActiveRepository>();
builder.Services.AddScoped<IBaseRepository<TypeOfActive, int>, TypeOfActiveRepository>();
builder.Services.AddScoped<IBaseRepository<Deal, int>, DealRepository>();
builder.Services.AddScoped<ISelectRepository, DealRepository>();
builder.Services.AddTransient<IRequestHandlerService<AnaliticsViewModel, TypeOfActive>, RequestHandlerService>();
builder.Services.AddTransient<IGetLastPriceService, GetLastPriceService>();


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

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

//Для того что бы можно было работать с дробными числами
    app.UseRequestLocalization();
    CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
    CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-US");


app.Run();
