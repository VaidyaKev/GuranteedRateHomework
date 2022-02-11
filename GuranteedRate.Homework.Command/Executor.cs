using GuranteedRate.Homework.BusineesLogic.DataContract;
using System;
using System.Collections.Generic;
using System.Text;

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
            Console.WriteLine(_recordBusinessLogic.GetRecord(""));
        }
    }
}
