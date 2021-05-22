using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Writter.dbo_Writter;
using Writter.ViewModels;

namespace Writter
{
    /// <summary>
    /// Логика взаимодействия для Setting.xaml
    /// </summary>
    public partial class Setting : Window
    {      
        public Setting(USERS uSERS)
        {
            InitializeComponent();
            this.DataContext = new SettingViewModel();
        }       
    }
}
