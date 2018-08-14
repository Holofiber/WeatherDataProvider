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
            //---------------------------------------------------------------------------


            var lvivWeather = provider.GetCurrentWeather("Lviv");
            var londonWeather = provider.GetCurrentWeather("London");




            //print weatherData
            Console.WriteLine($"{lvivWeather}", ConsoleColor.Gray);
            Console.WriteLine($"{londonWeather}", ConsoleColor.Gray);




            Console.ReadLine();

        }
    }
}
