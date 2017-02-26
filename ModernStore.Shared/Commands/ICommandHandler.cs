namespace ModernStore.Shared.Commands
{
    public interface ICommandHandler<T> where T : class
    {
        ICommandResult Handle(T command);
    }
}
