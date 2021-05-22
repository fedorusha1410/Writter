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
                USERS temp = HomePage.uSERS1;
                UnitOfWork unitOfWork = new UnitOfWork();
                result = unitOfWork.Note.GetNotesWithTyle(Type_Note.Todo_List.ToString(), temp);
                //using (WritterModel db = new WritterModel())
                //{

                    
                //    USERS temp = HomePage.uSERS1;
                //    var res = db.NOTE.Where(item => item.LOGIN_USER == temp.LOGIN &&
                //                             item.TYPE_NOTE == Type_Note.Todo_List.ToString());
                //    foreach (var i in res)
                //    {
                //        result.Add(i);
                //    }
                   
                //}
                
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
                             if (ContentTodo == null || DateTimes == null)
                                 throw new Exception("Enter date and todo, please ");
                             if (DateTimes.Value.ToString().Length==0)
                                 throw new Exception("Enter Date please!");
                             if (ContentTodo.Length > 50) throw new Exception("Note can be no more than 50 characters");
                            
                             foreach(var i in _noteTODO)
                             {
                                 if(i.NAME_OF_NOTE== content)
                                 {
                                     throw new Exception("Note with the same name already exists");
                                 }
                             }
                             UnitOfWork unitOfWork = new UnitOfWork();
                             NOTE note = new NOTE
                             {
                                 LOGIN_USER = user.LOGIN,
                                 DATE_CREATE = DateTimes,
                                 NAME_OF_NOTE = ContentTodo,
                                 TYPE_NOTE = Type_Note.Todo_List.ToString(),
                             };
                             unitOfWork.Note.Create(note);
                             STYLE style = new STYLE
                             {
                                 FONTFAMILY = "Lato",
                                 FONTSIZE = 20,
                                 FOREGROUND = "Color[DarkPink]",

                                 ID_NOTE = note.ID_NOTE,
                                 NOTE = note
                             };
                             unitOfWork.Style.Create(style);
                             _noteTODO.Add(note);
                             //using (WritterModel db = new WritterModel())
                             //{
                             //    NOTE note = new NOTE
                             //    {
                             //        LOGIN_USER=user.LOGIN,
                             //        DATE_CREATE= DateTimes,
                             //        NAME_OF_NOTE= ContentTodo,
                             //        TYPE_NOTE = Type_Note.Todo_List.ToString(),
                             //    };
                             //    db.NOTE.Add(note);
                             //    var tmp = note;
                             //     STYLE style = new STYLE
                             //    {
                             //        FONTFAMILY = "Lato",
                             //        FONTSIZE = 20,
                             //        FOREGROUND = "Color[DarkPink]",
                                   
                             //        ID_NOTE = tmp.ID_NOTE,
                             //        NOTE=note
                             //    };
                             //    db.STYLE.Add(style);
                             //    db.SaveChanges();

                             //    _noteTODO.Add(note);
                                 
                             //    MessageBox.Show("Task Add!");
                             //    db.Dispose();
                             //}
                            
                         }
                         catch(Exception e)
                         {
                           
                             MessageBox.Show(e.Message, "Writter" , MessageBoxButton.OK, MessageBoxImage.Warning); 
                            
                         }
                     }));
            }
            
        }

        private RelayCommand _openComman;
        public RelayCommand OpenTODO => this._openComman ?? (
                            _openComman = new RelayCommand(obj =>
                            {
                                if (Select_TODO_Element >= 0)
                                {
                                    NOTE Note_open = _noteTODO[Select_TODO_Element] as NOTE;
                                    DateTimes = Note_open.DATE_CREATE;
                                    ContentTodo = Note_open.NAME_OF_NOTE;
                                }
                            }));

    
        private RelayCommand deleteCommand;
        public RelayCommand DeleteTODO
        {
            get => deleteCommand ?? (
                deleteCommand = new RelayCommand(obj =>
                {
                   
                        if (Select_TODO_Element >= 0)
                        {
                        UnitOfWork unitOfWork = new UnitOfWork();
                        NOTE Note_Remov = _noteTODO[Select_TODO_Element] as NOTE;
                        NOTE GetNoteForDelet = unitOfWork.Note.Get(Note_Remov.ID_NOTE);
                        var GetStyle = unitOfWork.Style.Get(Note_Remov.ID_NOTE);
                        int id = GetStyle.ID_STYLE_NOTE;
                        unitOfWork.Note.Delete(GetNoteForDelet.ID_NOTE);
                        unitOfWork.Style.Delete(id);
                        _noteTODO.Remove(Note_Remov);
                        MessageBox.Show("Data deleted successfully");

                        //using (WritterModel db= new WritterModel())
                        //    {
                        //        try 
                        //        {
                        //        NOTE Note_Remove = _noteTODO[Select_TODO_Element] as NOTE;
                        //        NOTE removeNot = new NOTE();
                        //        STYLE style_remove = new STYLE();
                        //        if (Note_Remove != null)
                        //        {
                        //            removeNot = db.NOTE.Where(x => x.ID_NOTE == Note_Remove.ID_NOTE).FirstOrDefault();
                        //            style_remove = db.STYLE.Where(x => x.ID_NOTE == removeNot.ID_NOTE).FirstOrDefault();
                        //            if (removeNot != null)
                        //            {
                        //                // db.NOTEs.Remove(Note_Remove);
                        //                db.STYLE.Remove(style_remove);
                        //                db.NOTE.Remove(removeNot);

                        //                db.SaveChanges();
                        //                _noteTODO.RemoveAt(Select_TODO_Element);
                        //                db.Dispose();
                        //                MessageBox.Show("Data deleted successfully", "Writter", MessageBoxButton.OK, MessageBoxImage.Information);
                        //            }

                        //        }

                        //    }
                        //        catch  (Exception e)
                        //         {
                        //        MessageBox.Show(e.Message, "Writter", MessageBoxButton.OK, MessageBoxImage.Warning);
                        //    }
                        //     }

                        }
                    
                }));
        }

        #endregion
    }
}
