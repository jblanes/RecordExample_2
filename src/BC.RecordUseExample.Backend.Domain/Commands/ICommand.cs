namespace BC.RecordUseExample.Backend.Domain.Commands
{
    public interface ICommand<T>
    {
        T GetCommand();
        CommandResult Validate();
    }
}
