using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

namespace OpenWeatherMapProvider
{
    public class Subscriber
    {
        public OpenWeatherMapProvider.Provider Provider { get; set; }
        private string respponse;
        public string Response
        {
            get { return respponse; }
            set
            {
                respponse = value;
                OnPropertyChanged(Response);
            }
        }
        public Subscriber(OpenWeatherMapProvider.Provider provider)
        {
            if (provider == null)
            {
                throw new ArgumentNullException();
            }
            Provider = provider;
        }
        public event EventHandler PropertyChanged;
        public void StartSubscribe()
        {
            using (StreamReader streamReader = new StreamReader(Provider.HttpWebResponse.GetResponseStream() ?? throw new InvalidOperationException("Response is empty")))

            {
                respponse = streamReader.ReadToEnd();
            }
        }
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {

            PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


    }
}
