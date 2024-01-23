using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Petrol_Station_Manegement_System.DataAccess;
using PetrolStation.DataAccess.Repository;
using PetrolStation.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnectaion")
    ));

builder.Services.AddSession(
        Option =>
        {
            Option.IdleTimeout = TimeSpan.FromHours(6);
            Option.Cookie.HttpOnly = true;
            Option.Cookie.IsEssential = true;
        }
    );
builder.Services.AddScoped<IUnitOfwork,UnitOfwork>();
var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.UseSession();

app.Run();
