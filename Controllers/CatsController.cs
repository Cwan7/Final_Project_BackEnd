using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cats.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatsController : ControllerBase //this class lays out the structure of my API fetch
    {
        private readonly HttpClient _httpClient; //creating a varible called _httpClient that follows the HttpClient class structure 

        public CatsController(HttpClient httpClient) // this is the constructor takes varible httpClient that follows the HttpClient class stucture
        {
            _httpClient = httpClient; //
        }

        [HttpGet]
        public async Task<IActionResult> GetCats()
        {
            string apiKey = "live_WPeNhi2SuybBzK53iLQYVYwM82a7YD4EohwTCR1G5OIhDwNYSf73KstXGXSbI9Xp";
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.thecatapi.com/v1/breeds");
            request.Headers.Add("x-api-key", apiKey);

            var response = await _httpClient.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            return Content(content, "application/json");
        }
    }
}

