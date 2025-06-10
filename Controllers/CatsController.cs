using Microsoft.AspNetCore.Mvc;
using System.Net.Http; // needed this for making HTTP request to api
using System.Threading.Tasks; //async/awwait

namespace Cats.Controllers
{
    [ApiController] //sais this class is api controller
    [Route("api/[controller]")]
    public class CatsController : ControllerBase //this class lays out the structure of my API fetch
    {
        private HttpClient catApiRequest = new HttpClient();//HttpClient is class designed to send HTTP request
        // creates a new instance of the HTTPClient assings to catapirequest
        [HttpGet]
        public async Task<IActionResult> GetCats()
        {
            string apiKey = "live_WPeNhi2SuybBzK53iLQYVYwM82a7YD4EohwTCR1G5OIhDwNYSf73KstXGXSbI9Xp";
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.thecatapi.com/v1/breeds");//new instance
            request.Headers.Add("x-api-key", apiKey); //getting a 403 error needed 

            var response = await catApiRequest.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            return Content(content, "application/json");
        }
    }
}

