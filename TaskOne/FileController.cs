using System;
using System.IO;

namespace TaskOne
{
    public class FileController
    {
        const string fileExtension = ".txt";
        readonly string rootDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        
        public string ChooseFolder(string directoryName)
        {
            string createdDirectory = Path.Combine(rootDirectory, directoryName);
            if (Directory.Exists(createdDirectory))
            {
                return createdDirectory;
            }
            else
            {
                return CreateFolder(createdDirectory);
            }
        }

        public string ChooseFile(string fileName, string directoryPath)
        {
            string filePath = Path.Combine(directoryPath, $"{fileName}{fileExtension}");
            if (File.Exists(filePath))
            {
                return filePath;
            }
            else
            {
                return CreateFile(filePath);
            }
        }

        public void WriteDataToTextFile(string path, MyList<string> data)
        {
            File.AppendAllLines(path, data);
        }

        private string CreateFolder(string directoryPath)
        {
            var dir = Directory.CreateDirectory(directoryPath);
            if (dir.Exists)
                return dir.FullName;
            else
                return null;

        }

        private string CreateFile(string filePath)
        {
            using (File.Create(filePath))
            {
                return filePath;
            }
        }
    }
}