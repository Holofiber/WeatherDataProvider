using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic;
using BusinessLogic.Interface;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OpenWeatherMapProvider
{
    public class OpenWeatherProvider : IWeatherProvider
    {


        private OpenWeatherMapProvider.Provider provider;
        private OpenWeatherMapProvider.Subscriber subscriber;


        public WeatherData WeatherData { get; private set; }

        public OpenWeatherProvider()
        {

        }


        public string Name => "OpenWeather";

        public WeatherData GetCurrentWeather(string city)
        {
            provider = new OpenWeatherMapProvider.Provider(city);
            provider.CreateWebRequest();

            subscriber = new OpenWeatherMapProvider.Subscriber(provider);
            subscriber.StartSubscribe();






            OpenWeatherData weatherData = JsonConvert.DeserializeObject<OpenWeatherData>(subscriber.Response);

            OpenWeatherDataConverter converter = new OpenWeatherDataConverter();


            var currentWeather = converter.ConvertData(weatherData);
            currentWeather.Date = DateTime.Now;
            return currentWeather;
        }

        public List<WeatherData> GetWeatherForecast(string london, int dayPeriod)
        {
            throw new NotImplementedException();
        }


        private HashSet<string> cities = new HashSet<string>();

        public void Subscribe(string city)
        {
            cities.Add(city);
        }

        public void Unsubscribe(string city)
        {
            cities.Remove(city);
        }

        public void Start()
        {
            Task.Factory.StartNew(async () =>
             {

                 while (true)
                 {
                     await Task.Delay(TimeSpan.FromSeconds(5));
                     foreach (string city in cities)
                     {
                         var currentWeather = GetCurrentWeather(city);
                         RaiseOnWeatherUpdate(currentWeather);
                     }
                 }

             });
        }

        public event EventHandler<WeatherData> OnWeatherUpdate;


        protected virtual void RaiseOnWeatherUpdate(WeatherData e)
        {
            OnWeatherUpdate?.Invoke(this, e);
        }
    }
}
