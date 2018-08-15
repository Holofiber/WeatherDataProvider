using System;
using System.Net;

namespace OpenWeatherMapProvider
{
    public class Provider
    {
        private string City { get; set; }

        public HttpWebResponse HttpWebResponse { get; private set; }

        private string url;
        public Provider(string city)
        {
            if (String.IsNullOrEmpty(city))
            {
                throw new ArgumentNullException();
            }
            City = city;
        }
        
        public void CreateWebRequest()
        {
            url = $"http://api.openweathermap.org/data/2.5/weather?q=" + City + "&units=metric&appid=413ef3489a48bea729d26216bcc8ca0c";

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

        }




    }
}