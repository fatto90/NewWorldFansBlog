using NewWorldFansBlog.Commands;
using NewWorldFansBlog.Commands.Models;
using NewWorldFansBlog.Models;
using NewWorldFansBlog.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IAPIRequestClient<List<PostModel>>, APIRequestClient<List<PostModel>>>();
builder.Services.AddScoped<ICommand<GetPostsRequest, PostsViewModel>, GetPostsHandler>();

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
