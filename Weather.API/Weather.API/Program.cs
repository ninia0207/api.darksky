using System;
using System.Threading.Tasks;
using Weather.PCL.Abstractions;
using Weather.PCL.Implementations;

namespace Weather.API
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IDataBase db = new DataBase();
            //41.7151
            //44.8271
            
            do
            {
                Console.Write("Enter lng: ");
                double lng = double.Parse(Console.ReadLine());


                Console.Write("Enter lat: ");
                double lat = double.Parse(Console.ReadLine());

                Console.Clear();
                var weatherInfo = await db.GetWeatherDataByLngAndLat(lng, lat);

                Console.WriteLine($"Lng: {weatherInfo.Longitude}");
                Console.WriteLine($"Lat: {weatherInfo.Latitude}");
                Console.WriteLine($"Timezon: {weatherInfo.Timezone}");
                Console.WriteLine($"Summary: {weatherInfo.Currently.Summary}");


                Console.WriteLine($"Temperature: {weatherInfo.Currently.ApparentTemperature}");
                Console.Clear();

            } while (true);
            

            Console.ReadKey();
        }
    }
}
