using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PortfolioApp.Models.Weather;
using PortfolioApp.Storage;

namespace PortfolioApp.Controllers.Weather
{
    public class WeatherCall : ControllerBase
    {
        public OWeatherResponseRectangleDto Weathers { get; private set; }
        public OWeatherResponseDto SingleCityWeather { get; private set; }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("http://api.openweathermap.org");
                    var response = await client.GetAsync(
                        $"/data/2.5/box/city?bbox=-5,52,2,50,10&appid={ApiStorage.OWeatherApiKey}&units=metric");
                    response.EnsureSuccessStatusCode();

                    var stringResult = await response.Content.ReadAsStringAsync();
                    Weathers = JsonConvert.DeserializeObject<OWeatherResponseRectangleDto>(stringResult);
                    return Ok();
                }
                catch (HttpRequestException ex)
                {
                    return BadRequest($"Error getting data:{ex.Message}");
                }
            }
        }
        
        [HttpGet("{city}")]
        public async Task<IActionResult> GetCityWeather(string city)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("http://api.openweathermap.org");
                    var response = await client.GetAsync($"/data/2.5/weather?q={city}&appid={ApiStorage.OWeatherApiKey}&units=metric");
                    response.EnsureSuccessStatusCode();

                    var stringResult = await response.Content.ReadAsStringAsync();
                    SingleCityWeather = JsonConvert.DeserializeObject<OWeatherResponseDto>(stringResult);
                    return Ok(stringResult);
                }
                catch (HttpRequestException ex)
                {
                    return BadRequest($"Error getting data:{ex.Message}");
                }
            }
        }
    }
}
