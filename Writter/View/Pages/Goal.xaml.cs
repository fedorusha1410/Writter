using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Writter.ViewModels;

namespace Writter.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для Goal.xaml
    /// </summary>
    public partial class Goal : Page
    {
        public Goal()
        {
            InitializeComponent();
            this.DataContext = new GoalViewModel();
        }
    }
}
