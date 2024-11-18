using System;
using System.Windows.Forms;

namespace BasicQuizApplicationWithUI
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Show the Registration Form
            using (var regForm = new RegistrationForm())
            {
                if (regForm.ShowDialog() == DialogResult.OK)
                {
                    // If registration is successful, start the quiz
                    Application.Run(new QuizForm(regForm.UserName, regForm.UserEmail));
                }
            }
        }
    }
}

