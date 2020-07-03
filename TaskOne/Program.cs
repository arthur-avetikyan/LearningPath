using System;

namespace TaskOne
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<string> inputedList = new MyList<string>();
            InputMethod inputMethod = InputMethod.Group;

            Console.WriteLine("Hello User");
            bool success = false;
            while (!success)
            {
                success = InputHelper.ChooseInputMethod(ref inputMethod);
            }

            switch (inputMethod)
            {
                case InputMethod.Group:
                    InputHelper.AddNumbersByGroup(inputedList);
                    break;
                case InputMethod.Individual:
                    InputHelper.AddNumbersIdividually(inputedList);
                    break;
                default:
                    break;
            }

            FileController fileController = new FileController();

            Console.WriteLine($"{Environment.NewLine}Please select folder: ");
            string choosenDirectoryName = Console.ReadLine();
            string currentDirectory = fileController.ChooseFolder(choosenDirectoryName);

            Console.WriteLine($"{Environment.NewLine}Please select file: ");
            string choosenFileName = Console.ReadLine();
            string currentFile = fileController.ChooseFile(choosenFileName, currentDirectory);

            inputedList.SortByAscending();
            fileController.WriteDataToTextFile(currentFile, inputedList);

            Console.WriteLine($"{Environment.NewLine} Success! Your file is saved in {currentFile}");
            Console.ReadLine();
        }
    }
}
