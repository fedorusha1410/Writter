using DocumentFormat.OpenXml.Bibliography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Writter.Command;
using Writter.View.Pages;

namespace Writter.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        private Page SimpleNote;
        private Page TaskList;
        private Page TODO;
        private Page CurrentPage;
        private Page Goal;

        public MainViewModel()
        {
            SimpleNote = new SimpleNote();
            TaskList = new Goal();
            TODO = new TODO();
            CurrentPage.Visibility= System.Windows.Visibility.Visible;

        }

       

        
    }
}
