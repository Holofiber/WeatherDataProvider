using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using App1.Annotations;
using BusinessLogic;
using BusinessLogic.Interface;

namespace App1
{
    public class WeatherViewModel : INotifyPropertyChanged
    {
        private readonly IWeatherProvider provider;


        private WeatherData weatherData = new WeatherData();

        public void SubscribeData()
        {

            provider.Start();
            provider.Subscribe("Lviv");

            provider.OnWeatherUpdate += (sender, data) =>
            {
                Debug.WriteLine(1);

                Temperature = data.Temp;
                City = data.City;
                Date = data.Date;
            };
        }

        public WeatherViewModel(IWeatherProvider provider)
        {
            this.provider = provider;

            SubscribeData();
        }

        public float Temperature
        {
            get => weatherData.Temp;
            set
            {
                if (Math.Abs(weatherData.Temp - value) > 0f)
                {
                    weatherData.Temp = value;
                    OnPropertyChanged(nameof(Temperature));
                }
            }
        }

        public string City
        {
            get => weatherData.City;
            set
            {
                if (weatherData.City != value)
                {
                    weatherData.City = value;
                    OnPropertyChanged(nameof(City));
                }
            }
        }

        public DateTime Date
        {
            get => weatherData.Date;
            set
            {
                if (weatherData.Date != value)
                {
                    weatherData.Date = value;
                    OnPropertyChanged(nameof(Date));
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}