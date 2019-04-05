using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioApp.Models.Weather
{
    public class WeatherReport
    {
        public long Id { get; set; }
        public string City { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double Pressure { get; set; }
        public string Description { get; set; }
    }
}
