using ConsoleTables;
using GuranteedRate.Homework.BusineesLogic.Interfaces;
using GuranteedRate.Homework.Domain.Extensions;
using GuranteedRate.Homework.Model;
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
            var person = new Person()
            {
                FirstName = "Joe",
                LastName = "Doe",
                Email = "JoeDoe@Domain.com",
                DateOfBirth = DateTime.Now,
                FavoriteColor = "Blue"
            };

            _recordBusinessLogic.AddRecord(person);
            var records = _recordBusinessLogic.GetRecords();

            var table = new ConsoleTable("FirstName", "LastName", "Email", "DOB", "FavoriteColor");
            foreach(var record in records)
            {
                table.AddRow(record.FirstName, record.LastName, record.Email, record.DateOfBirth.ToString("d"), record.FavoriteColor);
            }

            table.Write();
        }
    }
}
