namespace ModernStore.Shared.Commands
{
    public interface ICommandHandler<T> where T : class
    {
        void Handle(T command);
    }
}
