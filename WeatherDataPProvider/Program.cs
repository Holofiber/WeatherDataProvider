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

            IWeatherProvider provider = new DummyWeatherProvider();
            IWeatherProvider provider2 = new OpenWeatherProvider();
            //---------------------------------------------------------------------------

            provider.Start();
            provider2.Start();

            string londonCity = "London";
            string lvivCity = "Lviv";

            var lvivWeather = provider.GetCurrentWeather(lvivCity);
            var londonWeather = provider.GetCurrentWeather(londonCity);
            var londonWeatherForecast = provider.GetWeatherForecast(londonCity, 5);

            provider.Subscribe(lvivCity);
            provider.Subscribe(londonCity);
            provider2.Subscribe("Paris");

            provider2.OnWeatherUpdate += (sender, data) => Console.WriteLine(data, Color.Red);
            provider.OnWeatherUpdate += (sender, data) => Console.WriteLine(data, Color.Green);


            Console.ReadLine();

        }


    }
}
