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
            _recordBusinessLogicMock.Setup(x => x.GetPersons()).Returns(new List<Person>());
            _sortHelperMock.Setup(x => x.SortByFavoriteColorAsc(It.IsAny<ICollection<Person>>())).Returns(new List<Person>());

            var actual = _recordsController.GetBySortedFavoriteColor();
            Assert.IsType<OkObjectResult>(actual);

            _recordBusinessLogicMock.Verify(x => x.GetPersons(), Times.Once);
            _sortHelperMock.Verify(x => x.SortByFavoriteColorAsc(It.IsAny<ICollection<Person>>()), Times.Once);
        }

        [Fact]
        public void GetBySortedFavoriteColor_ReturnNotFound_Test()
        {
            ICollection<Person> persons = null;
            _recordBusinessLogicMock.Setup(x => x.GetPersons()).Returns(persons);
            _sortHelperMock.Setup(x => x.SortByFavoriteColorAsc(It.IsAny<ICollection<Person>>())).Returns(new List<Person>());

            var actual = _recordsController.GetBySortedFavoriteColor();
            Assert.IsType<NotFoundResult>(actual);

            _recordBusinessLogicMock.Verify(x => x.GetPersons(), Times.Once);
            _sortHelperMock.Verify(x => x.SortByFavoriteColorAsc(It.IsAny<ICollection<Person>>()), Times.Never);
        }

        [Fact]
        public void GetBySortedFavoriteColor_ArgumentException_Test()
        {
            ICollection<Person> persons = null;
            _recordBusinessLogicMock.Setup(x => x.GetPersons()).Throws(new ArgumentException("Mock Exception"));
            _sortHelperMock.Setup(x => x.SortByFavoriteColorAsc(It.IsAny<ICollection<Person>>())).Returns(new List<Person>());

            var actual = _recordsController.GetBySortedFavoriteColor();
            Assert.IsType<ObjectResult>(actual);
            Assert.Equal(500, (actual as ObjectResult).StatusCode);

            _recordBusinessLogicMock.Verify(x => x.GetPersons(), Times.Once);
            _sortHelperMock.Verify(x => x.SortByFavoriteColorAsc(It.IsAny<ICollection<Person>>()), Times.Never);
        }
    }
}
