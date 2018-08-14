using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Interface
{
    public interface IWeatherProvider
    {
        WeatherData GetCurrentWeather(string city);

    }
}
