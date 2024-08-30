using BC.RecordUseExample.Backend.App.Commands;
using BC.RecordUseExample.Backend.App.Commands.EmployeeCommands;

namespace BC.RecordUseExample.UI.Razor.ViewModels
{
    public class EmployeeViewModel : ICreateCommandParseable<CreateEmployeeCommand>
    {
        public int Id { get; set; }
        public DateTime? BirthDate { get; set; }
        public decimal? Salary { get; set; }

        public ICommand<CreateEmployeeCommand> ToCreateCommand()
        {
            return new CreateEmployeeCommand { Id = Id, BirthDate = BirthDate, Salary = Salary };
        }
    }
}
