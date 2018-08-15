using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Interface
{
    public interface IWeatherProvider
    {
        string Name { get; }

        WeatherData GetCurrentWeather(string city);

        List<WeatherData> GetWeatherForecast(string london, int dayPeriod);

        event EventHandler<WeatherData> OnWeatherUpdate;
        void Subscribe(string city);

        void Start();


    }
}
