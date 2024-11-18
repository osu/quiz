namespace BasicQuizApplicationWithUI
{
    partial class RegistrationForm
    {
        private System.ComponentModel.IContainer components = null;

        private TextBox textBoxName;
        private TextBox textBoxEmail;
        private Label labelName;
        private Label labelEmail;
        private Button buttonRegister;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            textBoxName = new TextBox();
            textBoxEmail = new TextBox();
            labelName = new Label();
            labelEmail = new Label();
            buttonRegister = new Button();
            SuspendLayout();
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(120, 30);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(200, 23);
            textBoxName.TabIndex = 0;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(120, 70);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(200, 23);
            textBoxEmail.TabIndex = 1;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(30, 30);
            labelName.Name = "labelName";
            labelName.Size = new Size(39, 15);
            labelName.TabIndex = 2;
            labelName.Text = "Name";
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Location = new Point(30, 70);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(36, 15);
            labelEmail.TabIndex = 3;
            labelEmail.Text = "Email";
            // 
            // buttonRegister
            // 
            buttonRegister.Location = new Point(120, 110);
            buttonRegister.Name = "buttonRegister";
            buttonRegister.Size = new Size(100, 30);
            buttonRegister.TabIndex = 4;
            buttonRegister.Text = "Register";
            buttonRegister.UseVisualStyleBackColor = true;
            buttonRegister.Click += buttonRegister_Click;
            // 
            // RegistrationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 200);
            Controls.Add(textBoxName);
            Controls.Add(textBoxEmail);
            Controls.Add(labelName);
            Controls.Add(labelEmail);
            Controls.Add(buttonRegister);
            Name = "RegistrationForm";
            Text = "User Registration";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
