using GuranteedRate.Homework.API.Controllers.V1;
using GuranteedRate.Homework.BusineesLogic.Interfaces;
using GuranteedRate.Homework.Domain.Helpers;
using GuranteedRate.Homework.Model;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace GuranteedRate.Homework.API.Test.Controllers.V1
{
    public class RecordsControllerTests
    {
        private readonly Mock<IRecordBusinessLogic> _recordBusinessLogicMock;
        private readonly Mock<ISortHelper> _sortHelperMock;
        private readonly RecordsController _recordsController;

        public RecordsControllerTests()
        {
            _recordBusinessLogicMock = new Mock<IRecordBusinessLogic>();
            _sortHelperMock = new Mock<ISortHelper>();
            _recordsController = new RecordsController(_recordBusinessLogicMock.Object, _sortHelperMock.Object);
        }

        [Fact]
        public void GetBySortedFavoriteColor_ReturnOKList_Test()
        {
            _sortHelperMock.Setup(x => x.SortByFavoriteColorAsc(It.IsAny<ICollection<Person>>())).Returns(new List<Person>());
            GetBySortedList_ReturnOKList_Test(_recordsController.GetBySortedFavoriteColor);
            _sortHelperMock.Verify(x => x.SortByFavoriteColorAsc(It.IsAny<ICollection<Person>>()), Times.Once);
        }
        [Fact]
        public void GetBySortedFavoriteColor_ReturnNotFound_Test()
        {
            _sortHelperMock.Setup(x => x.SortByFavoriteColorAsc(It.IsAny<ICollection<Person>>())).Returns(new List<Person>());
            GetBySortedList_ReturnNotFound_Test(_recordsController.GetBySortedFavoriteColor);
            _sortHelperMock.Verify(x => x.SortByFavoriteColorAsc(It.IsAny<ICollection<Person>>()), Times.Never);
        }
        [Fact]
        public void GetBySortedFavoriteColor_ArgumentException_Test()
        {
            _sortHelperMock.Setup(x => x.SortByFavoriteColorAsc(It.IsAny<ICollection<Person>>())).Returns(new List<Person>());
            GetBySortedList_ArgumentException_Test(_recordsController.GetBySortedFavoriteColor);
            _sortHelperMock.Verify(x => x.SortByFavoriteColorAsc(It.IsAny<ICollection<Person>>()), Times.Never);
        }

        [Fact]
        public void GetBySortedBirthday_ReturnOKList_Test()
        {
            _sortHelperMock.Setup(x => x.SortByDobAsc(It.IsAny<ICollection<Person>>())).Returns(new List<Person>());
            GetBySortedList_ReturnOKList_Test(_recordsController.GetBySortedBirthday);
            _sortHelperMock.Verify(x => x.SortByDobAsc(It.IsAny<ICollection<Person>>()), Times.Once);
        }
        [Fact]
        public void GetBySortedBirthday_ReturnNotFound_Test()
        {
            _sortHelperMock.Setup(x => x.SortByDobAsc(It.IsAny<ICollection<Person>>())).Returns(new List<Person>());
            GetBySortedList_ReturnNotFound_Test(_recordsController.GetBySortedBirthday);
            _sortHelperMock.Verify(x => x.SortByDobAsc(It.IsAny<ICollection<Person>>()), Times.Never);
        }
        [Fact]
        public void GetBySortedBirthday_ArgumentException_Test()
        {
            _sortHelperMock.Setup(x => x.SortByDobAsc(It.IsAny<ICollection<Person>>())).Returns(new List<Person>());
            GetBySortedList_ArgumentException_Test(_recordsController.GetBySortedBirthday);
            _sortHelperMock.Verify(x => x.SortByDobAsc(It.IsAny<ICollection<Person>>()), Times.Never);
        }

        [Fact]
        public void GetBySortedLastName_ReturnOKList_Test()
        {
            _sortHelperMock.Setup(x => x.SortByLNameAsc(It.IsAny<ICollection<Person>>())).Returns(new List<Person>());
            GetBySortedList_ReturnOKList_Test(_recordsController.GetBySortedLastName);
            _sortHelperMock.Verify(x => x.SortByLNameAsc(It.IsAny<ICollection<Person>>()), Times.Once);
        }
        [Fact]
        public void GetBySortedLastName_ReturnNotFound_Test()
        {
            _sortHelperMock.Setup(x => x.SortByLNameAsc(It.IsAny<ICollection<Person>>())).Returns(new List<Person>());
            GetBySortedList_ReturnNotFound_Test(_recordsController.GetBySortedLastName);
            _sortHelperMock.Verify(x => x.SortByLNameAsc(It.IsAny<ICollection<Person>>()), Times.Never);
        }
        [Fact]
        public void GetBySortedLastName_ArgumentException_Test()
        {
            _sortHelperMock.Setup(x => x.SortByLNameAsc(It.IsAny<ICollection<Person>>())).Returns(new List<Person>());
            GetBySortedList_ArgumentException_Test(_recordsController.GetBySortedLastName);
            _sortHelperMock.Verify(x => x.SortByLNameAsc(It.IsAny<ICollection<Person>>()), Times.Never);
        }

        private void GetBySortedList_ReturnOKList_Test(Func<IActionResult> func)
        {
            _recordBusinessLogicMock.Setup(x => x.GetPersons()).Returns(new List<Person>());

            var actual = func();
            Assert.IsType<OkObjectResult>(actual);

            _recordBusinessLogicMock.Verify(x => x.GetPersons(), Times.Once);
        }

        private void GetBySortedList_ReturnNotFound_Test(Func<IActionResult> func)
        {
            ICollection<Person> persons = null;
            _recordBusinessLogicMock.Setup(x => x.GetPersons()).Returns(persons);

            var actual = func();
            Assert.IsType<NotFoundResult>(actual);

            _recordBusinessLogicMock.Verify(x => x.GetPersons(), Times.Once);
        }

        private void GetBySortedList_ArgumentException_Test(Func<IActionResult> func)
        {
            ICollection<Person> persons = null;
            _recordBusinessLogicMock.Setup(x => x.GetPersons()).Throws(new ArgumentException("Mock Exception"));
            

            var actual = func();
            Assert.IsType<ObjectResult>(actual);
            Assert.Equal(500, (actual as ObjectResult).StatusCode);

            _recordBusinessLogicMock.Verify(x => x.GetPersons(), Times.Once);
        }
    }
}
