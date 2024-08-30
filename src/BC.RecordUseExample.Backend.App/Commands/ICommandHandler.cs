namespace BC.RecordUseExample.Backend.App.Commands
{
    public interface ICommandHandler<T>
    {
        public abstract Task<CommandResult> HandleAsync(T command);
    }
}
