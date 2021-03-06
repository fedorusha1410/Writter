using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Tulpep.NotificationWindow;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Writter.dbo_Writter;
using Writter.View.Pages;
using Writter.ViewModels;
using System.Threading;
using Writter.Models.UnitOfWork;
using System.ComponentModel;
using JetBrains.Annotations;
using System.Runtime.CompilerServices;

namespace Writter
{
    /// <summary>
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
       public static string nameLatter;
        string UpLetter;
        static string login_name;
        public static  USER uSERS1;
        private ObservableCollection<NOTE> note;
   

        public static ObservableCollection<string> _image;

        public ObservableCollection<string> _Image
        {
            get => _image;
            set
            {
                _image = value;
                OnPropertyChanged("_Image");
            }
        }

        //public static ObservableCollection<string> image;

        //public ObservableCollection<string> Image
        //{
        //    get => image;
        //    set
        //    {
        //        image = value;
        //        OnPropertyChanged("Image");

        //    }
        //}

        public HomePage(string latter, USER uSERS)
        {
            _image = new ObservableCollection<string> {""};
            nameLatter = latter;
            uSERS1 = uSERS;
            login_name = uSERS.LOGIN;
            InitializeComponent();
            if (uSERS1.PHOTO != null && uSERS1.PHOTO!="false")
            {
                Latter.Visibility = Visibility.Collapsed;
            }
            DataContext = new HomePageViewModel(_image, uSERS1);
           
           
            UpLetter = nameLatter.Substring(0, 1);
                Latter.Text = UpLetter.ToUpper();
           // Users_name.Text = nameLatter + "'s Writter";
            note = new ObservableCollection<NOTE>();

            try
            {
                UnitOfWork unitOfWork = new UnitOfWork();
                note = unitOfWork.Note.GetNotesWithTyle(Type_Note.Todo_List.ToString(), uSERS1);

                foreach (var i in note)
                {
                    PopupNotifier notifier = new PopupNotifier();
                    notifier.Image = Properties.Resources.icon;

                    notifier.ImageSize = new System.Drawing.Size(50, 50);
                    notifier.TitleText = "TO DO | Notification";
                    var x = DateTime.Now;
                    var y = (DateTime)i.DATE_CREATE;
                    var z = (y - x).TotalDays;

                    if (z <= 2 && z>0)
                    {
                        notifier.ContentText = "Nearest event:  " + i.NAME_OF_NOTE + " in " + Convert.ToInt32(z) + " days";
                        //Thread.Sleep(500);
                        notifier.Popup();

                    }
                    Thread.Sleep(2000);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           

        }
        #region Pages
        private void Simlpe_Note_Click(object sender, RoutedEventArgs e) {  Note.Navigate(new SimpleNote());   }
        private void Blog(object sender, RoutedEventArgs e) { Note.Navigate(new BlogPost()); }
        private void Todo(object sender, RoutedEventArgs e) {  Note.Navigate(new TODO());  }
        private void Goals(object sender, RoutedEventArgs e) { Note.Navigate(new Goal()); }
        #endregion
        #region AllMethodHelper
        private void AddAllComponent(object sender, RoutedEventArgs e)
        {
            //string nameUser = Users_name.Text.Substring(0,1);
            //Latter.Text = UpLetter.ToUpper();
            Users_name.Text = nameLatter + "'s Writter";
        }
        private void OpenSetting(object sender, RoutedEventArgs e)
        {
            
            foreach(Window win in Application.Current.Windows)
            {
                if (win.GetType() == typeof(Setting) ) win.Close();
            }
            Setting setting = new Setting(uSERS1);
            if (uSERS1.LOGIN == "admin")
            {
                setting.DeleteAccount.Visibility = Visibility.Collapsed;
                setting.DangerZone.Visibility = Visibility.Collapsed;
            }
            setting.Show();
        }
        private void LogOutButton(object sender, RoutedEventArgs e)
        {
            MainWindow signUp = new MainWindow();
            signUp.Show();
            this.Hide();
        }

        #endregion

        private void Users(object sender, RoutedEventArgs e)
        {
            new WindowAdmin().Show();
            this.Hide();
            
        }
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        //private void Notification(object sender, RoutedEventArgs e)
        //{
        //    note = new ObservableCollection<NOTE>();
        //    try
        //    {
        //        using (WritterModel db = new WritterModel())
        //        {
        //            USER temp = uSERS1;
        //            var res = db.NOTEs.Where(item => item.LOGIN_USER == temp.LOGIN &&
        //                                     item.TYPE_NOTE == Type_Note.Todo_List.ToString());
        //            foreach (var i in res)
        //            {
        //                note.Add(i);

        //            }

        //        }
        //        foreach (var i in note)
        //        {
        //            PopupNotifier notifier = new PopupNotifier();
        //            notifier.Image = Properties.Resources.icon;

        //            notifier.ImageSize = new System.Drawing.Size(50, 50);
        //            notifier.TitleText = "TO DO | Notification";
        //            var x = DateTime.Now;
        //            var y = (DateTime)i.DATE_CREATE;
        //            var z = (y - x).TotalDays;

        //            if (z <=2)
        //            {
        //                notifier.ContentText = "Nearest event:  " + i.NAME_OF_NOTE + " in " + Convert.ToInt32(z) + " days";
        //                //Thread.Sleep(500);
        //                notifier.Popup();

        //            }
        //            Thread.Sleep(2000);
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
    }
}
