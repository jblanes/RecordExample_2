namespace BC.RecordUseExample.Backend.Domain.Commands
{
    public interface ICreateCommandParseable<T>
    {
        ICommand<T> ToCreateCommand();
    }
}
