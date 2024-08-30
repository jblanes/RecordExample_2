namespace BC.RecordUseExample.UI.Windows
{
    partial class ErroMessageControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblError = new Label();
            SuspendLayout();
            // 
            // lblError
            // 
            lblError.Dock = DockStyle.Fill;
            lblError.Location = new Point(0, 0);
            lblError.Name = "lblError";
            lblError.Size = new Size(171, 19);
            lblError.TabIndex = 0;
            lblError.Text = "err_message";
            // 
            // ErroMessageControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblError);
            ForeColor = Color.Red;
            Name = "ErroMessageControl";
            Size = new Size(171, 19);
            ResumeLayout(false);
        }

        #endregion

        private Label lblError;
    }
}
