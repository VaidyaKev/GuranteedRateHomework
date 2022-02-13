using GuranteedRate.Homework.Model;
using System.Collections.Generic;

namespace GuranteedRate.Homework.BusineesLogic.Interfaces
{
    public interface IRecordBusinessLogic
    {
        List<Person> GetRecords();
        void AddRecord(Person person);
        void AddRecord(string record);
    }
}
