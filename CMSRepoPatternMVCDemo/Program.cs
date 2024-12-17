using CMSRepoPatternMVCDemo.Models;
using CMSRepoPatternMVCDemo.Repository;
using CMSRepoPatternMVCDemo.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<EmpContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("CMSConn")));
builder.Services.AddScoped<IEmployee,EmployeeService>();
builder.Services.AddScoped<IDepartment, EmployeeService>();
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
