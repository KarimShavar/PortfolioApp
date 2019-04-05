using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioApp.Models.Weather
{
    public class OWeatherResponseRectangleDto
    {
        public string cod { get; set; }
        public double calctime { get; set; }
        public double cnt { get; set; }
        public List<OWeatherResponseDto> list { get; set; }
    }
}
