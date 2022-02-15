using GuranteedRate.Homework.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace GuranteedRate.Homework.Command.Tests
{
    public class SortHelperTests
    {
        private readonly SortHelper _sortHelper;

        public SortHelperTests()
        {
            _sortHelper = new SortHelper();
        }

        [Fact]
        public void SortByColorDescThenLNameAsc_ThrowsArgumentExceptionNull_Test()
        {
            Action action = () => _sortHelper.SortByColorDescThenLNameAsc(null);
            Verify_ThrowsArgumentException_Test(action);
        }
        [Fact]
        public void SortByColorDescThenLNameAsc_ThrowsArgumentExceptionEmpty_Test()
        {
            Action action = () => _sortHelper.SortByColorDescThenLNameAsc(new List<Person>());
            Verify_ThrowsArgumentException_Test(action);
        }
        [Fact]
        public void SortByColorDescThenLNameAsc_ExpectedOrderedList_Test()
        {
            var mockPersons = GetMockPersonList();
            var orderedList = _sortHelper.SortByColorDescThenLNameAsc(mockPersons);

            var expected = JsonConvert.SerializeObject(mockPersons.OrderByDescending(x => x.FavoriteColor).ThenBy(x => x.LastName));
            var actual = JsonConvert.SerializeObject(orderedList);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SortByDobAsc_ThrowsArgumentExceptionNull_Test()
        {
            Action action = () => _sortHelper.SortByDobAsc(null);
            Verify_ThrowsArgumentException_Test(action);
        }
        [Fact]
        public void SortByDobAsc_ThrowsArgumentExceptionEmpty_Test()
        {
            Action action = () => _sortHelper.SortByDobAsc(new List<Person>());
            Verify_ThrowsArgumentException_Test(action);
        }
        [Fact]
        public void SortByDobAsc_ExpectedOrderedList_Test()
        {
            var mockPersons = GetMockPersonList();
            var orderedList = _sortHelper.SortByDobAsc(mockPersons);

            var expected = JsonConvert.SerializeObject(mockPersons.OrderBy(x => x.DateOfBirth));
            var actual = JsonConvert.SerializeObject(orderedList);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SortByLNameDesc_ThrowsArgumentExceptionNull_Test()
        {
            Action action = () => _sortHelper.SortByLNameDesc(null);
            Verify_ThrowsArgumentException_Test(action);
        }
        [Fact]
        public void SortByLNameDesc_ThrowsArgumentExceptionEmpty_Test()
        {
            Action action = () => _sortHelper.SortByLNameDesc(new List<Person>());
            Verify_ThrowsArgumentException_Test(action);
        }
        [Fact]
        public void SortByLNameDesc_ExpectedOrderedList_Test()
        {
            var mockPersons = GetMockPersonList();
            var orderedList = _sortHelper.SortByLNameDesc(mockPersons);

            var expected = JsonConvert.SerializeObject(mockPersons.OrderByDescending(x => x.LastName));
            var actual = JsonConvert.SerializeObject(orderedList);

            Assert.Equal(expected, actual);
        }


        private void Verify_ThrowsArgumentException_Test(Action action)
        {
            var ex = Assert.Throws<ArgumentException>(() => action.Invoke());
            Assert.Equal("List Must Contain at Least One Item (Parameter 'persons')", ex.Message);
        }

        private ICollection<Person> GetMockPersonList()
        {
            return new List<Person>()
            {
                new Person()
                {
                    LastName = "Bugg",
                    FirstName = "Aida",
                    Email = "BuggAida@gmail.com",
                    FavoriteColor = "Green",
                    DateOfBirth = DateTime.Parse("2012/07/07")
                },
                new Person()
                {
                    LastName = "Tree",
                    FirstName = "Olive",
                    Email = "OliveTree@hotmail.com",
                    FavoriteColor = "White",
                    DateOfBirth = DateTime.Parse("2007/08/11")
                },
                new Person()
                {
                    LastName = "Scope",
                    FirstName = "Perry",
                    Email = "45Peryy@yahoo.com",
                    FavoriteColor = "Gray",
                    DateOfBirth = DateTime.Parse("1993/02/05")
                },
                new Person()
                {
                    LastName = "Legge",
                    FirstName = "Peg",
                    Email = "#pl@aol.com",
                    FavoriteColor = "Red",
                    DateOfBirth = DateTime.Parse("1993/06/05")
                },
                new Person()
                {
                    LastName = "Grater",
                    FirstName = "Allie",
                    Email = "AllieGrater@dell.com",
                    FavoriteColor = "Green",
                    DateOfBirth = DateTime.Parse("1995/06/08")
                },
            };
        }
    }
}
