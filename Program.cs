using CRMTask.Data;
using Microsoft.EntityFrameworkCore;
namespace CRMTask;

static class Program
{
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<AppDBContext>( options => options.UseSqlServer(
            builder.Configuration.GetConnectionString("DefaultConnection")));

        var app = builder.Build();

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}


