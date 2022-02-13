using GuranteedRate.Homework.BusineesLogic.DataContract;
using GuranteedRate.Homework.BusineesLogic.Interfaces;
using GuranteedRate.Homework.Domain.Extensions;
using GuranteedRate.Homework.Model;
using System;
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
            _exceptedDelimiter = new char[] { ',', '|' };
        }

        public ICollection<Person> GetRecords()
        {
            return _personRepo.GetPersonRecords();
        }

        public void AddRecord(string person)
        {
            if(person == null || person == string.Empty)
            {
                throw new ArgumentException("Must Have Value", "person");
            }

            if (person.IndexOfAny(_exceptedDelimiter) == -1)
            {
                person.Replace(' ', ',');
            }

            var personObj = person.ToObj(_exceptedDelimiter);
            _personRepo.AddPerson(personObj);
        }
    }
}
