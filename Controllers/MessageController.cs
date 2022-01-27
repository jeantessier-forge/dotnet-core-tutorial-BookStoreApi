using BookStoreApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMyDependency _myDependency;

        public MessageController(IMyDependency myDependency)
        {
            _myDependency = myDependency;
        }

        [HttpGet]
        public string Get(string message)
        {
            _myDependency.WriteMessage(message);
            return "OK";
        }
    }
}
