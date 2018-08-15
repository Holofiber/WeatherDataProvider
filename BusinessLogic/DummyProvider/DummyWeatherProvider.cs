using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public class DummyWeatherProvider : IWeatherProvider
    {
        private HashSet<string> cities = new HashSet<string>();
        public void Subscribe(string city)
        {
            cities.Add(city);
        }

        public void Start()
        {
            Task.Factory.StartNew(async () =>
            {

                while (true)
                {
                    await Task.Delay(TimeSpan.FromSeconds(3));
                    foreach (string city in cities)
                    {
                        var currentWeather = GetCurrentWeather(city);
                        RaiseOnWeatherUpdate(currentWeather);
                    }
                }

            });
        }

        public void Unsubscribe(string city)
        {
            cities.Remove(city);
        }

        public string Name => "Dummy";

        public WeatherData GetCurrentWeather(string city)
        {
            var weatherData = new WeatherData();
            weatherData.Date = DateTime.Today;

            var random = new Random();
            weatherData.Temp = random.Next(20, 30);

            if (city == "Lviv")
            {
                weatherData.City = city;
                weatherData.Humidity = 56;
                weatherData.Pressure = 1034;

                weatherData.WindSpeed = 10;
            }
            else if (city == "London")
            {
                weatherData.City = city;
                weatherData.Humidity = 12;
                weatherData.Pressure = 1334;

                weatherData.WindSpeed = 5;
            }
            else if (city == "Paris")
            {
                weatherData.City = city;
                weatherData.Humidity = 33;
                weatherData.Pressure = 987;

                weatherData.WindSpeed = 7;
            }
            else
            {
                throw new ArgumentException();
            }

            return weatherData;
        }

        public event EventHandler<WeatherData> OnWeatherUpdate;


        protected virtual void RaiseOnWeatherUpdate(WeatherData e)
        {
            OnWeatherUpdate?.Invoke(this, e);
        }

        public List<WeatherData> GetWeatherForecast(string city, int i)
        {
            List<WeatherData> weatherDataForecast = new List<WeatherData>();

            var date = DateTime.Today;

            for (int j = 0; j < i; j++)
            {
                var d = date.AddDays(j);
                weatherDataForecast.Add(GetCurrentWeather(city));
            }

            return weatherDataForecast;
        }


    }
}