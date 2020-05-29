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
                bool success = true;
                while (success)
                {
                    Console.Write("Your answer: ");
                    string answer = Console.ReadLine();
                    int.TryParse(answer, out number);
                    success = Validate(number, item.Options);
                };
                answers[item.Number - 1] = number;

            }

            DisplayCorrectAnswersCount(answers);
        }

        static bool Validate(int number, Dictionary<int, string> options)
        {
            if (!options.ContainsKey(number))
            {
                Console.WriteLine("Insert valid answer.");
                return true;
            }
            else
            {
                return false;
            }
        }

        static void DisplayCorrectAnswersCount(int[] answers)
        {
            int count = 0;
            var correctAnswers = QuizData.GetCorrectAnswers();
            for (int i = 0; i < answers.Length; i++)
            {
                if (answers[i] == correctAnswers[i + 1])
                {
                    count++;
                }
            }

            Console.WriteLine($"{Environment.NewLine}You answered {count} questions correctly.");
        }
    }
}
