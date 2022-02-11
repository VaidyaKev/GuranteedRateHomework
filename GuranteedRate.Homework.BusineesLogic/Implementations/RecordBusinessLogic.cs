using GuranteedRate.Homework.BusineesLogic.DataContract;
using GuranteedRate.Homework.BusineesLogic.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GuranteedRate.Homework.BusineesLogic.Implementations
{
    public class RecordBusinessLogic : IRecordBusinessLogic
    {
        private const string FilePrefixName = "PersonRecord";
        private readonly string _folderPath;
        private readonly IFileRepository _fileRepository;

        public RecordBusinessLogic(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
            _folderPath = Directory.GetCurrentDirectory();
        }

        public void AddRecord(string record)
        {
            var fileCount = GetFileNames()
                            .Count(x => x.Contains(FilePrefixName));
            _fileRepository.WriteFileContents(_folderPath, $"{FilePrefixName}{++fileCount}", new string[] {record});
        }

        public List<string> GetRecords()
        {
            List<string> records = new List<string>();
            foreach (var file in GetFileNames())
            {
                var fileInfo = new FileInfo(file);
                records.AddRange(_fileRepository.GetFileContent(fileInfo.Directory.FullName, fileInfo.Name));
            }

            return records;
        }

        private IEnumerable<string> GetFileNames()
        {
            return _fileRepository.GetFileNames(_folderPath)
                .Where(x => x.Contains(FilePrefixName));
        }
    }
}
