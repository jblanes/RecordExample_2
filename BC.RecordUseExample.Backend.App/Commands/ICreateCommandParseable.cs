namespace BC.RecordUseExample.Backend.App.Commands
{
    public interface ICreateCommandParseable<T>
    {
        ICommand<T> ToCreateCommand();
    }
}
