using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.PCL.Models.Abstractions;
using Weather.PCL.Models.Enums;

namespace Weather.PCL.Abstractions
{
    public interface IDataBase
    {
        public Task<IWeather> GetWeatherDataByLngAndLat(double lng, double lat);

        public void ChoiceCorF(TempChoice F);
    }
}
