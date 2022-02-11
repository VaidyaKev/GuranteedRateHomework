using GuranteedRate.Homework.BusineesLogic.DataContract;
using System;

namespace GuranteedRate.Homework.Repository
{
    public class FileRepository : IFileRepository
    {
        public string GetFileContent(string folderPath, string fileName)
        {
            return "DI works";
        }

        public int GetFileCount(string folderPath)
        {
            throw new NotImplementedException();
        }

        public void WriteFileContent(string folderPath, string fileName)
        {
            throw new NotImplementedException();
        }
    }
}
