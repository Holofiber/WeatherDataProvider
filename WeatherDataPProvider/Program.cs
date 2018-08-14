using System;
using System.Drawing;
using BusinessLogic;
using BusinessLogic.Interface;
using Console = Colorful.Console;

namespace WeatherDataProvider
{
    class Program
    {
        static void Main(string[] args)
        {

           // IWeatherProvider provider = new DummyWeatherProvider();
            IWeatherProvider provider2 = new WeatherProvider();
            //---------------------------------------------------------------------------

           // provider.Start();
          //  provider2.Start();

            string londonCity = "London";
            string lvivCity = "Lviv";

          //  var lvivWeather = provider.GetCurrentWeather(lvivCity);
          //  var londonWeather = provider.GetCurrentWeather(londonCity);
           // var londonWeatherForecast = provider.GetWeatherForecast(londonCity, 5);

            //provider.Subscribe(lvivCity);
           // provider.Subscribe(londonCity);
            provider2.Subscribe(lvivCity);
            provider2.Start();
            provider2.OnWeatherUpdate += ProviderOnOnWeatherUpdate;
           // provider.OnWeatherUpdate += ProviderOnOnWeatherUpdate;




            //print weatherData
            /* Console.WriteLine($"{lvivWeather}", Color.Crimson);
             Console.WriteLine($"{londonWeather}", Color.ForestGreen);

             foreach (var weatherData in londonWeatherForecast)
             {
                 Console.WriteLine($"{weatherData}", Color.Yellow);
             }*/

            //  System.Console.WriteLine(londonWeatherForecast);



            Console.ReadLine();

        }

        private static void ProviderOnOnWeatherUpdate(object sender, WeatherData data)
        {
           
                Console.WriteLine(data, Color.Red);
            
        }
    }
}
