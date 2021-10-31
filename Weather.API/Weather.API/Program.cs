using System;
using System.Linq;
using System.Text;
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
            Console.OutputEncoding = Encoding.UTF8;
            IDataBase db = new DataBase();
            //41.716667
            //44.783333

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

                Console.Write("Enter the language(use abbreviation like english = en): ");
                var userLang = Console.ReadLine();
                if (userLang.Length > 2) continue;
                if (!IsCorrectLng || !IsCorrectLat) continue;

                Console.Clear();
                Console.WriteLine("Loading...");
                var weatherInfo = await db.GetWeatherDataByLngAndLat(lat, lng, userLang);
                Console.Clear();

                Console.WriteLine($"Longitude: {weatherInfo.Longitude}  Latitude: {weatherInfo.Latitude}");
                Console.WriteLine($"Timezone: {weatherInfo.Timezone}");
                Console.WriteLine($"Summary: {weatherInfo.Currently.Summary}");
                char tempChoice;
                TempChoice userTempChoice = (TempChoice)choice;
                if (userTempChoice == TempChoice.C)
                {
                    tempChoice = 'C';
                }
                else
                {
                    tempChoice = 'F';
                }
                Console.WriteLine($"Temperature: {(int)weatherInfo.Currently.ApparentTemperature} °{tempChoice}");
                Console.WriteLine($"Rain Probability: {weatherInfo.Currently.PrecipProbability}");
                Console.WriteLine($"Wind Speed: {weatherInfo.Currently.WindSpeed} m/s");
                Console.WriteLine($"Daily Summary: {weatherInfo.Daily.Summary}");
                Console.WriteLine($"Hourly Summary: {weatherInfo.Hourly.Summary}");

                Console.ReadKey();
                Console.Clear();
            } while (true);
            

            Console.ReadKey();
        }
    }
}
