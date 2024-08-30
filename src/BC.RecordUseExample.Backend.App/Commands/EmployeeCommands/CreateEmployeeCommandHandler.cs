using BC.RecordUseExample.Backend.App.Commands;
using BC.RecordUseExample.Backend.App.Services;

namespace BC.RecordUseExample.Backend.App.Commands.EmployeeCommands
{
    internal class CreateEmployeeCommandHandler(IEmployeeService employeeService) : ICommandHandler<CreateEmployeeCommand>
    {
        private readonly IEmployeeService _employeeService = employeeService;

        public async Task<CommandResult> HandleAsync(CreateEmployeeCommand command)
        {
            await _employeeService.TryCreateAndSaveEmployeeAsync(command);
            return new();
        }

    }
}
