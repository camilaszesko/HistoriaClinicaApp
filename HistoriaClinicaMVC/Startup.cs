using HistoriaClinicaMVC.Data;
using HistoriaClinicaMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace HistoriaClinicaMVC
{

    public static class Startup
{

    public static WebApplication InicializarApp(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        ConfigureServices(builder);

        var app = builder.Build();
        Configure(app);
        return app;
    }

    private static void ConfigureServices(WebApplicationBuilder builder)
  {

        builder.Services.AddDbContext<HistoriaClinicaContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("HCADBCS")));

        builder.Services.AddIdentity<Persona, Rol>().AddEntityFrameworkStores<HistoriaClinicaContext>();
            builder.Services.Configure<IdentityOptions>(opciones =>

              {
                  opciones.Password.RequireNonAlphanumeric = false;
                  opciones.Password.RequireUppercase = false;
                  opciones.Password.RequireLowercase = false;
                  opciones.Password.RequireDigit = false;
                  opciones.Password.RequiredLength = 5;
              }
                
                ) ;

        builder.Services.AddControllersWithViews();
  }

   private static void Configure(WebApplication app)
   {
        
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
    }





}
}