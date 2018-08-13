using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class WeatherResponse
    {
        public TemperatureInfo Main { get; set; }
        public string Name { get; set; }

        public Wind Wind { get; set; }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name }" +
                   $" \t{nameof(Main.Temp)}: {Main.Temp}°C," +
                   $" \t{nameof(Main.Humidity)}: {Main.Humidity}%," +
                   $" \t{nameof(Main.Pressure)}: {Main.Pressure}, " +
                   $" \t{nameof(Wind.Speed)}: {Wind.Speed} ";
        }
    }

    public class Wind
    {
        public float Speed { get; set; }
    }


}
