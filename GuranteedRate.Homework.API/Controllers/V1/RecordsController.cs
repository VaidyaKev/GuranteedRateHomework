using GuranteedRate.Homework.BusineesLogic.Interfaces;
using GuranteedRate.Homework.Domain.Helpers;
using GuranteedRate.Homework.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace GuranteedRate.Homework.API.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RecordsController : ControllerBase
    {
        private readonly IRecordBusinessLogic _recordBusinessLogic;
        private readonly ISortHelper _sortHelper;

        public RecordsController(IRecordBusinessLogic recordBusinessLogic, ISortHelper sortHelper)
        {
            _recordBusinessLogic = recordBusinessLogic;
            _sortHelper = sortHelper;
        }

        /// <summary>
        /// Gets Person Record Sorted By Favorite Color in Ascending Order.
        /// </summary>
        /// <returns></returns>
        [Route("records/color")]
        [ProducesResponseType(typeof(List<Person>), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [ProducesResponseType(typeof(string), 500)]
        [HttpGet]
        public IActionResult GetBySortedFavoriteColor()
        {
            return GetSortedPersonList(_sortHelper.SortByFavoriteColorAsc);
        }

        /// <summary>
        /// Gets Person Record Sorted By Date of Birth in Ascending Order.
        /// </summary>
        /// <returns></returns>
        [Route("records/birthday")]
        [ProducesResponseType(typeof(List<Person>), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [ProducesResponseType(typeof(string), 500)]
        [HttpGet]
        public IActionResult GetBySortedBirthday()
        {
            return GetSortedPersonList(_sortHelper.SortByDobAsc);
        }

        /// <summary>
        /// Gets Person Record Sorted By Last Name in Ascending Order.
        /// </summary>
        /// <returns></returns>
        [Route("records/name")]
        [ProducesResponseType(typeof(List<Person>), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [ProducesResponseType(typeof(string), 500)]
        [HttpGet]
        public IActionResult GetBySortedLastName()
        {
            return GetSortedPersonList(_sortHelper.SortByLNameAsc);
        }

        /// <summary>
        /// Able to Add Person Record.
        /// </summary>
        /// <param name="personStr">ex. LastName, FirstName, Email, Favorite Color, DOB</param>
        /// <returns></returns>
        [Route("records")]
        [ProducesResponseType(typeof(List<Person>), 200)]
        [ProducesResponseType(typeof(string), 500)]
        [HttpPost]
        public IActionResult AddPersonRecord(string personStr)
        {
            try
            {
                _recordBusinessLogic.AddPerson(personStr);
                return Ok();
            }
            catch (Exception ex)
            {
                //log(ex);

                if (ex is ArgumentException || ex is ArgumentNullException)
                {
                    return BadRequest(ex.Message);
                }

                return StatusCode(500, "Encounterd an Error Fetching Person Records");
            }
        }


        private IActionResult GetSortedPersonList(Func<ICollection<Person>, ICollection<Person>> func)
        {
            try
            {
                var persons = _recordBusinessLogic.GetPersons();
                if (persons == null)
                {
                    return NotFound();
                }

                var orderedPerson = func(persons);

                return Ok(orderedPerson);
            }
            catch (Exception ex)
            {
                //log(ex);
                return StatusCode(500, "Encounterd an Error Fetching Person Records");
            }
        }
    }
}
