using Newtonsoft.Json.Linq;

var client = new HttpClient();

Console.WriteLine("Enter GamerTag: ");
var gamerTag = Console.ReadLine();

var request = new HttpRequestMessage
{
    Method = HttpMethod.Get,
    RequestUri = new Uri($"https://call-of-duty-modern-warfare.p.rapidapi.com/warzone-matches/{gamerTag}/psn"),
    Headers =
    {
        { "X-RapidAPI-Key", "d0f6aa5c75msh863272f2aadee3dp1eb14ejsnceeacde7e03c" },
        { "X-RapidAPI-Host", "call-of-duty-modern-warfare.p.rapidapi.com" },
    },
};
using (var response = await client.SendAsync(request))
{
    response.EnsureSuccessStatusCode();
    var body = await response.Content.ReadAsStringAsync();
    //Console.WriteLine(body);
    var kills = JObject.Parse(body).SelectToken("summary.all.kills")?.ToString();
    var kdRatio = JObject.Parse(body).SelectToken("summary.all.kdRatio")?.ToString();
    var score = JObject.Parse(body).SelectToken("summary.all.score")?.ToString();
    
    
    Console.WriteLine($"Kills: {kills}");
    Console.WriteLine($"KdRatio: {kdRatio}");
    Console.WriteLine($"Score: {score}");
}