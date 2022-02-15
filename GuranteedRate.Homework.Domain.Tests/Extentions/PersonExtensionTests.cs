using GuranteedRate.Homework.Domain.Extensions;
using GuranteedRate.Homework.Model;
using Newtonsoft.Json;
using System;
using Xunit;

namespace GuranteedRate.Homework.Domain.Tests.Extentions
{
    public class PersonExtensionTests
    {
        [Fact]
        public void ToStr_DoesNotThrow_Test()
        {
            var ex = Record.Exception(() => GetMockPerson().ToStr());
            Assert.Null(ex);
        }

        [Fact]
        public void ToStr_ObjNullRef_Test()
        {
            Person person = null;
            var ex = Assert.Throws<NullReferenceException>(() => person.ToStr());
            Assert.Equal("Object reference not set to an instance of an object.", ex.Message);
        }

        [Fact]
        public void ToObj_CommaSeperatedString_Test()
        {
            var actualPerson = MockPersonStr.ToObj();

            var actual = JsonConvert.SerializeObject(actualPerson);
            var expected = JsonConvert.SerializeObject(GetMockPerson());

            Assert.Equal(expected, actual); ;
        }

        [Fact]
        public void ToObj_NotDelimeterSeperatedString_Test()
        {
            string personStr = MockPersonStr.Replace(',', '/');
            var ex = Assert.Throws<ArgumentException>(() => personStr.ToObj());
            Assert.Equal("Must Contain at Least One Delimeters", ex.Message);
        }

        [Theory]
        [InlineData('|')]
        [InlineData(',')]
        [InlineData(' ')]
        public void ToObj_AnyDelimeterSeperateString_Test(char delimeter)
        {
            var mockPersonStr = MockPersonStr.Replace(',', delimeter);

            var actual = JsonConvert.SerializeObject(mockPersonStr.ToObj());
            var expected = JsonConvert.SerializeObject(GetMockPerson());

            Assert.Equal(expected, actual);
        }

        private static string MockPersonStr => "UnitTest,Mock,UnitTest@Moq.com,MockColor,12/07/2021";

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
