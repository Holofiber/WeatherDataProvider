using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic;

namespace OpenWeatherMapProvider
{
    public class OpenWeatherDataConverter
    {
        WeatherData wd = new WeatherData();

        public WeatherData ConvertData(OpenWeatherData owd)
        {
            wd.City = owd.Name;
            wd.Humidity = owd.Main.Humidity;
            wd.Pressure = owd.Main.Pressure;
            wd.Temp = owd.Main.Temp;
            wd.WindSpeed = owd.Wind.Speed;

            return wd;
        }

    }
}
