# **Basic Quiz Application with User Registration**

## **Overview**
The Basic Quiz Application is a simple yet interactive desktop application built using Windows Forms in C#. It allows users to register with their name and email address, take a multiple-choice quiz, and receive their results via email. The app is designed with an intuitive interface, incorporating features like time-limited questions, a visually appealing background, and automated email integration for sharing quiz results.

---

## **Features**
- **User Registration**: Users can register with their name and email address before starting the quiz.
- **Multiple-Choice Quiz**: Users answer a series of questions with four options each.
- **Timer**: Each question is time-limited to add an element of challenge.
- **Progress Bar**: Displays the remaining time for each question.
- **Dynamic Background**: The application features customizable background images for both the registration and quiz forms.
- **Email Integration**: Final quiz results are sent to the registered email using SendGrid SMTP integration.
- **Responsive Design**: The application adjusts the layout for better readability and interaction.

---

## **Technology Stack**
- **Programming Language**: C#
- **Framework**: .NET 8.0 Windows Forms
- **SMTP Integration**: SendGrid API for email delivery
- **UI Design**: Windows Forms Designer
- **Image Assets**: Background images (`joes.png` and `apd.jpg`)

---

## **Prerequisites**
- .NET 8.0 SDK
- Visual Studio (or any compatible C# IDE)
- An active SendGrid account for email integration
- Background images:
  - `joes.png` for the registration page
  - `apd.jpg` for the quiz page

---

## **Installation**
1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/basic-quiz-application.git
   ```
2. Navigate to the project directory:
   ```bash
   cd basic-quiz-application
   ```
3. Open the project in Visual Studio.
4. Replace the `API Key` and `Sender Email` in `QuizForm.cs` and `RegistrationForm.cs` with your SendGrid credentials.
5. Place the background images (`joes.png` and `apd.jpg`) in the project's root directory.
6. Build the project:
   ```bash
   dotnet build
   ```
7. Run the project:
   ```bash
   dotnet run
   ```

---

## **Usage**
1. Launch the application.
2. Register with your name and email address.
3. Start the quiz and answer the questions within the given time.
4. Upon quiz completion, your score will be displayed and sent to your registered email.

---

## **Future Enhancements**
- **AI Integration**: Automatically generate dynamic questions using AI models like OpenAI GPT.
- **Customizable Quiz Topics**: Allow users to select quiz topics.
- **Leaderboard**: Implement a leaderboard to display high scores.
- **Offline Mode**: Enable offline functionality with local data storage.
- **Improved Security**: Encrypt user credentials and quiz data.

---

## **Screenshots**
### **Registration Form**
_Description: User registration form with `joes.png` as the background._
![Registration Form](./screenshots/registration_form.png)

### **Quiz Form**
_Description: Quiz form with `apd.jpg` as the background._
![Quiz Form](./screenshots/quiz_form.png)

---

## **License**
This project is licensed under the [MIT License](LICENSE).

---

## **Acknowledgments**
- **SendGrid** for email integration.
- **OpenAI** for future AI enhancements.
- **Microsoft** for .NET framework and tooling.
