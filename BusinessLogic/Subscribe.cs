using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Subscribe
    {
        public Provider Provider { get; set; }
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
        public Subscribe(Provider provider)
        {
            if (provider == null)
            {
                throw new ArgumentNullException();
            }
            Provider = provider;
        }
        public event EventHandler PropertyChanged;
        public async void StartSubscribe()
        {



            while (true)
            {
                await Task.Delay(TimeSpan.FromSeconds(30));

                using (StreamReader streamReader = new StreamReader(Provider.HttpWebResponse.GetResponseStream() ?? throw new InvalidOperationException("Response is empty")))

                {
                    respponse = streamReader.ReadToEnd();
                }
            }

        }
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {

            PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


    }
}
