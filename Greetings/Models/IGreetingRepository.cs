namespace Greetings.Models
{
    public interface IGreetingRepository
    {
        Task<string> GetGreetingAsync(string name);
        Task SetGreetingAsync(string name, string greetingText);
    }
}
