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
        private readonly IPersonRepository _personRepo;

        public RecordBusinessLogic(IPersonRepository fileRepository)
        {
            _personRepo = fileRepository;
        }

        public ICollection<Person> GetPersons()
        {
            return _personRepo.GetPersonRecords();
        }

        public void AddPerson(string person)
        {
            if(person == null || person == string.Empty)
            {
                throw new ArgumentException("Must Have Value", "person");
            }

            var personObj = person.ToObj();
            _personRepo.AddPerson(personObj);
        }
    }
}
