using System;
using System.Collections.Generic;

namespace Quiz
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Question> questions = QuizData.GetQuestions();
            int[] answers = new int[questions.Count];

            Console.WriteLine("Starting the Quiz!");

            foreach (var item in questions)
            {
                Console.WriteLine($"{Environment.NewLine}{item.Number}. {item.QuestionText}");

                foreach (var otion in item.Options)
                {
                    Console.WriteLine($"  {otion.Key}) {otion.Value}");
                }

                int number = 0;
                bool success = false;
                while (!success)
                {
                    Console.Write("Your answer: ");
                    string answer = Console.ReadLine();
                    int.TryParse(answer, out number);
                    success = Validate(number, item.Options);
                };
                answers[item.Number - 1] = number;

            }

            CountCorrectAnswers(answers, questions);
        }

        static bool Validate(int number, Dictionary<int, string> options)
        {
            if (!options.ContainsKey(number))
            {
                Console.WriteLine("Insert valid answer.");
                return false;
            }
            return true;

        }

        static void CountCorrectAnswers(int[] answers, List<Question> questions)
        {
            int count = 0;
            for (int i = 0; i < answers.Length; i++)
            {
                if (answers[i] == questions[i].CorrectAnswer)
                {
                    count++;
                }
            }
            DisplayScore(count);
        }

        private static void DisplayScore(int count)
        {
            Console.WriteLine($"{Environment.NewLine}You answered {count} questions correctly.");
        }
    }
}
