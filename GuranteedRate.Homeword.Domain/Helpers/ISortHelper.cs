using GuranteedRate.Homework.Model;
using System.Collections.Generic;

namespace GuranteedRate.Homework.Domain.Helpers
{
    public interface ISortHelper
    {
        public ICollection<Person> SortByColorDescThenLNameAsc(ICollection<Person> persons);
        public ICollection<Person> SortByDobAsc(ICollection<Person> persons);
        public ICollection<Person> SortByLNameDesc(ICollection<Person> persons);
        public ICollection<Person> SortByLNameAsc(ICollection<Person> persons);
        public ICollection<Person> SortByFavoriteColorAsc(ICollection<Person> persons);
    }
}
