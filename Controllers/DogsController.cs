using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace Dogs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DogsController : ControllerBase
    {
        private HttpClient dogApiRequest = new HttpClient();

        [HttpGet]
        public async Task<IActionResult> GetDogs()
        {
            string apiKey = "live_cYOEW54OGV0QZxYnKx82NYDqUWSaV48ZODUWf7fCzlWAGcEZKAWj9XzAHMaC20HG";
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.thedogapi.com/v1/breeds");
            request.Headers.Add("x-api-key", apiKey);

            var response = await dogApiRequest.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            return Content(content, "application/json");
        }
    }
}










//Browser calls /api/cats ➝ ASP.NET creates CatsController ➝ ➝ Runs GetCats() ➝ Prepares request ➝ Sends request ➝ Gets response ➝ Returns JSON

