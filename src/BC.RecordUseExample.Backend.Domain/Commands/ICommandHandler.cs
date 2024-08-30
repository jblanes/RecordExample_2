namespace BC.RecordUseExample.Backend.Domain.Commands
{
    public interface ICommandHandler<T>
    {
        public abstract Task<CommandResult> HandleAsync(T command);
    }
}
