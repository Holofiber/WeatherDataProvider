using System;
using System.Collections.Generic;

namespace OpenWeatherMapProvider
{
    public class OpenWeatherData
    {
        public Coord Coord { get; set; }
        public List<Weather> Weather { get; set; }
        public string Base { get; set; }
        public Main Main { get; set; }
        public long Visibility { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; }
        public long Dt { get; set; }
        public Sys Sys { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
        public long Cod { get; set; }
    }

    public class Clouds
    {
        public long All { get; set; }
    }

    public class Coord
    {
        public decimal Lon { get; set; }
        public decimal Lat { get; set; }
    }

    public class Main
    {
        public long Temp { get; set; }
        public long Pressure { get; set; }
        public long Humidity { get; set; }
        public long Temp_Min { get; set; }
        public long Temp_Max { get; set; }
    }

    public class Sys
    {
        public long Type { get; set; }
        public long Id { get; set; }
        public decimal Message { get; set; }
        public string Country { get; set; }
        public long Sunrise { get; set; }
        public long Sunset { get; set; }
    }

    public class Weather
    {
        public long Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }

    public class Wind
    {
        public long Speed { get; set; }
        public long Deg { get; set; }
    }

}
