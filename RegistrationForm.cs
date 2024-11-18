using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BasicQuizApplicationWithUI
{
    public partial class RegistrationForm : Form
    {
        // Properties to store the entered data
        public string UserName { get; private set; }
        public string UserEmail { get; private set; }

        // Constructor
        public RegistrationForm()
        {
            // Setup the form manually
            SetupUI();
        }

        // Button click event handler
        private void buttonRegister_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(textBoxName.Text) || string.IsNullOrWhiteSpace(textBoxEmail.Text))
            {
                // Show a warning if fields are empty
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Email validation using regex
            string email = textBoxEmail.Text;
            if (!IsValidEmail(email))
            {
                // Show a warning if the email is invalid
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UserName = textBoxName.Text;
            UserEmail = email;

            // Close the form with OK result
            DialogResult = DialogResult.OK;
            Close();
        }

        // Method to validate email
        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        // Manual UI setup
        private void SetupUI()
        {
            // Form properties
            this.Text = "User Registration";
            this.Size = new Size(400, 300);
            this.BackgroundImage = Image.FromFile("joema.jpg"); // Set the background image
            this.BackgroundImageLayout = ImageLayout.Stretch; // Stretch the image to fit the form
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Labels
            Label labelName = new Label
            {
                Text = "Name:",
                Location = new Point(20, 30),
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Bold),
                BackColor = Color.Transparent, // Ensure transparency for the label background
                ForeColor = Color.White // Text color to contrast with the image
            };
            Label labelEmail = new Label
            {
                Text = "Email:",
                Location = new Point(20, 80),
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Bold),
                BackColor = Color.Transparent, // Ensure transparency for the label background
                ForeColor = Color.White // Text color to contrast with the image
            };

            // TextBoxes
            TextBox textBoxName = new TextBox
            {
                Location = new Point(100, 25),
                Size = new Size(250, 30),
                Font = new Font("Arial", 10, FontStyle.Regular)
            };
            TextBox textBoxEmail = new TextBox
            {
                Location = new Point(100, 75),
                Size = new Size(250, 30),
                Font = new Font("Arial", 10, FontStyle.Regular)
            };
            this.textBoxName = textBoxName; // Bind to class-level variable
            this.textBoxEmail = textBoxEmail; // Bind to class-level variable

            // Button
            Button buttonRegister = new Button
            {
                Text = "Register",
                Location = new Point(150, 150),
                Size = new Size(100, 40),
                BackColor = Color.MediumSeaGreen,
                ForeColor = Color.White,
                Font = new Font("Arial", 12, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat // Modern button style
            };
            buttonRegister.Click += buttonRegister_Click;

            // Add controls to the form
            this.Controls.Add(labelName);
            this.Controls.Add(textBoxName);
            this.Controls.Add(labelEmail);
            this.Controls.Add(textBoxEmail);
            this.Controls.Add(buttonRegister);
        }
    }
}
