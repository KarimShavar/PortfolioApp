using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChartJSCore.Models;
using ChartJSCore.Models.Bar;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortfolioApp.Controllers.Weather;
using PortfolioApp.Models.Weather;

namespace PortfolioApp.Pages.Portfolio
{
    public class OpenWeatherModel : PageModel
    {
        public string BackgroundImage = @"assets/severin-hoin-1441624-unsplash.jpg";

        public double[] MedianGlobalTemperatures { get; set; }
        public IDictionary<string, double> CityTemperatures { get; set; }

        public IList<WeatherReport> Weathers { get; set; }
        private readonly IWeatherService _weatherService;
        private IList<double> _medianTemps;

        public OpenWeatherModel(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public async Task OnGetAsync()
        {
            Weathers = await _weatherService.GetWeatherForAllCitiesAsync();
            CityTemperatures = _weatherService.GetCityTemperatures();
            _medianTemps = GetMedianTemperature();
        }

        public Chart TempChart()
        {
            var chart = new Chart();

            chart.Type = Enums.ChartType.Line;

            var data = new ChartJSCore.Models.Data();
            data.Labels = new List<string>(CityTemperatures.Keys);

            var dataset1 = new LineDataset()
            {
                Label = "Temperatures",
                Data = CityTemperatures.Values.ToList(),
                Fill = "true",
                LineTension = 0.1,
                BackgroundColor = "rgba(75, 192, 192, 0.4)",
                BorderColor = "rgba(75,192,192,1)",
                BorderCapStyle = "butt",
                BorderDash = new List<int> { },
                BorderDashOffset = 0.0,
                BorderJoinStyle = "miter",
                PointBorderColor = new List<string>() { "rgba(75,192,192,1)" },
                PointBackgroundColor = new List<string>() { "#fff" },
                PointBorderWidth = new List<int> { 1 },
                PointHoverRadius = new List<int> { 5 },
                PointHoverBackgroundColor = new List<string>() { "rgba(75,192,192,1)" },
                PointHoverBorderColor = new List<string>() { "rgba(220,220,220,1)" },
                PointHoverBorderWidth = new List<int> { 2 },
                PointRadius = new List<int> { 1 },
                PointHitRadius = new List<int> { 10 },
                SpanGaps = false
            };

            var dataset2 = new LineDataset()
            {
                Label = "Median",
                Data = _medianTemps,
                Fill = "false",
                LineTension = 0.1,
                BackgroundColor = "rgba(0, 0, 0, 0.4)",
                BorderColor = "rgba(0,0,0,1)",
                BorderCapStyle = "butt",
                PointRadius = new List<int> { 0 },
                PointHitRadius = new List<int> { 10 },
                SpanGaps = false
            };


            data.Datasets = new List<Dataset> { dataset1, dataset2 };
            chart.Data = data;

            var options = new BarOptions()
            {
                Scales = new Scales(),
                BarPercentage = 0.7
            };

            var scales = new Scales()
            {
                YAxes = new List<Scale>()
                {
                    new CartesianScale()
                    {
                        Ticks = new CartesianLinearTick()
                        {
                            BeginAtZero = true
                        }
                    }
                }
            };

            options.Scales = scales;

            chart.Options = options;

            chart.Options.Layout = new Layout()
            {
                Padding = new Padding()
                {
                    PaddingObject = new PaddingObject()
                    {
                        Left = 10,
                        Right = 12
                    }
                }
            };

            return chart;
        }
        private IList<double> GetMedianTemperature()
        {
            var sortedWeathers = Weathers.OrderBy(t => t.Temperature);
            var middle = sortedWeathers.Count() / 2;

            var median = sortedWeathers.Skip(middle).FirstOrDefault();
            var medianTemps = new List<double>();

            if (median == null)
            {
                throw new Exception("Could not get median temperature values");
            }
            foreach (var weatherReport in Weathers)
            {
                medianTemps.Add(median.Temperature);
            }

            return medianTemps;
        }
    }
}