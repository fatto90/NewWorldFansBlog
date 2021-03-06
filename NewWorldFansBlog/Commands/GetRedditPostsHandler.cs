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

            IEnumerable<RedditPostModel> postModelsQuery = container?.Data?.Childrens.Select(x => x.Data);
            return new RedditPostsViewModel
            {
                CurrentPage = request.Page,
                Posts = postModelsQuery.OrderByDescending(x => x.Pinned).ThenByDescending(x => x.Date).ToList(),
                SelectedFilter = request.SelectedFilter,
            };
        }

        private string GetPostsUrl(GetRedditPostsRequest request)
        {
            string baseUrl = $"https://www.reddit.com/r/newworldgame/{request.SelectedFilter.ToString().ToLower()}.json";
            string getRedditPostsUrl = baseUrl;
            if (!string.IsNullOrEmpty(request.PostName) && request.Page != 1)
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
