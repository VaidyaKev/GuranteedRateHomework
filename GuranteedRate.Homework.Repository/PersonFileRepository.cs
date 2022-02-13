using GuranteedRate.Homework.BusineesLogic.DataContract;
using System.IO;

namespace GuranteedRate.Homework.Repository
{
    public class PersonFileRepository : IPersonRepository
    {
        private const string FileType = ".txt";

        public string[] GetFileNames(string folderPath)
        {
            return Directory.GetFiles(folderPath, $"*{FileType}");
        }

        public string[] GetFileContent(string folderPath, string fileName)
        {
            var filePath = Path.Combine(folderPath, fileName);
            return File.ReadAllLines(filePath);
        }

        public void WriteFileContents(string folderPath, string fileName, string[] contents)
        {
            var filePath = Path.Combine(folderPath, $"{fileName}{FileType}");
            File.WriteAllLines(filePath, contents);
        }
    }
}
