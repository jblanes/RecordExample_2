namespace BC.RecordUseExample.Backend.App.Commands
{
    public interface ICommand<T>
    {
        T GetCommand();
        CommandResult Validate();
    }
}
