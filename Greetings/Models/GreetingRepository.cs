using Greetings.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Greetings.Models
{
    public class GreetingRepository : IGreetingRepository
    {
        private readonly GreetingContext _context;
        private readonly IMemoryCache _cache;

        public GreetingRepository(GreetingContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<string?> GetGreetingAsync(string name)
        {
            if (_cache.TryGetValue(name, out string cachedGreeting))
                return cachedGreeting;

            var greeting = await _context.Greetings
            .Where(g => g.Name == name)
            .Select(g => g.GreetingText)
            .FirstOrDefaultAsync();

            if (greeting != null)
                _cache.Set(name, greeting, TimeSpan.FromMinutes(5));

            return greeting;
        }

        public async Task SetGreetingAsync(string name, string greetingText)
        {
            var greeting = new Greeting
            {
                Name = name,
                GreetingText = greetingText,
                CreatedAt = DateTime.UtcNow
            };
            await _context.Greetings.AddAsync(greeting);
            await _context.SaveChangesAsync();

            _cache.Set(name, greetingText, TimeSpan.FromMinutes(5));
        }
    }
}
