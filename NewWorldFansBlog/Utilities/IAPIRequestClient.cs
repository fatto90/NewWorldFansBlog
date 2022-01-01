namespace NewWorldFansBlog.Utilities
{
    public interface IAPIRequestClient<T>
    {
        Task<T?> GetResponse(string url);
    }
}
