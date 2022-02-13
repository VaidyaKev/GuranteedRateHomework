using GuranteedRate.Homework.BusineesLogic.DataContract;
using GuranteedRate.Homework.Model;
using System;
using System.Collections.Generic;

namespace GuranteedRate.Homework.DI
{
    public class RecordHelper
    {
        public readonly IPersonRepository _personRepository;

        public RecordHelper(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
            CreateBasicPersonRecord();
        }

        public void CreateBasicPersonRecord()
        {
            var persons = new List<Person>()
            {
                new Person()
                {
                    LastName = "Bugg",
                    FirstName = "Aida",
                    Email = "BuggAida@gmail.com",
                    FavoriteColor = "Brown",
                    DateOfBirth = DateTime.Parse("2012/07/07")
                },
                new Person()
                {
                    LastName = "Tree",
                    FirstName = "Olive",
                    Email = "OliveTree@hotmail.com",
                    FavoriteColor = "Brown",
                    DateOfBirth = DateTime.Parse("2007/08/11")
                },
                new Person()
                {
                    LastName = "Scope",
                    FirstName = "Perry",
                    Email = "45Peryy@yahoo.com",
                    FavoriteColor = "Brown",
                    DateOfBirth = DateTime.Parse("1993/02/05")
                }
            };

            foreach(var person in persons)
            {
                _personRepository.AddPerson(person);
            }
        }
    }
}
