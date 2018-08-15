using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidWeather.Annotations;
using BusinessLogic;

namespace AndroidWeather
{
    public class WeatherViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private WeatherData weatherData;

        public WeatherViewModel()
        {
            weatherData = new WeatherData();
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


    }
}