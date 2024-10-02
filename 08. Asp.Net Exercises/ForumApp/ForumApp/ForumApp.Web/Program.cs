using ForumApp.Data.Core;
using ForumApp.Repos;
using ForumApp.Repos.Contracts;
using ForumApp.Services;
using ForumApp.Services.Contracts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add dbContext
string connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<ForumAppContext>(options => options.UseSqlServer(connectionString));

// Add Post service
builder.Services.AddScoped<PostRepo>();
builder.Services.AddScoped<PostService>();

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
