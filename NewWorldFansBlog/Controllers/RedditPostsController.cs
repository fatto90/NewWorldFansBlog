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
            return View("Index", await GetRedditPostViewModel(page, direction, postName, selectedFilter));
        }

        public async Task<IActionResult> RenderPostList(int? page, DirectionType? direction, string postName, PostFilterType? selectedFilter)
        {
            var viewModel = await GetRedditPostViewModel(page, direction, postName, selectedFilter);
            var mappedPostViewModels = viewModel.Posts.Select(x => new PostViewModel {
                Author = x.Author,
                Date = x.Date,
                Subtitle = x.Title,
                Url = x.Url,
                Pinned = x.Pinned
            }).ToList();
            return PartialView("_PostListPartial", mappedPostViewModels);
        }

        private async Task<RedditPostsViewModel> GetRedditPostViewModel(int? page, DirectionType? direction, string postName, PostFilterType? selectedFilter)
        {
            var request = new GetRedditPostsRequest
            {
                Page = page ?? 1,
                Direction = direction ?? DirectionType.None,
                PostName = postName,
                SelectedFilter = selectedFilter ?? PostFilterType.New,
            };
            RedditPostsViewModel viewModel = await _getRedditPostsCommand.Handle(request);
            return viewModel;
        }
    }
}
