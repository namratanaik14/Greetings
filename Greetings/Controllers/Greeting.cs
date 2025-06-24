using Greetings.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace Greetings.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Greeting : Controller
    {
        private readonly IGreetingRepository _context;

        public Greeting(IGreetingRepository context)
        {
            _context = context;
        }

        [HttpGet]
        [EnableRateLimiting("fixed")]
        public async Task<IActionResult> Get([FromQuery] string name = "World")
        {
            var greeting = await _context.GetGreetingAsync(name) ?? $"Hello, {name}";
            return Ok(greeting);
        }

        [HttpPost]
        [EnableRateLimiting("fixed")]
        public async Task<IActionResult> Post([FromBody] string name)
        {
            var greetingText = $"Hello, {name}";
            await _context.SetGreetingAsync(name, greetingText);
            return Ok(greetingText);
        }
    }
}
