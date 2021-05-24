using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Writter.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Threading.Tasks;
using Writter.Command;
using System.Windows;
using System.Drawing;
using Writter.dbo_Writter;
using System.Data.Entity;
using System.ComponentModel;
using Writter.Models.UnitOfWork;

namespace Writter.ViewModels
{
    class AdminViewModel : BaseViewModel
    {

        #region Private Field
        private int index;
        private USER admin = HomePage.uSERS1;
        
        UnitOfWork unitOfWork1 = new UnitOfWork();
        private ObservableCollection<USER> _users;
        private void InitUsers()
        {
            foreach(var item in unitOfWork1.User.GetAll())
            {
                _users.Add(item);
                OnPropertyChanged();
            }
        }


        #endregion

        WritterModel db = new WritterModel();
        public int Index
        {
            get => index;
            set
            {
                index = value;
                OnPropertyChanged();

            }
        }
        public ObservableCollection<USER> AllUsers
        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChanged();

            }
        }
        string Message;
        public AdminViewModel()
        {
            _users = new ObservableCollection<USER>();
            InitUsers();
         
        }

        #region Command

        public DelegateCommand ExitToLogIn
        {
            get => new DelegateCommand((i) =>
            {
                var values = (i as object[]);
                var adminWindow = values[0] as Window;

                try
                {
                    
                    adminWindow.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            });
        }

        public DelegateCommand Close
        {
            get => new DelegateCommand((i) =>
            {
                var values = (i as object[]);
                var adminWindow = values[0] as Window;
                try
                {
                    USER uSERS = unitOfWork1.User.GetByLogin("admin", "11111");

                    HomePage homePage = new HomePage(admin.NAME, admin);
                    homePage.UserInformation.Visibility = Visibility.Visible;
                    homePage.Show();
                    adminWindow.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            });
        }

        private RelayCommand deleteUser;
        public RelayCommand DeleteUser
        {
            get => deleteUser ?? (deleteUser = new RelayCommand(obj =>
            {
                try
                {
                   
                    USER _user = AllUsers[Index];
                    var getUserByLogin = db.USERS.Find(_user.LOGIN);
                    foreach (var i in db.NOTEs)
                    {
                        foreach (var j in db.STYLEs)
                        {
                            if (i.LOGIN_USER == getUserByLogin.LOGIN && i.ID_NOTE == j.ID_NOTE)
                            {
                                db.STYLEs.Remove(j);
                                db.NOTEs.Remove(i);
                            }
                        }

                    }
                   
                                db.USERS.Remove(getUserByLogin);
                                _users.Remove(_user);
                                db.SaveChanges();
                    MessageBox.Show("User deleted successfully!");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }));
        }

   

        private RelayCommand blockUser;
        public RelayCommand BlockUser
        {
            get => blockUser ?? (
                blockUser = new RelayCommand(obj =>
                 {
                     try
                     {
                         UnitOfWork unitOfWork = new UnitOfWork();
                         USER _user = AllUsers[Index];
                       //  var getUserByLogin = unitOfWork.User.GetByLogin(_user.LOGIN, _user.PASSWORD);
                              
                         Message = unitOfWork.User.UpdateStatus(_user);




                         AllUsers.Clear();
                         AllUsers = unitOfWork.User.GetAllUser();
                         MessageBox.Show(Message);
                      
                     }
                     catch (Exception e)
                     {
                         MessageBox.Show(e.Message);
                     }

                 }));
        }
        #endregion




    }
}
