using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Writter.Help
{
    class Data : INotifyPropertyChanged
    {
        private FontFamily fontFamily = new FontFamily("Times New Roman");
        public FontFamily _FontFamily
        {
            get
            {
                return fontFamily;
            }
            set
            {
                fontFamily = value;
                OnPropertyChanged(new PropertyChangedEventArgs("_FontFamily"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }
    }
}
