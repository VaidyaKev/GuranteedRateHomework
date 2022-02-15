using GuranteedRate.Homework.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GuranteedRate.Homework.Domain.Helpers
{
    public class SortHelper : ISortHelper
    {
        public ICollection<Person> SortByColorDescThenLNameAsc(ICollection<Person> persons)
        {
            VerifyListNotEmptyOrNull(persons);
            return persons
                .OrderByDescending(x => x.FavoriteColor)
                .ThenBy(x => x.LastName)
                .ToList();
        }

        public ICollection<Person> SortByDobAsc(ICollection<Person> persons)
        {
            VerifyListNotEmptyOrNull(persons);
            return persons
                .OrderBy(x => x.DateOfBirth)
                .ToList();
        }

        public ICollection<Person> SortByFavoriteColorAsc(ICollection<Person> persons)
        {
            VerifyListNotEmptyOrNull(persons);
            return persons
                .OrderBy(x => x.FavoriteColor)
                .ToList();
        }

        public ICollection<Person> SortByLNameAsc(ICollection<Person> persons)
        {
            VerifyListNotEmptyOrNull(persons);
            return persons
                .OrderBy(x => x.LastName)
                .ToList();
        }

        public ICollection<Person> SortByLNameDesc(ICollection<Person> persons)
        {
            VerifyListNotEmptyOrNull(persons);
            return persons
                .OrderByDescending(x => x.LastName)
                .ToList();
        }

        private void VerifyListNotEmptyOrNull(ICollection<Person> persons)
        {
            if (persons == null || !persons.Any())
            {
                throw new ArgumentException("List Must Contain at Least One Item", "persons");
            }
        }
    }
}
