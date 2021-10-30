using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.PCL.Abstractions;
using Weather.PCL.Models.Abstractions;
using WebClient.Abstractions;

namespace Weather.PCL.Implementations
{
    public class DataBase : IDataBase
    {
        private readonly IWebClient _webClient = null;

        public DataBase()
        {
            _webClient = new WebClient.Implementations.WebClient();

        }

        public async Task<IWeather> GetWeatherDataByLngAndLat(double lng, double lat)
        {
            var weatherUrl = $"https://api.darksky.net/forecast/f11a85ff0f9dca472f8be4d387384bfb/{lat},{lng}";
            _webClient.ChangeUrl(weatherUrl);
            var weatherData = await _webClient.GetDataAsync();

            return JsonConvert.DeserializeObject<Weather.PCL.Models.Implementations.Weather>(weatherData);
        }
    }
}
