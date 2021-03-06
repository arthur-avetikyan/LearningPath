﻿using System.Collections.Generic;

namespace Quiz
{
    public static class QuizData
    {
        public static List<Question> GetQuestions() => new List<Question>
            {
                new Question
                {
                    Number = 1,
                    QuestionText = "Which is Earth's highest mountian?",
                    Options = new Dictionary<int, string>()
                    {
                        {1,"Ararat" },
                        {2,"Everest" },
                        {3,"Manaslu" },
                        {4,"Karjiang" },
                    }
                },
                new Question
                {
                    Number = 2,
                    QuestionText = "Which is the capital of France?",
                    Options = new Dictionary<int, string>()
                    {
                        {1,"Kiev" },
                        {2,"Riga" },
                        {3,"Berlin" },
                        {4,"Paris" },
                    }
                },
                new Question
                {
                    Number = 3,
                    QuestionText = "Which is Earth's largest lake?",
                    Options = new Dictionary<int, string>()
                    {
                        {1,"Caspian" },
                        {2,"Baikal" },
                        {3,"Sevan" },
                        {4,"Michigan" },
                    }
                },
                new Question
                {
                    Number = 4,
                    QuestionText = "Which is country won the 2006 FIFA World Cup?",
                    Options = new Dictionary<int, string>()
                    {
                        {1,"Germany" },
                        {2,"Brazil" },
                        {3,"Greece" },
                        {4,"Italy" },
                    }
                },

            };

        public static Dictionary<int, int> GetCorrectAnswers() =>
            new Dictionary<int, int>
            {
                {1,2 },
                {2,4 },
                {3,1 },
                {4,4 },
            };
    }
}
