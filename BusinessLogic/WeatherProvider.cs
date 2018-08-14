using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic.Interface;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BusinessLogic
{
    public class WeatherProvider : IWeatherProvider
    {


        private Provider provider;
        private Subscriber subscriber;


        public WeatherData WeatherData { get; private set; }

        public WeatherProvider()
        {

        }



        public WeatherData GetCurrentWeather(string city)
        {
            provider = new Provider(city);
            provider.CreateWebRequest();

            subscriber = new Subscriber(provider);
            subscriber.StartSubscribe();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<JObject, WeatherData>();
                cfg.AddProfile<WeatherDataProfile>();
            });

            var mapper = config.CreateMapper();

            

            var jsonoObj = JObject.Parse(subscriber.Response);
            WeatherData vd  = mapper.Map<WeatherData>(jsonoObj);

            //WeatherData = JsonConvert.DeserializeObject<WeatherData>(subscriber.Response);

            return WeatherData;
        }

        public List<WeatherData> GetWeatherForecast(string london, int dayPeriod)
        {
            throw new NotImplementedException();
        }


        private List<string> cities = new List<string>();
        public void Subscribe(string city)
        {
            cities.Add(city);
        }

        public void Start()
        {
            // Task.Factory.StartNew(async () =>
            //  {

            //   while (true)
            //  {
            //     await Task.Delay(TimeSpan.FromSeconds(2));
            foreach (string city in cities)
            {
                var currentWeather = GetCurrentWeather(city);
                RaiseOnWeatherUpdate(currentWeather);
            }
            // }

            //});
        }

        public event EventHandler<WeatherData> OnWeatherUpdate;


        protected virtual void RaiseOnWeatherUpdate(WeatherData e)
        {
            OnWeatherUpdate?.Invoke(this, e);
        }
    }
}
