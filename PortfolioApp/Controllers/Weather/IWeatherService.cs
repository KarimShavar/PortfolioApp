using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortfolioApp.Models.Weather;

namespace PortfolioApp.Controllers.Weather
{
    public interface IWeatherService
    {
        Task<IList<WeatherReport>> GetWeatherForAllCitiesAsync();
        IDictionary<string, double> GetCityTemperatures();
    }
}
