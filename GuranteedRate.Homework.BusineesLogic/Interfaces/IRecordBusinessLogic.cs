using System.Collections.Generic;

namespace GuranteedRate.Homework.BusineesLogic.Interfaces
{
    public interface IRecordBusinessLogic
    {
        List<string> GetRecords();
        void AddRecord(string record);
    }
}
