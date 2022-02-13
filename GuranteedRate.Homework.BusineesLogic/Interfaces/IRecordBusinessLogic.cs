using GuranteedRate.Homework.Model;
using System.Collections.Generic;

namespace GuranteedRate.Homework.BusineesLogic.Interfaces
{
    public interface IRecordBusinessLogic
    {
        IEnumerable<Person> GetRecords();
        void AddRecord(string person);
    }
}
