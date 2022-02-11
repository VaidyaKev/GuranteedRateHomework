using GuranteedRate.Homework.BusineesLogic.DataContract;
using System.IO;

namespace GuranteedRate.Homework.Repository
{
    public class FileRepository : IFileRepository
    {
        private const string FileType = ".txt";

        public string[] GetFileName(string folderPath)
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
            var filePath = Path.Combine(folderPath, fileName);
            File.WriteAllLines(filePath, contents);
        }
    }
}
