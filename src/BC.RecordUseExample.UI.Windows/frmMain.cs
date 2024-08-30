using BC.RecordUseExample.Backend.App;
using BC.RecordUseExample.Backend.Domain.Commands;
using BC.RecordUseExample.UI.Windows.ViewModels;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace BC.RecordUseExample.UI.Windows
{
    public partial class frmMain : Form
    {
        private readonly SystemCommands _systemCommands;
        private readonly ILogger<frmMain> _logger;

        public frmMain(SystemCommands systemCommands, ILogger<frmMain> logger)
        {
            _systemCommands = systemCommands;
            InitializeComponent();
            _logger = logger;

            dtBirthDate.Value = DateTime.Now;
            ClearErrors();

        }

        private async void btnAddEmployee_Click(object sender, EventArgs e)
        {
            ClearErrors();

            var salary = TryParseNullable(txtSalary.Text);
          
            var employeeData = new EmployeeViewModel
            {
                Id = Convert.ToInt32(lblId.Text), BirthDate = dtBirthDate.Value, Salary = salary
            };

            try
            {
                var result = await _systemCommands.ProcessAsync(employeeData);
                if (result.IsFailure)
                {
                    PresentErrors(result);
                    return;
                }

                MessageBox.Show("Empleado creado con éxito.");
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                MessageBox.Show($"Error de sistema: {ex.Message}. Por favor trate de nuevo en unos minutos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearErrors()
        {
            foreach(Control ctrl in this.Controls)
            {
                if (ctrl is ErroMessageControl errCtrl)
                {
                    errCtrl.Clear();
                }
            }
        }

        private static decimal? TryParseNullable(string? val)
        {
            return decimal.TryParse(val, out decimal outValue) ? (decimal?)outValue : null;
        }

        private void PresentErrors(CommandResult result)
        {
            var errors = result.GetErrorMessages();
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is ErroMessageControl errCtrl)
                {
                    SetError(errCtrl, errors);
                }
            }
        }

        private void SetError(ErroMessageControl errCtrl, List<MessageText> errors)
        {
            errCtrl.SetError(errors);
        }

       
        
    }
}
