namespace BC.RecordUseExample.Backend.App.Validation
{
    internal static class Validators
    {
        public static string IsValidBirthDay(DateTime? birthday)
        {

            return Validator.Value(birthday).Where(b => !b.HasValue, "Favor entrar Fecha de nacimiento.")
                .Then(b => b < new DateTime(DateTime.Now.Year - 125, DateTime.Now.Month, DateTime.Now.Day), "Fecha de nacimiento incorrecta: Persona no puede tener más de 125 años.")
                .Then(b => b > DateTime.Now, "Fecha de nacimiento incorrecta: Fechas futuras no son permitidas.")
                .Message;

        }

        public static string IsValidSalary(decimal? salary)
        {

            return Validator.Value(salary).Where(b => !b.HasValue, "Favor entrar el valor del Salario.")
                .Then(b => b < decimal.Zero, "Salario no puede ser negativo.")
                .Then(b => b > 1_000_000M, "Salario no puede ser mayor de $1 millón.")
                .Message;

        }

        public static string IsValidId(int id)
        {

            return Validator.Value(id).Where(b => b < 0, "Id's no pueden ser negativos")
                .Message;

        }
    }
}
