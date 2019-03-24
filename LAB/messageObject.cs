using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace LAB
{
    public class MessageObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string who;
        private string type;
        private string data;
        private string source;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public string Who
        {
            get { return this.who; }
            set
            {
                if (this.who != value)
                {
                    this.who = value;
                    this.NotifyPropertyChanged("Who");
                }
            }
        }

        public string Type
        {
            get { return this.type; }
            set
            {
                if (this.type != value)
                {
                    this.type = value;
                    this.NotifyPropertyChanged("Type");
                }
            }
        }

        public string Source
        {
            get
            {
                return System.AppDomain.CurrentDomain.BaseDirectory + "/assets/img/" + this.data;
            }
            set
            {
                if (this.source != value)
                {
                    this.source = value;
                    this.NotifyPropertyChanged("Source");
                }
            }
        }

        public string Data
        {
            get
            {
                    return this.data;
            }
            set
            {
                if (data != value)
                {
                    data = value;
                    NotifyPropertyChanged("Data");
                }
            }
        }
    }
}