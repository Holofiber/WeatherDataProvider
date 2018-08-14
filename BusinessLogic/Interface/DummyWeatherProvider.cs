using System;

namespace BusinessLogic.Interface
{
    public class DummyWeatherProvider : IWeatherProvider
    {
        public WeatherData GetCurrentWeather(string city)
        {
            var weatherData = new WeatherData {Period = TimeSpan.Zero};

            if (city == "Lviv")
            {
                weatherData.City = city;
                weatherData.Humidity = 56;
                weatherData.Pressure = 1034;
                weatherData.Temp = 27;
                weatherData.WindSpeed = 10;
            }
            else if (city == "London")
            {
                weatherData.City = city;
                weatherData.Humidity = 12;
                weatherData.Pressure = 1334;
                weatherData.Temp = 21;
                weatherData.WindSpeed = 5;
            }
            else
            {
                throw new ArgumentException();
            }

            return weatherData;
        }
    }
}