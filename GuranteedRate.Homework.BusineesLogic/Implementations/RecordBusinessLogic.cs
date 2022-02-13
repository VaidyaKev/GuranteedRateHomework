﻿using GuranteedRate.Homework.BusineesLogic.DataContract;
using GuranteedRate.Homework.BusineesLogic.Interfaces;
using GuranteedRate.Homework.Domain.Extensions;
using GuranteedRate.Homework.Model;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GuranteedRate.Homework.BusineesLogic.Implementations
{
    public class RecordBusinessLogic : IRecordBusinessLogic
    {
        private const string FilePrefixName = "PersonRecord";
        private readonly char[] _exceptedDelimiter;
        private readonly string _folderPath;
        private readonly IPersonRepository _fileRepository;

        public RecordBusinessLogic(IPersonRepository fileRepository)
        {
            _fileRepository = fileRepository;
            _folderPath = Directory.GetCurrentDirectory();
            _exceptedDelimiter = new char[] { ',', '|', ' ' };
        }

        public void AddRecord(Person person)
        {
            var fileCount = GetFileNames()
                            .Count(x => x.Contains(FilePrefixName));
            _fileRepository.WriteFileContents(_folderPath, $"{FilePrefixName}{++fileCount}", new string[] { person.ToStr()});
        }

        public void AddRecord(string record)
        {
            var person = record.ToObj(_exceptedDelimiter);
            AddRecord(person);
        }

        public List<Person> GetRecords()
        {
            List<string> records = new List<string>();
            foreach (var file in GetFileNames())
            {
                var fileInfo = new FileInfo(file);
                records.AddRange(_fileRepository.GetFileContent(fileInfo.Directory.FullName, fileInfo.Name));
            }

            return records.Select(x => x.ToObj()).ToList();
        }

        private IEnumerable<string> GetFileNames()
        {
            return _fileRepository.GetFileNames(_folderPath)
                .Where(x => x.Contains(FilePrefixName));
        }
    }
}
