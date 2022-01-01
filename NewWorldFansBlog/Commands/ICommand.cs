namespace NewWorldFansBlog.Commands
{
    public interface ICommand<T,M>
    {
        Task<M> Handle(T request);
    }
}
