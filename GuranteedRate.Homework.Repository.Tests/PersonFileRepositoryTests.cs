using GuranteedRate.Homework.Model;
using Newtonsoft.Json;
using System;
using System.Linq;
using Xunit;

namespace GuranteedRate.Homework.Repository.Tests
{
    public class PersonFileRepositoryTests
    {
        private readonly PersonFileRepository _personFileRepository;


        public PersonFileRepositoryTests()
        {
            _personFileRepository = new PersonFileRepository();
        }

        [Fact]
        public void GetPersonRecordNum_ReturnsInt_Test()
        {
            var num = _personFileRepository.GetPersonRecordNum();
            Assert.True(num >= 0);
        }

        [Fact]
        public void AddPerson_DoesNotThrow_Test()
        {
            var excpetion = Record.Exception(() => _personFileRepository.AddPerson(GetMockPerson()));
            Assert.Null(excpetion);
        }

        [Fact]
        public void AddPerson_NullExcpeton_Test()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => _personFileRepository.AddPerson(null));
            Assert.Equal("Can Not be Null (Parameter 'Person')", ex.Message);
        }

        [Fact]
        public void GetPersonRecord_DoesNotThrow_Test()
        {
            var excpetion = Record.Exception(() => _personFileRepository.GetPersonRecords());
            Assert.Null(excpetion);
        }

        [Fact]
        public void GetPersonRecord_ReturnsNotNullList_Test()
        {
            var personRecords = _personFileRepository.GetPersonRecords();
            Assert.NotNull(personRecords);
        }

        [Fact]
        public void GetPersonRecord_ReturnsList_Test()
        {
            var mockPerson = GetMockPerson();
            _personFileRepository.AddPerson(mockPerson);

            var personRecords = _personFileRepository.GetPersonRecords();
            Assert.True(personRecords.Count >= 1);

            var actualPerson = personRecords.Where(x => x.FirstName == "Mock").FirstOrDefault();

            var expected = JsonConvert.SerializeObject(mockPerson);
            var actual = JsonConvert.SerializeObject(actualPerson);
            Assert.Equal(expected, actual);

        }

        private Person GetMockPerson()
        {
            return new Person()
            {
                FirstName = "Mock",
                LastName = "UnitTest",
                Email = "UnitTest@Moq.com",
                DateOfBirth = new DateTime(2021, 12, 07),
                FavoriteColor = "MockColor"
            };
        }
    }
}
