
using Microsoft.EntityFrameworkCore;
using PustoKen.DAL;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(builder.Configuration["ConnectionStrings:Default"]));


builder.Services.AddControllersWithViews();

var app = builder.Build();


app.UseStaticFiles();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=DashBoard}/{action=Index}/{id?}"
    );
});

app.MapDefaultControllerRoute();

app.Run();