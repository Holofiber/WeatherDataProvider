using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using BusinessLogic.Interface;
using Newtonsoft.Json;
using Console = Colorful.Console;

namespace WeatherDataProvider
{
    class Program
    {
        static void Main(string[] args)
        {
            //create weatherProvider
            IWeatherProvider weatherProvider = new WeatherProvider("Lviv");
            var secondProvider = new WeatherProvider("London");

            //start weatherProvider
            weatherProvider.Run();
            secondProvider.Run();



            //print weatherProvider
            Console.WriteLine($"{weatherProvider.WeatherResponse}", ConsoleColor.Gray);
            Console.WriteLine($"{secondProvider.WeatherResponse}", Color.Coral);



            Console.ReadLine();

        }
    }
}
