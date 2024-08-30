using BC.RecordUseExample.Backend.Domain.Validation;

namespace BC.RecordUseExample.Backend.Domain.Commands.EmployeeCommands
{
    public record CreateEmployeeCommand : ICommand<CreateEmployeeCommand>
    {
        public int Id { get; set; }
        public DateTime? BirthDate { get; set; }
        public decimal? Salary { get; set; }

        public CreateEmployeeCommand GetCommand()
        {
            return this;
        }

        CommandResult ICommand<CreateEmployeeCommand>.Validate()
        {
            CommandResult result = new();

            result.AddError(nameof(Id), Validators.IsValidId(Id));
            result.AddError(nameof(BirthDate), Validators.IsValidBirthDay(BirthDate));
            result.AddError(nameof(Salary), Validators.IsValidSalary(Salary));

            return result;
        }
    }
}
