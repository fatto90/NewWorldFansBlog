using NewWorldFansBlog.Commands.Models;
using NewWorldFansBlog.Commands.Requests;
using NewWorldFansBlog.Models;
using NewWorldFansBlog.Utilities;

namespace NewWorldFansBlog.Commands
{
    public class GetRedditPostsHandler : ICommand<GetRedditPostsRequest, RedditPostsViewModel>
    {
        private readonly IAPIRequestClient<RedditPostContainerModel> API;

        public GetRedditPostsHandler(IAPIRequestClient<RedditPostContainerModel> api)
        {
            API = api;
        }

        public async Task<RedditPostsViewModel> Handle(GetRedditPostsRequest request)
        {
            string getRedditPostsUrl = GetPostsUrl(request);

            RedditPostContainerModel? container = await API.GetResponse(getRedditPostsUrl);

            return new RedditPostsViewModel
            {
                CurrentPage = request.Page,
                Posts = container?.Data?.Childrens.Select(x => x.Data).OrderByDescending(x => x.Date).ToList(),
            };
        }

        private string GetPostsUrl(GetRedditPostsRequest request)
        {
            string baseUrl = "https://www.reddit.com/r/newworldgame/top.json";
            string getRedditPostsUrl = baseUrl;
            if (!string.IsNullOrEmpty(request.PostName))
            {
                switch (request.Direction)
                {
                    case DirectionType.After:
                        getRedditPostsUrl = $"{baseUrl}?after={request.PostName}";
                        break;
                    case DirectionType.Before:
                        getRedditPostsUrl = $"{baseUrl}?before={request.PostName}";
                        break;
                    default:
                        break;
                }
            }
            return getRedditPostsUrl;
        }
    }
}
