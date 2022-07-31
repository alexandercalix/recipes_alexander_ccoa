using recipes_alexander_ccoa.Core.Data;
using recipes_alexander_ccoa.Core.Models;
using recipes_alexander_ccoa.Core.Service;
using recipes_alexander_ccoa.web.Reports;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<recipesContext>();
builder.Services.AddScoped<crudService<Recetas>>();
builder.Services.AddScoped<crudService<Motores>>();

builder.Services.AddScoped<RecipesReport>();
builder.Services.AddScoped<MaintenanceReport>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("NewPolicy", builder =>
     builder.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader());
});

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
}

app.UseStaticFiles();
app.UseRouting();

app.UseCors("NewPolicy");


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
