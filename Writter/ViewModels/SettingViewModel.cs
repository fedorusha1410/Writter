using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Writter.Command;
using Writter.Models.UnitOfWork;

namespace Writter.ViewModels
{
    class SettingViewModel : BaseViewModel
    {
        USERS uSER = new USERS();
        NOTE nOTE = new NOTE();
        string message;
        private USERS _user = HomePage.uSERS1;
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
                            var tmp = USERS.getHash(Password);
                            var newPass = USERS.getHash(NewPassword);
                            UnitOfWork unitOfWork = new UnitOfWork();
                            _user.PASSWORD = tmp;
                            uSER = unitOfWork.User.GetByLogin(_user.LOGIN, tmp);
                            if (uSER != null)
                            {
                                if (NewPassword != null )
                                {
                                    message = unitOfWork.User.Update(uSER);
                                    uSER.PASSWORD = newPass;
                                    MessageBox.Show(message);
                                }
                                else
                                {
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

    }
}
