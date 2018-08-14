using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class WeatherData
    {
        public TimeSpan Period { get; set; }

        public string City { get; set; }

        public float WindSpeed { get; set; }

        public float Temp { get; set; }

        public float Pressure { get; set; }

        public float Humidity { get; set; }

        public override string ToString()
        {
            return $"{nameof(City)}: {City }" +
                   $" \t{nameof(Temp)}: {Temp}°C," +
                   $" \t{nameof(Humidity)}: {Humidity}%," +
                   $" \t{nameof(Pressure)}: {Pressure}, " +
                   $" \t{nameof(WindSpeed)}: {WindSpeed} ";
        }
    }




}
