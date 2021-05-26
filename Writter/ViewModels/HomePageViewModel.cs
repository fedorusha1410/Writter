using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Writter.ViewModels
{
    class HomePageViewModel : BaseViewModel
    {
        public static ObservableCollection<string> _image= new ObservableCollection<string> { "/Resourses/empty.png" };

        public static ObservableCollection<string> _name = new ObservableCollection<string> { "User" };

        public ObservableCollection<string> Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public  ObservableCollection<string> Image
        {
            get => _image;
            set
            {
                _image = value;
                OnPropertyChanged("Image");
            }
        }
        public HomePageViewModel(ObservableCollection<string> image, USER user)
        {
            // _image.Clear();
            _name[0] = user.NAME;
            if (user.PHOTO != null)
            {
                _image[0] = user.PHOTO;
            } else
            {

            _image[0] = image[0];
            }

        }
    }
}
