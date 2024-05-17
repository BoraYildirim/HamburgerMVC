using HamburgerMVC.DAL;
using HamburgerMVC.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Session s�resi
    options.Cookie.HttpOnly = true; // G�venlik i�in
    options.Cookie.IsEssential = true; // GDPR i�in gerekli
});

//Context s�n�f� i�in...
builder.Services.AddDbContext<BurgerDBContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr")));

//Identity i�in
builder.Services.AddIdentity<Uye, Rol>(x => x.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<BurgerDBContext>()
                .AddRoles<Rol>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
