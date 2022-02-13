using GuranteedRate.Homework.BusineesLogic.DataContract;
using GuranteedRate.Homework.Domain.Extensions;
using GuranteedRate.Homework.Model;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GuranteedRate.Homework.Repository
{
    public class PersonFileRepository : IPersonRepository
    {
        private const string FilePrefixName = "PersonRecord";
        private const string FileType = ".txt";
        private readonly string _folderPath;

        public PersonFileRepository()
        {
            _folderPath = Directory.GetCurrentDirectory();
        }

        public int GetPersonRecordNum()
        {
            return GetFileNames()
                   .Count(x => x.Contains(FilePrefixName));
        }

        public void AddPerson(Person person)
        {
            var fileCount = GetPersonRecordNum();
            WriteFileContents(_folderPath, $"{FilePrefixName}{++fileCount}", new string[] { person.ToStr() });
        }

        public IEnumerable<Person> GetPersonRecords()
        {
            List<string> records = new List<string>();
            foreach (var file in GetFileNames())
            {
                var fileInfo = new FileInfo(file);
                records.AddRange(GetFileContent(fileInfo.Directory.FullName, fileInfo.Name));
            }

            return records.Select(x => x.ToObj()).ToList();
        }

        private string[] GetFileNames()
        {
            return Directory.GetFiles(_folderPath, $"*{FileType}");
        }

        private string[] GetFileContent(string folderPath, string fileName)
        {
            var filePath = Path.Combine(folderPath, fileName);
            return File.ReadAllLines(filePath);
        }

        private void WriteFileContents(string folderPath, string fileName, string[] contents)
        {
            var filePath = Path.Combine(folderPath, $"{fileName}{FileType}");
            File.WriteAllLines(filePath, contents);
        }
    }
}
