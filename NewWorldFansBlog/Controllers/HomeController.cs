using Microsoft.AspNetCore.Mvc;
using NewWorldFansBlog.Commands;
using NewWorldFansBlog.Commands.Requests;
using NewWorldFansBlog.Models;
using System.Diagnostics;

namespace NewWorldFansBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICommand<GetPostsRequest, HomePostsViewModel> _getPostsCommand;

        public HomeController(ILogger<HomeController> logger, ICommand<GetPostsRequest, HomePostsViewModel> getPostsCommand)
        {
            _logger = logger;
            _getPostsCommand = getPostsCommand;
        }

        public async Task<IActionResult> Index(int? page)
        {
            HomePostsViewModel viewModel = await _getPostsCommand.Handle(new GetPostsRequest { Page = page ?? 1 });
            return View("Index", viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}