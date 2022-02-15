using GuranteedRate.Homework.BusineesLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GuranteedRate.Homework.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonsController : ControllerBase
    {
        private readonly IRecordBusinessLogic _recordBusinessLogic;

        public PersonsController(IRecordBusinessLogic recordBusinessLogic)
        {
            _recordBusinessLogic = recordBusinessLogic;
        }

        [HttpGet]
        public string Get()
        {
            return "";
        }
    }
}
