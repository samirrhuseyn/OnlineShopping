using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<Context>().AddDefaultTokenProviders();
builder.Services.AddControllersWithViews();
builder.Services.AddSession();


builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
                     .RequireAuthenticatedUser()
                     .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});
builder.Services.AddMvc();
builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(x =>
    {
        x.LoginPath = "/Login/Index";
    });

builder.Services.ConfigureApplicationCookie(options =>
{
    //Cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(100);
    options.AccessDeniedPath = new PathString("/Login/AccessDenied/");
    options.LoginPath = "/Login/Index";
    options.SlidingExpiration = true;
});
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        areaName: "Admin",
        name: "Admin",
        pattern: "Admin/{controller=Student}/{action=Index}/{id?}"
        );

    endpoints.MapAreaControllerRoute(
        areaName: "Seller",
        name: "Seller",
        pattern: "Seller/{controller=Student}/{action=Index}/{id?}"
        );

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
        );


});
app.Run();
