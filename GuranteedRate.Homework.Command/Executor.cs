using GuranteedRate.Homework.BusineesLogic.Interfaces;
using System;

namespace GuranteedRate.Homework.Command
{
    public class Executor : IExecutor
    {
        private readonly IRecordBusinessLogic _recordBusinessLogic;

        public Executor(IRecordBusinessLogic recordBusinessLogic)
        {
            _recordBusinessLogic = recordBusinessLogic;
        }

        public void Execute()
        {
            _recordBusinessLogic.AddRecord($"added this record at {DateTime.Now}");
            var records = _recordBusinessLogic.GetRecords();

            foreach(var record in records)
            {
                Console.WriteLine(record);
            }
        }
    }
}
