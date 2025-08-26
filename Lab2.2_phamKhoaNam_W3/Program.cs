
using BLL.Interface;
using BLL.Service;
using DAL.Models;
using DAL.Models.Interface;
using DAL.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);


//Context

builder.Services.AddDbContext<GameHubContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Service
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
// Add services to the container. 
builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache(); 
builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => {
        options.LoginPath = "/Login";
        options.AccessDeniedPath = "/AccessDenied";
    });
builder.Services.AddAuthorization();

builder.Services.AddSignalR();


var app = builder.Build();


// Configure the HTTP request pipeline. 
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}


// define default page is Login
app.MapGet("/", context =>
{
    context.Response.Redirect("/Shared/Login");
    return Task.CompletedTask;
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
//app.MapHub<>("/"); // SignalR
app.Run();