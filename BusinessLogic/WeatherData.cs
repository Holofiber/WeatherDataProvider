using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BusinessLogic
{
    public class WeatherData
    {
        public DateTime Date { get; set; }

        //  [JsonProperty("name")]
        public string City { get; set; }

        [JsonProperty("wind.speed")]
        public float WindSpeed { get; set; }

        // [JsonProperty("temp")]
        public float Temp { get; set; }

        public float Pressure { get; set; }

        public float Humidity { get; set; }

        public override string ToString()
        {
            return $"{nameof(City)}: {City}" +
                   $" \t{nameof(Temp)}: {Temp}°C," +
                   $" \t{nameof(Humidity)}: {Humidity}%," +
                   $" \t{nameof(Pressure)}: {Pressure}, " +
                   $" \t{nameof(WindSpeed)}: {WindSpeed} " +
                   $" \t{nameof(Date)}: {Date:MM/dd/yyyy dddd} ";
        }
    }

}
