using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace ScreenFixer
{
    internal class ScreenFix: INotifyPropertyChanged
    {

        private Type pageType;
        private string title;
        private string description;

        public Type PageType
        {
            get
            {
                return pageType;
            }

            set
            {
                pageType = value;
                NotifyPropertyChanged("PageType");
            }
        }

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
                NotifyPropertyChanged("Title");
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
                NotifyPropertyChanged("Description");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
