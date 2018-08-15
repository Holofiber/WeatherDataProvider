using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Subscriber
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
        public Subscriber(Provider provider)
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
