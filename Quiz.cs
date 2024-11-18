using System;
using System.Collections.Generic;

namespace BasicQuizApplicationWithUI
{
    public class Quiz
    {
        private List<Question> _questions;
        private int _currentQuestionIndex;
        public int Score { get; private set; }

        public Quiz()
        {
            _questions = new List<Question>();
            _currentQuestionIndex = 0;
            Score = 0;
            LoadQuestions();
            ShuffleQuestions();
        }

        private void LoadQuestions()
        {
            _questions.Add(new Question("What is the capital of France?", new[] { "Berlin", "Madrid", "Paris", "Rome" }, 2));
            _questions.Add(new Question("Which planet is known as the Red Planet?", new[] { "Earth", "Mars", "Jupiter", "Venus" }, 1));
            _questions.Add(new Question("What is the largest ocean?", new[] { "Atlantic", "Indian", "Pacific", "Arctic" }, 2));
            _questions.Add(new Question("Who developed the theory of relativity?", new[] { "Newton", "Einstein", "Galileo", "Bohr" }, 1));
            _questions.Add(new Question("Language used to develop Unity applications?", new[] { "Python", "Java", "C#", "Ruby" }, 2));
            _questions.Add(new Question("Which country is the Land of the Rising Sun?", new[] { "China", "Japan", "South Korea", "Thailand" }, 1));
            _questions.Add(new Question("What is the powerhouse of the cell?", new[] { "Nucleus", "Mitochondria", "Ribosome", "Chloroplast" }, 1));
            _questions.Add(new Question("What is the chemical symbol for water?", new[] { "H2O", "O2", "CO2", "NaCl" }, 0));
            _questions.Add(new Question("Language of the web'?", new[] { "C++", "Java", "JavaScript", "Python" }, 2));
            _questions.Add(new Question("Who painted the Mona Lisa?", new[] { "Vincent van Gogh", "Pablo Picasso", "Leonardo da Vinci", "Claude Monet" }, 2));
            // Add more questions here if you want
        }

        private void ShuffleQuestions()
        {
            Random random = new Random();
            for (int i = _questions.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                (_questions[i], _questions[j]) = (_questions[j], _questions[i]);
            }
        }

        public Question GetNextQuestion()
        {
            if (_currentQuestionIndex < _questions.Count)
                return _questions[_currentQuestionIndex++];
            return null;
        }

        public void CheckAnswer(int selectedOption)
        {
            if (_currentQuestionIndex > 0)
            {
                var currentQuestion = _questions[_currentQuestionIndex - 1];
                if (currentQuestion.CheckAnswer(selectedOption))
                    Score++;
            }
        }

        public int GetQuestionCount() => _questions.Count;
    }
}
