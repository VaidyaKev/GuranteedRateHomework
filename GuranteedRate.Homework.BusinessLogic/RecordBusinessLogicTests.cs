using GuranteedRate.Homework.BusineesLogic.DataContract;
using GuranteedRate.Homework.BusineesLogic.Implementations;
using GuranteedRate.Homework.Model;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace GuranteedRate.Homework.BusinessLogic
{
    public class RecordBusinessLogicTests
    {
        private static string MockPersonStr => "UnitTest, Mock, UnitTest@Moq.com, MockColor, 12/07/2021";
        private readonly Mock<IPersonRepository> _personRepositoryMock;
        private readonly RecordBusinessLogic _recordBusinessLogic;

        public RecordBusinessLogicTests()
        {
            _personRepositoryMock = new Mock<IPersonRepository>();
            _recordBusinessLogic = new RecordBusinessLogic(_personRepositoryMock.Object);
        }

        [Fact]
        public void AddRecord_DoesNotThrow_Test()
        {
            var ex = Record.Exception(() => _recordBusinessLogic.AddPerson(MockPersonStr));
        }

        [Fact]
        public void AddRecord_EmptyStr_Test()
        {
            var ex = Assert.Throws<ArgumentException>(() => _recordBusinessLogic.AddPerson(string.Empty));
            Assert.Equal("Must Have Value (Parameter 'person')", ex.Message);
        }

        [Fact]
        public void AddRecord_NullStr_Test()
        {
            var ex = Assert.Throws<ArgumentException>(() => _recordBusinessLogic.AddPerson(null));
            Assert.Equal("Must Have Value (Parameter 'person')", ex.Message);
        }


        [Fact]
        public void AddRecord_ArgumentNullExcpetion_Test()
        {
            _personRepositoryMock.Setup(x => x.AddPerson(It.IsAny<Person>())).Throws(new ArgumentNullException("mockParam", "Mock Excpetion"));
            var ex = Assert.Throws<ArgumentNullException>(() => _recordBusinessLogic.AddPerson(MockPersonStr));
            Assert.Equal("Mock Excpetion (Parameter 'mockParam')", ex.Message);
            _personRepositoryMock.Verify(x => x.AddPerson(It.IsAny<Person>()), Times.Once);
        }

        [Fact]
        public void GetRecords_ExpectList_Test()
        {
            var mockList = new List<Person>() { GetMockPerson(), GetMockPerson() };
            _personRepositoryMock.Setup(x => x.GetPersonRecords()).Returns(mockList);
            var persons = _recordBusinessLogic.GetPersons();
            Assert.Equal(2, persons.Count);
            _personRepositoryMock.Verify(x => x.GetPersonRecords(), Times.Once);
        }

        [Fact]
        public void GetRecords_ThrowsException_Test()
        {
            _personRepositoryMock.Setup(x => x.GetPersonRecords()).Throws(new Exception("Generic Mock Exception"));
            var ex = Assert.Throws<Exception>(() => _recordBusinessLogic.GetPersons());
            Assert.Equal("Generic Mock Exception", ex.Message);
            _personRepositoryMock.Verify(x => x.GetPersonRecords(), Times.Once);
        }

        private Person GetMockPerson()
        {
            return new Person()
            {
                LastName = "UnitTest",
                FirstName = "Mock",
                Email = "UnitTest@Moq.com",
                FavoriteColor = "MockColor",
                DateOfBirth = new DateTime(2021, 12, 07)
            };
        }
    }
}
