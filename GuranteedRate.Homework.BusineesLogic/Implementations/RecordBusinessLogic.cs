using GuranteedRate.Homework.BusineesLogic.DataContract;
using GuranteedRate.Homework.BusineesLogic.Interfaces;
using GuranteedRate.Homework.Domain.Extensions;
using GuranteedRate.Homework.Model;
using System.Collections.Generic;

namespace GuranteedRate.Homework.BusineesLogic.Implementations
{
    public class RecordBusinessLogic : IRecordBusinessLogic
    {
        private readonly char[] _exceptedDelimiter;
        private readonly IPersonRepository _personRepo;

        public RecordBusinessLogic(IPersonRepository fileRepository)
        {
            _personRepo = fileRepository;
            _exceptedDelimiter = new char[] { ',', '|', ' ' };
        }

        public void AddRecord(string person)
        {
            var personObj = person.ToObj(_exceptedDelimiter);
            _personRepo.AddPerson(personObj);
        }

        public IEnumerable<Person> GetRecords()
        {
            return _personRepo.GetPersonRecords();
        }
    }
}
