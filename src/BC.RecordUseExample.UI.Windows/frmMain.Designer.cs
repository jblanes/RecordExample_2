namespace BC.RecordUseExample.UI.Windows
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            dtBirthDate = new DateTimePicker();
            label2 = new Label();
            txtSalary = new TextBox();
            btnAddEmployee = new Button();
            errProvider = new ErrorProvider(components);
            lblId = new Label();
            ((System.ComponentModel.ISupportInitialize)errProvider).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(53, 52);
            label1.Name = "label1";
            label1.Size = new Size(119, 15);
            label1.TabIndex = 0;
            label1.Text = "Fecha de Nacimiento";
            // 
            // dtBirthDate
            // 
            dtBirthDate.Location = new Point(190, 46);
            dtBirthDate.Name = "dtBirthDate";
            dtBirthDate.Size = new Size(200, 23);
            dtBirthDate.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(53, 102);
            label2.Name = "label2";
            label2.Size = new Size(59, 15);
            label2.TabIndex = 2;
            label2.Text = "Salario ($)";
            // 
            // txtSalary
            // 
            txtSalary.Location = new Point(190, 99);
            txtSalary.Name = "txtSalary";
            txtSalary.Size = new Size(100, 23);
            txtSalary.TabIndex = 3;
            // 
            // btnAddEmployee
            // 
            btnAddEmployee.Location = new Point(192, 153);
            btnAddEmployee.Name = "btnAddEmployee";
            btnAddEmployee.Size = new Size(75, 23);
            btnAddEmployee.TabIndex = 4;
            btnAddEmployee.Text = "Añadir Empleado";
            btnAddEmployee.UseVisualStyleBackColor = true;
            btnAddEmployee.Click += btnAddEmployee_Click;
            // 
            // errProvider
            // 
            errProvider.ContainerControl = this;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(56, 10);
            lblId.Name = "lblId";
            lblId.Size = new Size(13, 15);
            lblId.TabIndex = 5;
            lblId.Text = "0";
            lblId.Visible = false;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(580, 265);
            Controls.Add(lblId);
            Controls.Add(btnAddEmployee);
            Controls.Add(txtSalary);
            Controls.Add(label2);
            Controls.Add(dtBirthDate);
            Controls.Add(label1);
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Información del Empleado";
            ((System.ComponentModel.ISupportInitialize)errProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DateTimePicker dtBirthDate;
        private Label label2;
        private TextBox txtSalary;
        private Button btnAddEmployee;
        private ErrorProvider errProvider;
        private Label lblId;
    }
}
