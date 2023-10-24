using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace StayHappy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;

        }

        public IActionResult Index()
        {
            _logger.LogInformation("Hey, this is an INFO message.");
            _logger.LogWarning("Hey, this is a WARNING message.");
            _logger.LogError("Hey, this is an ERROR message.");
            _logger.LogCritical("This is acritical message");
            return Ok();
        }
    }
}
