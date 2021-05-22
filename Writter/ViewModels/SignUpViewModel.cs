using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Writter.Command;
using Writter.dbo_Writter;
using Writter.Models.dbo_Writter;
using Writter.Models.UnitOfWork;

namespace Writter.ViewModels
{
    class SignUpViewModel :BaseViewModel
    {
        USERS _user;
        NOTE _note = new NOTE();
        STYLE _style = new STYLE();
        HomePage home;
        private string _login;
        string message;
        private string _name;
        private string _passwordOne;
        private string _passwordTwo;
        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged();
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public static TreeViewItem TreeView = new TreeViewItem();

        public static string Latter;
        public string Password
        {
            get => _passwordOne;
            set
            {
                _passwordOne = value;
                OnPropertyChanged();
            }
        }
        public string PasswordTwo
        {
            get => _passwordTwo;
            set
            {
                _passwordTwo = value;
                OnPropertyChanged();
            }
        }
        public string symbol;

        public DelegateCommand CreateAccount
        {
            get => new DelegateCommand((i) =>
              {
                  var values = (i as object[]);
                  var signUpWimdow = values[0] as Window;
 
                  try
                  {
                      if (Name== null || Login==null||
                      (values[1] as PasswordBox).Password==null ||
                      (values[2] as PasswordBox).Password==null) throw new Exception("Fill in all the data for registration");
                      if ((values[1] as PasswordBox).Password.Length > 20 ||
                     (values[2] as PasswordBox).Password.Length > 20) throw new Exception("Password must be no more than 20 characters");

                      var pass1 = USERS.getHash((values[1] as PasswordBox).Password);
                      var pass2 = USERS.getHash((values[2] as PasswordBox).Password);
                      
                         UnitOfWork context = new UnitOfWork();
                          if (!pass1.Equals(pass2)) throw new Exception("Password mismatch!!!!");
                          //foreach(USER user in db.USERS)
                          //{
                          //    if (user.LOGIN.Equals(Login)) throw new Exception("User with this login already exists");
                          //}
                          _user = new USERS
                          {
                              NAME = Name,
                              LOGIN = Login,
                              PHOTO = "true",
                              TYPE_USER = Type_User.User.ToString(),
                              PASSWORD = pass1,
                              STATUS_USER=StatusUser.Active.ToString()
                          };
                          UnitOfWork unitOfWork = new UnitOfWork();
                          message = unitOfWork.User.Create(_user);
                          MessageBox.Show(message);            
                      symbol = _user.NAME;
                      Latter = Name;
                      home = new HomePage(Latter, _user);
                      home.UserInformation.Visibility = Visibility.Hidden;
                      home.Show();
                      signUpWimdow.Close();
                  }catch(Exception ex)
                  {
                      MessageBox.Show(ex.Message);
                  }
                

            });


        }
        public DelegateCommand GetLogInWindow
        {
            get => new DelegateCommand((i) =>
            {
                var values = (i as object[]);
                var signUpWimdow = values[0] as Window;

                try
                {
                    
                    new MainWindowLog().Show();
                    signUpWimdow.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                ///ВАЛИДАЦИЯ 

            });
        }
    }
}
