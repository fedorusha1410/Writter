using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Writter.Command;
using Writter.Models.dbo_Writter;
using Writter.Models.UnitOfWork;

namespace Writter.ViewModels
{
    class LogInViewModel : BaseViewModel
    {
        USER user;
        HomePage home;
        private string _login;
        string symbol;
        
        public static TreeViewItem TreeView= new TreeViewItem();
        public static string Latter;
        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged();
            }
        }
        
        public DelegateCommand LogInCommand
        {
            get => new DelegateCommand((i) =>
            {
                var values = (i as object[]);
                var logInWindow = values[0] as Window;



               
                try
                {

                    if (Login == "admin" && (values[1] as PasswordBox).Password == "11111")
                    {

                        USER userAdmin = new USER();


                        using (WritterModel context = new WritterModel())
                        {

                            userAdmin = context.USERS.Where(item => item.LOGIN == Login).FirstOrDefault();
                        }
                        if (userAdmin != null)
                        {
                            user = userAdmin;
                            symbol = userAdmin.NAME;
                            home = new HomePage(symbol, user);
                            home.UserInformation.Visibility = Visibility.Visible;
                            home.Show();

                            logInWindow.Close();
                        }

                    }
                    else
                    {
                        var passwordBoxOnw = USER.getHash((values[1] as PasswordBox).Password);
                        USER authUser = null;
                        UnitOfWork unitOfWork = new UnitOfWork();
                        authUser = unitOfWork.User.GetByLogin(Login, passwordBoxOnw);
                        if (authUser != null)
                        {

                            user = authUser;
                            symbol = authUser.NAME;
                            home = new HomePage(symbol, user);
                            home.UserInformation.Visibility = Visibility.Collapsed;
                            home.Show();
                            logInWindow.Close();
                        }
                        else { throw new Exception("No such user exists"); }
                    }
                 
                    //using (WritterModel db = new WritterModel())
                    //{
                    //    authUser = db.USERS.Where(b => b.LOGIN == Login && b.PASSWORD == passwordBoxOnw && b.STATUS_USER==StatusUser.Active.ToString()).FirstOrDefault();
                   
                    //if (authUser != null)
                    //{
                       
                    //    user = authUser;
                    //    symbol = authUser.NAME;
                    //    home = new HomePage(symbol, user);
                    //    home.UserInformation.Visibility = Visibility.Collapsed;
                    //    home.Show();
                    //    logInWindow.Close();
                    //}
                    //else throw new Exception("No such user exists");
                    //}
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                ///ВАЛИДАЦИЯ 

            });
        }

        public DelegateCommand GetSignUpWindow
        {
            get => new DelegateCommand((i) =>
            {
                var values = (i as object[]);
                var logInWindow = values[0] as Window;

                try
                {
                    //буква имени
                    new MainWindow().Show();
                    logInWindow.Close();
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
