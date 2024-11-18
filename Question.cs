namespace BasicQuizApplicationWithUI
{
    public class Question
    {
        public string Text { get; set; }
        public string[] Options { get; set; }
        public int CorrectOption { get; set; }

        public Question(string text, string[] options, int correctOption)
        {
            Text = text;
            Options = options;
            CorrectOption = correctOption;
        }

        public bool CheckAnswer(int userAnswer)
        {
            return userAnswer == CorrectOption;
        }
    }
}
