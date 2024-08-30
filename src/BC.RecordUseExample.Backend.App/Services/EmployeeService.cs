using BC.RecordUseExample.Backend.Domain.Commands.EmployeeCommands;
using BC.RecordUseExample.Backend.Infrastructure;
using BC.RecordUseExample.Backend.Infrastructure.DbModels;

namespace BC.RecordUseExample.Backend.App.Services
{
    public class EmployeeService(SqlDbContext db) : IEmployeeService
    {
        public readonly SqlDbContext _db = db;

        public async Task TryCreateAndSaveEmployeeAsync(CreateEmployeeCommand createEmployeeCommand)
        {
            // Convierte el comando a modelo de Base de datos y lo guarda.
            // Al estar el comando ya validado, no es necesário código de validación aquí. El sistema viene protegido de datos incorrectos.
            // Si el Save falla es por errores a conexión de base de datos, que se pueden mitigar con retries automáticos usando librerías como Polly, etc.
            Employee employee = MapFromCreateEmployeeCommand(createEmployeeCommand);
            await _db.Employees.AddAsync(employee);
            await _db.SaveChangesAsync();
        }

        public static Employee MapFromCreateEmployeeCommand(CreateEmployeeCommand cmd) => new() { Id = cmd.Id, BirthDate = cmd.BirthDate!.Value, Salary = cmd.Salary!.Value };
    }
}
