using GuranteedRate.Homework.BusineesLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GuranteedRate.Homework.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {

        private readonly IRecordBusinessLogic _recordBusinessLogic;

        public TestController(IRecordBusinessLogic recordBusinessLogic)
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
