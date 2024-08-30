using BC.RecordUseExample.Backend.Domain.Commands.EmployeeCommands;

namespace BC.RecordUseExample.Backend.App.Services
{
    public interface IEmployeeService
    {
        Task TryCreateAndSaveEmployeeAsync(CreateEmployeeCommand createEmployeeCommand);
    }
}