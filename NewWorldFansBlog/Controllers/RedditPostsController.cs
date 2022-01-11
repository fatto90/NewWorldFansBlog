using Microsoft.AspNetCore.Mvc;
using NewWorldFansBlog.Commands;
using NewWorldFansBlog.Commands.Models;
using NewWorldFansBlog.Commands.Requests;
using NewWorldFansBlog.Models;

namespace NewWorldFansBlog.Controllers
{
    public class RedditPostsController : Controller
    {
        private readonly ICommand<GetRedditPostsRequest, RedditPostsViewModel> _getRedditPostsCommand;

        public RedditPostsController(ICommand<GetRedditPostsRequest, RedditPostsViewModel> getRedditPostsCommand)
        {
            _getRedditPostsCommand = getRedditPostsCommand;
        }

        public async Task<IActionResult> Index(int? page, DirectionType? direction, string postName, PostFilterType? selectedFilter)
        {
            var request = new GetRedditPostsRequest { 
                Page = page ?? 1,
                Direction = direction ?? DirectionType.None,
                PostName = postName,
                SelectedFilter = selectedFilter ?? PostFilterType.New,
            };
            RedditPostsViewModel viewModel = await _getRedditPostsCommand.Handle(request);
            return View("Index", viewModel);
        }
    }
}
