using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace weather.map.Pages.api
{
    [Route("api")]
    [ApiController]
    public class OpenWeatherMapAPI : Controller
    {
        private readonly string? apiKey = "6718004e99fa5e8a92fd526818590b15";

        private async Task<string> SendHttpRequest(string requestUri)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            request.Headers.Add("Accept", "application/json");
            HttpClient client = new HttpClient();
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }

        // GET: api/LocationData/{longitude}/{latitude}
        [Route("LocationData/{longitude}/{latitude}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<string>> LocationData(double longitude, double latitude)
        {
            var requestUri = $"https://api.openweathermap.org/data/2.5/weather?lat={latitude}&lon={longitude}&appid={apiKey}";
            var response = await SendHttpRequest(requestUri);
            return new ActionResult<string>(response);
        }

        // GET: api/ForecastHourlyData/{longitude}/{latitude}
        [Route("ForecastHourlyData/{longitude}/{latitude}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<string>> ForecastHourlyData(double longitude, double latitude)
        {
            var requestUri = $"https://pro.openweathermap.org/data/2.5/forecast/hourly?lat={latitude}&lon={longitude}&appid={apiKey}";
            var response = await SendHttpRequest(requestUri);
            return new ActionResult<string>(response);
        }

        // GET: api/ForecastDailyData/{longitude}/{latitude}
        [Route("ForecastDailyData/{longitude}/{latitude}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<string>> ForecastDailyData(double longitude, double latitude)
        {
            var requestUri = $"https://api.openweathermap.org/data/2.5/forecast/daily?lat={latitude}&lon={longitude}&appid={apiKey}";
            var response = await SendHttpRequest(requestUri);
            return new ActionResult<string>(response);
        }
    }
}
