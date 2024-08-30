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
            label1 = new Label();
            dtBirthDate = new DateTimePicker();
            label2 = new Label();
            txtSalary = new TextBox();
            btnAddEmployee = new Button();
            lblId = new Label();
            erroMessageControl1 = new ErroMessageControl();
            erroMessageControl2 = new ErroMessageControl();
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
            btnAddEmployee.Location = new Point(190, 163);
            btnAddEmployee.Name = "btnAddEmployee";
            btnAddEmployee.Size = new Size(75, 23);
            btnAddEmployee.TabIndex = 4;
            btnAddEmployee.Text = "Añadir Empleado";
            btnAddEmployee.UseVisualStyleBackColor = true;
            btnAddEmployee.Click += btnAddEmployee_Click;
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
            // erroMessageControl1
            // 
            erroMessageControl1.FieldName = "Salary";
            erroMessageControl1.ForeColor = Color.Red;
            erroMessageControl1.Location = new Point(56, 128);
            erroMessageControl1.Name = "erroMessageControl1";
            erroMessageControl1.Size = new Size(360, 19);
            erroMessageControl1.TabIndex = 6;
            // 
            // erroMessageControl2
            // 
            erroMessageControl2.FieldName = "BirthDate";
            erroMessageControl2.ForeColor = Color.Red;
            erroMessageControl2.Location = new Point(56, 75);
            erroMessageControl2.Name = "erroMessageControl2";
            erroMessageControl2.Size = new Size(457, 19);
            erroMessageControl2.TabIndex = 7;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(558, 265);
            Controls.Add(erroMessageControl2);
            Controls.Add(erroMessageControl1);
            Controls.Add(lblId);
            Controls.Add(btnAddEmployee);
            Controls.Add(txtSalary);
            Controls.Add(label2);
            Controls.Add(dtBirthDate);
            Controls.Add(label1);
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Información del Empleado";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DateTimePicker dtBirthDate;
        private Label label2;
        private TextBox txtSalary;
        private Button btnAddEmployee;
        private Label lblId;
        private ErroMessageControl erroMessageControl1;
        private ErroMessageControl erroMessageControl2;
    }
}
