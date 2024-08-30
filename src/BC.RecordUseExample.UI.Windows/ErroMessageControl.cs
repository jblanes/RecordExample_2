using BC.RecordUseExample.Backend.Domain.Commands;

namespace BC.RecordUseExample.UI.Windows
{
    public partial class ErroMessageControl : UserControl
    {
        public string FieldName { get; set; } = string.Empty;

        public ErroMessageControl()
        {
            InitializeComponent();

        }

        public void SetError(List<MessageText> errors)
        {
            errors.ForEach(err =>
            {
                if (err.FieldName == FieldName)
                {
                    lblError.Text = err;
                    this.Visible = true;
                }
            });
        }

        public void Clear()
        {
            this.Visible = false;
            lblError.Text = string.Empty;
        }
    }
}
