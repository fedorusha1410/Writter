using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using Writter.Command;
using Writter.Models.UnitOfWork;

namespace Writter.ViewModels
{
    class SettingViewModel : BaseViewModel
    {
        USER uSER = new USER();
        NOTE nOTE = new NOTE();
        private BitmapImage _imagePath;
        string message;
        private USER _user = HomePage.uSERS1;
        private string _name = HomePage.uSERS1.NAME;
        private string _login = HomePage.uSERS1.LOGIN;
        private string _password;
        private string _newPassword;
       
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }
        public string NewPassword
        {
            get => _newPassword;
            set
            {
                _newPassword = value;
                OnPropertyChanged();
            }
        }
        public string Name1 { get => _name; set => _name = value; }

        private RelayCommand renameProperties;
        public RelayCommand RenameProperties
        {
            get
            {
                return renameProperties ??
                    (renameProperties = new RelayCommand(obj =>
                    {
                        try
                        {
                            var tmp = USER.getHash(Password);
                            var newPass = USER.getHash(NewPassword);
                            UnitOfWork unitOfWork = new UnitOfWork();
                            HomePage.nameLatter = Name;
                            _user.PASSWORD = tmp;
                            uSER = unitOfWork.User.GetByLogin(_user.LOGIN, tmp);

                            if (uSER != null)
                            {
                                if (NewPassword != null )
                                {
                                    HomePageViewModel._name[0] = Name;
                                    uSER.PASSWORD = newPass;
                                    uSER.NAME = Name;
                                    message = unitOfWork.User.Update(uSER);
                                    MessageBox.Show(message);
                                }
                                else
                                {
                                    HomePageViewModel._name[0] = Name;
                                    message = unitOfWork.User.UpdateName(uSER, Name);
                                    MessageBox.Show(message);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Check the data!");
                            }
                            
                            //using (WritterModel db = new WritterModel())
                            //{

                            //    uSER = null;
                            //    nOTE = null;
                            //    uSER = db.USERS.Where(b => b.PASSWORD == tmp).FirstOrDefault();
                            //    if (uSER != null)
                            //    {
                            //        nOTE = db.NOTEs.Where(x => x.LOGIN_USER == uSER.LOGIN).FirstOrDefault();
                            //        if (nOTE != null)
                            //        {

                            //            uSER.NAME = Name;
                            //            var temp = USER.getHash(NewPassword);
                            //            uSER.PASSWORD = temp;

                            //            db.SaveChanges();
                            //            MessageBox.Show("Data changed successfully!!");
                            //        }

                            //    }
                            //}



                        }
                        catch(Exception e)
                        {
                            MessageBox.Show(e.Message);
                        }
                    }));
            }
        }

        public BitmapImage ImagePath
        {
            get { return _imagePath; }
            set
            {
                _imagePath = value;
                OnPropertyChanged("ImagePath");
            }
        }

        private RelayCommand addImage;
        public RelayCommand AddImage
        {
            get
            {
                return addImage ?? (addImage = new RelayCommand(obj =>
                 {
                     try
                     {
                         var dlg = new OpenFileDialog()
                         {
                             Multiselect = true,
                             Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf"

                         };
                         
                         if (dlg.ShowDialog() == true)
                         {
                             ImagePath = new BitmapImage(new Uri(dlg.FileName, UriKind.Absolute));
                             string tmp = Convert.ToString(dlg.FileName);
                             HomePageViewModel._image[0] = tmp;
                             HomePage._image[0] = tmp;
                             UnitOfWork unitOfWork = new UnitOfWork();
                             unitOfWork.User.RefactorPhoto(_user.LOGIN, tmp);
                          


                         }
                     }
                     catch (Exception e)
                     {
                         MessageBox.Show(e.Message);
                     }
                 }
                ));
            }
        }
    }
}
