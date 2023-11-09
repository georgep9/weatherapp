using System;
using System.Net;
using System.Text.Json;

namespace WpfApp1
{

    class OpenWeatherMapAPI
    {
        private WebRequest wrGETURL;
        public OpenWeatherMapAPI()
        {
            wrGETURL = WebRequest.Create("https://api.openweathermap.org/data/2.5/weather?lat=44.34&lon=10.99&appid=6718004e99fa5e8a92fd526818590b15");
            wrGETURL.Method = WebRequestMethods.Http.Get;
            wrGETURL.ContentType = "application/json";
        }
        public string GetResponse()
        {
            WebResponse response = wrGETURL.GetResponse();
            string jsonResponse = JsonSerializer.Serialize(response);
            return jsonResponse;
        }
    }
    internal class WeatherApp
    {
        static void Main(string[] args)
        {
            OpenWeatherMapAPI weatherMapAPI = new OpenWeatherMapAPI();
            string response = weatherMapAPI.GetResponse();
            Console.WriteLine(response);
        }
    }
}
