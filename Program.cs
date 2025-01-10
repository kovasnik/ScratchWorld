using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ScratchWorld.BLL.Interfaces;
using ScratchWorld.BLL.Services;
using ScratchWorld.Data;
using ScratchWorld.Data.Interfaces;
using ScratchWorld.Data.Repository;
using ScratchWorld.Models;

var builder = WebApplication.CreateBuilder(args);

// Add repositores to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRegionRepository, RegionRepository>();
builder.Services.AddScoped<ILandmarkRepository, LandmarkRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IRegionSettingsRepository, RegionSettingsRepository>();

// Add services to the container.
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IMapService, MapService>();

builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseNpgsql(builder.Configuration.GetConnectionString("ScratchWorldDb"));
});
builder.Services.AddIdentity<User, IdentityRole>(options => { 
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false; })
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

var app = builder.Build();

//if (args.Length == 1 && args[0].ToLower() == "seeddata")
//{
//    //Seed.SeedData(app);
//    await AdminSeed.SeedAdmin(app);
//}

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
