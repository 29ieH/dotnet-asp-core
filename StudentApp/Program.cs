using Microsoft.EntityFrameworkCore;
using StudentApp.Models;
using StudentApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration;
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("Default"));
});
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
    pattern: "{controller=Student}/{action=Index}/{id?}");

app.Run();
