using System.Collections.Generic;

namespace GuranteedRate.Homework.BusineesLogic.DataContract
{
    public interface IFileRepository
    {
        string[] GetFileName(string folderPath);
        string[] GetFileContent(string folderPath, string fileName);
        void WriteFileContents(string folderPath, string fileName, string[] contents);
    }
}
