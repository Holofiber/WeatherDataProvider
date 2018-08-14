using System;
using BusinessLogic.Interface;
using Newtonsoft.Json;

namespace BusinessLogic
{
    public class WeatherProvider 
    {

        private string City;
        private Provider Provider;
        private Subscribe Subscribe;


        public WeatherData WeatherData { get; private set; }

        public WeatherProvider(string city)
        {
            if (string.IsNullOrEmpty(city))
            {
                throw new ArgumentNullException();
            }
            City = city;
        }

        public void Run()
        {

            Provider = new Provider(City);
            Provider.CreateWebRequest();

            Subscribe = new Subscribe(Provider);
            Subscribe.StartSubscribe();

            WeatherData = JsonConvert.DeserializeObject<WeatherData>(Subscribe.Response);
        }
    }
}
