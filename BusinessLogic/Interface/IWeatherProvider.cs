using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Interface
{
    public interface IWeatherProvider
    {
        WeatherResponse WeatherResponse { get;}
        void Run();
    }
}
