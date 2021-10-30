using System;
using System.Threading.Tasks;
using Weather.PCL.Abstractions;
using Weather.PCL.Implementations;
using Weather.PCL.Models.Enums;

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
                var IsCorrectLng = double.TryParse(Console.ReadLine(), out double lng);
                Console.Write("Enter lat: ");
                var IsCorrectLat = double.TryParse(Console.ReadLine(), out double lat);

                Console.WriteLine("1. Celcius");
                Console.WriteLine("2. Farenheit");
                Console.Write("Your Choice: ");
                var userChoice = int.TryParse(Console.ReadLine(), out int choice);
                if (!userChoice || choice > 2) continue;
                db.ChoiceCorF((TempChoice)choice);

                if (!IsCorrectLng || !IsCorrectLat) continue;

                Console.Clear();
                Console.WriteLine("Loading...");
                var weatherInfo = await db.GetWeatherDataByLngAndLat(lng, lat);
                Console.Clear();

                Console.WriteLine($"Longitude: {weatherInfo.Longitude}");
                Console.WriteLine($"Latitude: {weatherInfo.Latitude}");
                Console.WriteLine($"Timezon: {weatherInfo.Timezone}");
                Console.WriteLine($"Summary: {weatherInfo.Currently.Summary}");

                
                Console.WriteLine($"Temperature: {(int)weatherInfo.Currently.ApparentTemperature}");

                Console.ReadKey();
                Console.Clear();
            } while (true);
            

            Console.ReadKey();
        }
    }
}
