using BC.RecordUseExample.Backend.App.Services;
using BC.RecordUseExample.Backend.Domain.Commands;
using BC.RecordUseExample.Backend.Domain.Commands.EmployeeCommands;

namespace BC.RecordUseExample.Backend.App.CommandHandlers
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
