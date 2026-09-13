using DesignPatternASP.Configuration;
using DesignPatterns.Models.Models;
using DesignPatterns.Repository;
using Microsoft.EntityFrameworkCore;
using Tools.Earn;
using Tools.Generator;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.Configure<MyConfig>(builder.Configuration.GetSection("MyConfig")); // Inyeccion de dependencia de la variable en appsettings.json mediante el patron Options Pattern

builder.Services.AddTransient((factory) => new LocalEarnFactory(builder.Configuration.GetSection("MyConfig").GetValue<decimal>("LocalPercentage")));


// Inyectar DBContext
builder.Services.AddDbContext<DesignPatternsContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Connection"));
});
// Repository
builder.Services.AddScoped(typeof(IRepository<>), typeof(IRepository<>));
// Inyectar UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
// Inyeccion de builder concrete
builder.Services.AddScoped<GeneratorConcreteBuilder>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
