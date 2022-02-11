using GuranteedRate.Homework.BusineesLogic.DataContract;
using System;

namespace GuranteedRate.Homework.BusineesLogic.Implementations
{
    public class RecordBusinessLogic : IRecordBusinessLogic
    {
        private readonly IFileRepository _fileRepository;

        public RecordBusinessLogic(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public string GetRecord(string id)
        {
           return  _fileRepository.GetFileContent("", "");
        }
    }
}
