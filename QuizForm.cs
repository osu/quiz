using System;
using System.Drawing;
using System.Net.Mail;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace BasicQuizApplicationWithUI
{
    public partial class QuizForm : Form
    {
        private Quiz _quiz;
        private Question _currentQuestion;
        private string _userName;
        private string _userEmail;
        private System.Windows.Forms.Timer _questionTimer;
        private int _timeLeft; // Remaining time for the current question

        public QuizForm(string userName, string userEmail)
        {
            InitializeComponent();
            _userName = userName;
            _userEmail = userEmail;
            _quiz = new Quiz();
            InitializeFormStyles(); // Initialize custom styles
            InitializeTimer();
            LoadNextQuestion();
        }

        private void InitializeFormStyles()
        {
            // Set form background image
            this.BackgroundImage = Image.FromFile("apd.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;

            // Center the question label
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.ForeColor = Color.White;
            label1.BackColor = Color.Transparent; // Make label background transparent
            label1.AutoSize = false;
            label1.Dock = DockStyle.Top;
            label1.Height = 270; // Adjust height as needed
            label1.Font = new Font("Arial", 18, FontStyle.Bold);

            // Style radio buttons
            foreach (Control control in this.Controls)
            {
                if (control is RadioButton radioButton)
                {
                    radioButton.ForeColor = Color.White;
                    radioButton.BackColor = Color.Transparent; // Transparent background
                }
            }

            // Center the Next button
            buttonNext.Text = "Next";
            buttonNext.ForeColor = Color.White;
            buttonNext.BackColor = Color.DarkSlateGray;
            buttonNext.FlatStyle = FlatStyle.Flat;
            buttonNext.FlatAppearance.BorderSize = 0;
            buttonNext.Dock = DockStyle.Bottom;
            buttonNext.Height = 20; // Adjust height as needed
        }

        private void InitializeTimer()
        {
            _questionTimer = new System.Windows.Forms.Timer { Interval = 1000 }; // 1 second
            _questionTimer.Tick += QuestionTimer_Tick;
        }

        private void LoadNextQuestion()
        {
            _currentQuestion = _quiz.GetNextQuestion();

            if (_currentQuestion != null)
            {
                // Reset timer and progress bar
                _timeLeft = 15;
                progressBarTime.Maximum = 15;
                progressBarTime.Value = 15;
                _questionTimer.Start();

                // Display the question and options
                label1.Text = _currentQuestion.Text;
                radioButton1.Text = _currentQuestion.Options[0];
                radioButton2.Text = _currentQuestion.Options[1];
                radioButton3.Text = _currentQuestion.Options[2];
                radioButton4.Text = _currentQuestion.Options[3];
            }
            else
            {
                _questionTimer.Stop();
                DisplayResults();
            }
        }

        private void QuestionTimer_Tick(object? sender, EventArgs e)
        {
            if (_timeLeft > 0)
            {
                _timeLeft--;
                progressBarTime.Value = _timeLeft;
            }
            else
            {
                _questionTimer.Stop();
                MessageBox.Show("Time's up! Moving to the next question.", "Time Out", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadNextQuestion();
            }
        }

        private void DisplayResults()
        {
            label1.Text = "Quiz Completed!";
            label2.Text = $"Your score: {_quiz.Score} out of {_quiz.GetQuestionCount()}";
            buttonNext.Enabled = false;
            progressBarTime.Visible = false; // Hide progress bar after completion

            // Send the results via email (you can choose the method below)
            SendScoreByEmail();
        }

        private int GetSelectedOption()
        {
            if (radioButton1.Checked) return 0;
            if (radioButton2.Checked) return 1;
            if (radioButton3.Checked) return 2;
            if (radioButton4.Checked) return 3;
            return -1;
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            int selectedOption = GetSelectedOption();
            if (selectedOption != -1)
            {
                _quiz.CheckAnswer(selectedOption);
                _questionTimer.Stop(); // Stop the timer before loading the next question
                LoadNextQuestion();
            }
            else
            {
                MessageBox.Show("Please select an option before proceeding.");
            }
        }

        private void SendScoreByEmail()
        {
            try
            {
                // Set up SMTP server and credentials for SendGrid
                string smtpServer = "smtp.sendgrid.net"; // SendGrid's SMTP server
                string senderEmail = "example@gmail.com"; // Use your verified sender email from SendGrid
                string apiKey = "x"; // Your SendGrid API Key

                // Construct the email
                MailMessage mail = new MailMessage
                {
                    From = new MailAddress(senderEmail, "Quiz Application"),
                    Subject = "Quiz Results",
                    Body = $"Hello {_userName},\n\nYour score is: {_quiz.Score} out of {_quiz.GetQuestionCount()}.\n\nThank you for participating!",
                    IsBodyHtml = false // Change to true if sending HTML content
                };
                mail.To.Add(_userEmail);

                // Set up the SMTP client
                SmtpClient smtp = new SmtpClient(smtpServer)
                {
                    Port = 587, // TLS connection
                    Credentials = new System.Net.NetworkCredential("apikey", apiKey), // Username is "apikey", password is the API key
                    EnableSsl = true // Use TLS/SSL
                };

                // Send the email
                smtp.Send(mail);
                MessageBox.Show("Results emailed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to send email: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
