using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Writter.Command;
using Tulpep.NotificationWindow;
using System.Windows.Media;
using Writter.dbo_Writter;
using Writter.Models.UnitOfWork;

namespace Writter.ViewModels
{
    class TodoViewModel : BaseViewModel
    {
        #region Private Fields
        WritterModel db = new WritterModel();
        private DateTime? dateTime;
        private string content;
        private int index;
        private ObservableCollection<NOTE> _noteTODO = TodoViewModel.GetTODO();
        private PopupNotifier notifier = null;
      
      


        #endregion

        #region Public Fields 

        public USERS user = HomePage.uSERS1;
        public ObservableCollection<NOTE> AllTODO
        {
            get { return _noteTODO; }
            set
            {
                _noteTODO = value;
                OnPropertyChanged("AllTODO");
            }
        }
        public DateTime? DateTimes
        {
            get => dateTime;
            set
            {
                dateTime = value;
                OnPropertyChanged();
            }
        }
        public string ContentTodo
        {
            get => content;
            set
            {
                content = value;
                OnPropertyChanged("ContentTodo");
            }
        }
        public int Select_TODO_Element
        {
            get => index;
            set
            {
                index = value;
                OnPropertyChanged("Select_TODO_Element");
            }
        }
        public static ObservableCollection<NOTE> GetTODO()
        {
            ObservableCollection<NOTE> result = new ObservableCollection<NOTE>();
            try
            {
                
                using (WritterModel db = new WritterModel())
                {

                    
                    USERS temp = HomePage.uSERS1;
                    var res = db.NOTE.Where(item => item.LOGIN_USER == temp.LOGIN &&
                                             item.TYPE_NOTE == Type_Note.Todo_List.ToString());
                    foreach (var i in res)
                    {
                        result.Add(i);
                    }
                   
                }
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return result;
        }
        #endregion

        #region Command
       
      

        private RelayCommand clearCommand;
        public RelayCommand ClearCommand => this.clearCommand ??
                      (clearCommand = new RelayCommand(obj =>
                      {
                          DateTimes = null;
                          ContentTodo = null;

                      }));

        private RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return saveCommand ??
                    (saveCommand = new RelayCommand(obj =>
                     {
                         try
                         {
                             //if (!(DateTimes is DateTime) || !(DateTimes is DateTime?))
                             //    throw new Exception("Enter correct Date");
                             if (ContentTodo == null)
                                 throw new Exception("Enter Todo-note");
                             if (ContentTodo.Length > 50) throw new Exception("Note can be no more than 50 characters");
                            
                             foreach(var i in _noteTODO)
                             {
                                 if(i.NAME_OF_NOTE== content)
                                 {
                                     throw new Exception("Note with the same name already exists");
                                 }
                             }
                             using(WritterModel db = new WritterModel())
                             {
                                 NOTE note = new NOTE
                                 {
                                     LOGIN_USER=user.LOGIN,
                                     DATE_CREATE= DateTimes,
                                     NAME_OF_NOTE= ContentTodo,
                                     TYPE_NOTE = Type_Note.Todo_List.ToString(),
                                 };
                                 db.NOTE.Add(note);
                                 var tmp = note;
                                 //var idNote = db.NOTEs.ToList();
                                 //foreach (NOTE notes in idNote)
                                 //{
                                 //    if (user.LOGIN == notes.LOGIN_USER)
                                 //        note = notes;
                                 //}
                                 STYLE style = new STYLE
                                 {
                                     FONTFAMILY = "Lato",
                                     FONTSIZE = 20,
                                     FOREGROUND = "Color[DarkPink]",
                                   
                                     ID_NOTE = tmp.ID_NOTE,
                                     NOTE=note
                                 };
                                 db.STYLE.Add(style);
                                 db.SaveChanges();

                                 _noteTODO.Add(note);
                                 
                                 MessageBox.Show("Task Add!");
                                 db.Dispose();
                             }
                            
                         }
                         catch(Exception e)
                         {
                             MessageBox.Show(e.Message);
                         }
                     }));
            }
            
        }

        private RelayCommand _openComman;
        public RelayCommand OpenTODO => this._openComman ?? (
                            _openComman = new RelayCommand(obj =>
                            {
                                if (Select_TODO_Element > 0)
                                {
                                    DateTimes = _noteTODO[Select_TODO_Element].DATE_CREATE;
                                    ContentTodo = _noteTODO[Select_TODO_Element].NAME_OF_NOTE;
                                }
                            }));

    
        private RelayCommand deleteCommand;
        public RelayCommand DeleteTODO
        {
            get => deleteCommand ?? (
                deleteCommand = new RelayCommand(obj =>
                {
                   
                        if (Select_TODO_Element > 0)
                        {
                            using(WritterModel db= new WritterModel())
                            {
                                try 
                                {
                                NOTE Note_Remove = _noteTODO[Select_TODO_Element] as NOTE;
                                NOTE removeNot = new NOTE();
                                STYLE style_remove = new STYLE();
                                if (Note_Remove != null)
                                {
                                    removeNot = db.NOTE.Where(x => x.ID_NOTE == Note_Remove.ID_NOTE).FirstOrDefault();
                                    style_remove = db.STYLE.Where(x => x.ID_NOTE == removeNot.ID_NOTE).FirstOrDefault();
                                    if (removeNot != null)
                                    {
                                        // db.NOTEs.Remove(Note_Remove);
                                        db.STYLE.Remove(style_remove);
                                        db.NOTE.Remove(removeNot);

                                        db.SaveChanges();
                                        _noteTODO.RemoveAt(Select_TODO_Element);
                                        db.Dispose();
                                        MessageBox.Show("Data deleted successfully");
                                    }

                                }

                            }
                                catch  (Exception e)
                                 {
                                MessageBox.Show(e.Message);
                                 }
                             }

                        }
                    
                }));
        }

        #endregion
    }
}
