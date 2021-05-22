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
        private ObservableCollection<USERS> _users;
        private void InitUsers()
        {
            foreach(var item in db.USERS)
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
        public ObservableCollection<USERS> AllUsers
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
            _users = new ObservableCollection<USERS>();
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
                    USERS _user = AllUsers[Index];
                    var getUserByLogin = db.USERS.Find(_user.LOGIN);
                    foreach (var i in db.NOTE)
                    {
                        foreach (var j in db.STYLE)
                        {
                            if (i.LOGIN_USER == getUserByLogin.LOGIN && i.ID_NOTE == j.ID_NOTE)
                            {
                                db.NOTE.Remove(i);
                                db.STYLE.Remove(j);
                            }
                        }

                    }
                    db.USERS.Remove(getUserByLogin);
                    _users.Remove(getUserByLogin);
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
                         USERS _user = AllUsers[Index];
                         var getUserByLogin = db.USERS.Find(_user.LOGIN);
                              
                         Message = unitOfWork.User.UpdateStatus(getUserByLogin);
                                    
                                 
                             

                        
                         //db.USERS.Remove(getUserByLogin);
                         //_users.Remove(getUserByLogin);
                         //db.SaveChanges();
                         MessageBox.Show("User deleted successfully!");
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
