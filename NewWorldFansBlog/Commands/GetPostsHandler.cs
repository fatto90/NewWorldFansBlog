using NewWorldFansBlog.Commands.Models;
using NewWorldFansBlog.Commands.Requests;
using NewWorldFansBlog.Models;
using NewWorldFansBlog.Utilities;

namespace NewWorldFansBlog.Commands
{
    public class GetPostsHandler : ICommand<GetPostsRequest, HomePostsViewModel>
    {
        private readonly IAPIRequestClient<List<PostModel>> API;

        public GetPostsHandler(IAPIRequestClient<List<PostModel>> api)
        {
            API = api;
        }

        public async Task<HomePostsViewModel> Handle(GetPostsRequest request)
        {
            string getPostsUrl = $"https://newworldfans.com/api/v1/dev_tracker?page={request.Page}";
            List<PostModel>? posts = await API.GetResponse(getPostsUrl);

            return new HomePostsViewModel
            {
                CurrentPage = request.Page,
                Posts = posts,
            };
        }
    }
}
