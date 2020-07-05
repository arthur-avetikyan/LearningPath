using System;

namespace TaskOne
{
    public enum InputMethod
    {
        Group = 1,
        Individual = 2
    }


    public static class InputHelper
    {
        public static void AddNumbersByGroup(MyList<string> inputedList)
        {
            Console.WriteLine($"Please input numbers separated with comma (',') in order to save them in the text file.");
            string[] input = Console.ReadLine().Split(',');

            for (int i = 0; i < input.Length; i++)
            {
                if (!int.TryParse(input[i], out _))
                {
                    Console.WriteLine($"Inputed symbols contain non-numeric charaters.");
                    AddNumbersByGroup(inputedList);
                }
            }
            inputedList.AddRange(input);
        }

        public static void AddNumbersIdividually(MyList<string> inputedList)
        {
            bool inputMode;
            int counter;

            Console.WriteLine("Please input total count of numbers that you want to save.");
            do
            {
                inputMode = int.TryParse(Console.ReadLine(), out counter);
            }
            while (!inputMode);

            Console.WriteLine($"Please input {counter} numbers in order to save them in the text file.");

            while (counter > 0)
            {
                string input = Console.ReadLine();

                if (int.TryParse(input, out _))
                {
                    inputedList.Add(input);
                }
                counter--;
            }
        }

        public static bool ChooseInputMethod(ref InputMethod inputMethod)
        {
            bool success;
            try
            {
                Console.WriteLine($"Choose input method: {Environment.NewLine} Group -> 1 {Environment.NewLine} Individual -> 2");
                var method = int.Parse(Console.ReadLine());

                if (Enum.IsDefined(typeof(InputMethod), method))
                {
                    inputMethod = (InputMethod)method;
                    success = true;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                success = false;
            }
            return success;
        }
    }
}

