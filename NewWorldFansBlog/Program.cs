using NewWorldFansBlog.Commands;
using NewWorldFansBlog.Commands.Models;
using NewWorldFansBlog.Commands.Requests;
using NewWorldFansBlog.Models;
using NewWorldFansBlog.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IAPIRequestClient<List<PostModel>>, APIRequestClient<List<PostModel>>>();
builder.Services.AddSingleton<ICommand<GetPostsRequest, PostsViewModel>, GetPostsHandler>();
builder.Services.AddSingleton<IAPIRequestClient<RedditPostContainerModel>, APIRequestClient<RedditPostContainerModel>>();
builder.Services.AddSingleton<ICommand<GetRedditPostsRequest, RedditPostsViewModel>, GetRedditPostsHandler>();

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
