using GuranteedRate.Homework.Domain.Extensions;
using GuranteedRate.Homework.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
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
            var actualPerson = GetMockPersonStr().ToObj();

            var actual = JsonConvert.SerializeObject(actualPerson);
            var expected = JsonConvert.SerializeObject(GetMockPerson());

            Assert.Equal(expected, actual); ;
        }

        [Fact]
        public void ToObj_NotCommaSeperatedString_Test()
        {
            string personStr = GetMockPersonStr().Replace(',', '/');
            var ex = Assert.Throws<ArgumentException>(() => personStr.ToObj());
            Assert.Equal("Must be Comma Seperated Value", ex.Message);
        }

        [Theory]
        [InlineData('|')]
        [InlineData(',')]
        [InlineData('^')]
        public void ToObj_AnyDelimeterSeperateString_Test(char delimeter)
        {
            var mockPersonStr = GetMockPersonStr().Replace(',', delimeter);

            var actual = JsonConvert.SerializeObject(mockPersonStr.ToObj(new char[] { '+', '-', '*', delimeter }));
            var expected = JsonConvert.SerializeObject(GetMockPerson());

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToObj_NoDelimeterSeperateString_Test()
        {
            var mockPersonStr = GetMockPersonStr();

            var ex = Assert.Throws<ArgumentException>(() => mockPersonStr.ToObj(new char[0]));
            Assert.Equal("Must Have at Least One Delimeters (Parameter 'delimeters')", ex.Message);
        }

        [Fact]
        public void ToObj_NullDelimeterSeperateString_Test()
        {
            var mockPersonStr = GetMockPersonStr();

            var ex = Assert.Throws<ArgumentException>(() => mockPersonStr.ToObj(null));
            Assert.Equal("Must Have at Least One Delimeters (Parameter 'delimeters')", ex.Message);
        }

        private static string GetMockPersonStr()
        {
            return "UnitTest, Mock, UnitTest@Moq.com, MockColor, 12/07/2021";
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
