namespace GuranteedRate.Homework.BusineesLogic.DataContract
{
    public interface IFileRepository
    {
        int GetFileCount(string folderPath);
        string GetFileContent(string folderPath, string fileName);
        void WriteFileContent(string folderPath, string fileName);
    }
}
