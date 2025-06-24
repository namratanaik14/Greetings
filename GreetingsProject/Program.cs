using System.Net.Http.Json;

// See https://aka.ms/new-console-template for more information

var cache = new Dictionary<string, string>();
var client = new HttpClient();
string baseUrl = "https://localhost:7137/api/greeting";

Console.Write("Enter your name: ");
string name = Console.ReadLine();

if (cache.ContainsKey(name))
{
    Console.WriteLine(cache[name]);
}
else
{
    try
    {
        var response = await client.GetAsync($"{baseUrl}?name={name}");
        if (response.IsSuccessStatusCode)
        {
            var greeting = await response.Content.ReadAsStringAsync();
            cache[name] = greeting;
            Console.WriteLine(greeting);
            Console.ReadLine();
        }
        else if ((int)response.StatusCode == 429)
        {
            Console.WriteLine("Rate limit exceeded. Try again later.");
        }
        else
        {
            Console.WriteLine("An error occurred.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

