using GuranteedRate.Homework.Model;
using System.Collections.Generic;

namespace GuranteedRate.Homework.BusineesLogic.DataContract
{
    public interface IPersonRepository
    {
        int GetPersonRecordNum();
        ICollection<Person> GetPersonRecords();
        void AddPerson(Person person);
        //string[] GetFileNames(string folderPath);
        //string[] GetFileContent(string folderPath, string fileName);
        //void WriteFileContents(string folderPath, string fileName, string[] contents);
    }
}
