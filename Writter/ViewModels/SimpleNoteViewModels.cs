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
    public class SimpleNoteViewModels : BaseViewModel
    {
        #region Private Fields
        NOTE note;
        string Message;
        string StyleMessage;
        STYLE _style;
        private USERS _user = HomePage.uSERS1;
        static ObservableCollection<NOTE> _notesSimple;
        private string _contentNote;
        static string _fontfamily = "Montserrat_Light";
        static string _foreground = Color.Black.ToString();
        private int index;
        private string name_of_Note;
        private int indexSize;
        private List<int> fontSizeSelect = new List<int> { 14, 16, 18, 22, 26, 30, 32, 36, 38 };
        #endregion 

        #region Public Properties
        public int SelectElementIndex
        {
            get => index;
            set
            {
                index = value;
                OnPropertyChanged("SelectElementIndex");
            }
        }
        public string Name_Of_SimpleNote
        {
            get => name_of_Note;
            set
            {
                name_of_Note = value;
                OnPropertyChanged();
            }
        }
        public SimpleNoteViewModels()
        {
            _notesSimple = new ObservableCollection<NOTE>();
            GetSimpleNote();
        }
        public ObservableCollection<NOTE> AllSimpleNote
        {
            get { return _notesSimple; }
            set
            {
                _notesSimple = value;
                OnPropertyChanged();
            }
        }
        public List<int> FontSizeSelect
        {
            get => fontSizeSelect;
            set
            {
                fontSizeSelect = value;
                OnPropertyChanged("FontSizeSelect");
            }
        }
        public int IndexSizeFont
        {
            get => FontSizeSelect[indexSize];
            set
            {
                indexSize = value;

                OnPropertyChanged("IndexSizeFont");
            }
        }
        public string ContentInfo
        {
            get
            {
                return _contentNote;
            }
            set
            {
                _contentNote = value;
                this.OnPropertyChanged();
            }
        }
        #endregion

        #region Command
        static RelayCommand _saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return _saveCommand ??
                    (_saveCommand = new RelayCommand( obj =>
                      {
                          try
                          {
                              if(_contentNote == null  ||
                                name_of_Note == null   || 
                                name_of_Note.Length==0 ||
                                _contentNote.Length==0)

                              {
                                  throw new Exception("Fill in the blank fields");
                              }
                              if (ContentInfo.Length > 1000)
                                  throw new Exception("Max Length is 1000 characters!");
                                 
                              
                              foreach(var i in _notesSimple)
                              {
                                  if(i.NAME_OF_NOTE== name_of_Note)
                                  {
                                      throw new Exception("Note with the same name already exists");
                                  }
                              }

                                  note = new NOTE
                                  {
                                      LOGIN_USER = _user.LOGIN,
                                      CONTENT = ContentInfo,
                                      DATE_CREATE = DateTime.Now.Date,
                                      NAME_OF_NOTE= Name_Of_SimpleNote,
                                      TYPE_NOTE = Type_Note.Simple_Note.ToString(),

                                  };
                                  UnitOfWork unitOfWork = new UnitOfWork();
                                  Message = unitOfWork.Note.Create(note);
                                 
                                  //db.NOTEs.Add(note);
                                  //db.SaveChanges();
                                  //var idNote = db.NOTEs.ToList();                             
                                  var tmp = note;
                                  int temp = IndexSizeFont;
                                      _style = new STYLE
                                      {
                                          FONTFAMILY = _fontfamily,
                                          FONTSIZE = IndexSizeFont,
                                          FOREGROUND = _foreground,
                                         
                                          ID_NOTE = tmp.ID_NOTE,

                                      };
                                 StyleMessage= unitOfWork.Style.Create(_style);
                                 // db.STYLEs.Add(_style);
                                  //db.SaveChanges();

                                 _notesSimple.Add(note);
                                  MessageBox.Show(Message+StyleMessage);

                              

                          } catch (Exception e)
                          {
                              MessageBox.Show(e.Message );
                          }
                      }));

            }
        }

        private RelayCommand _clearCommand;
        public RelayCommand ClearCommand => this._clearCommand ??
                        (_clearCommand = new RelayCommand(obj =>
                        {
                            ContentInfo = null;
                            Name_Of_SimpleNote = null;
                           

                        }));


        private RelayCommand _openComman;
        public RelayCommand OpenTask => this._openComman ?? (
                            _openComman = new RelayCommand(obj =>
                              {
                                  if (SelectElementIndex > 0)
                                  {
                                      ContentInfo = _notesSimple[SelectElementIndex].CONTENT;
                                      Name_Of_SimpleNote = _notesSimple[SelectElementIndex].NAME_OF_NOTE;
                                  }
                              }));

        private RelayCommand _deleteCommand;
        public RelayCommand DeleteTask => this._deleteCommand ?? (
            _deleteCommand = new RelayCommand(obj =>
             {
                 if (SelectElementIndex > 0)
                 {
                     
                         UnitOfWork unitOfWork = new UnitOfWork();
                         NOTE Note_Remov = _notesSimple[SelectElementIndex] as NOTE;
                         NOTE GetNoteForDelet = unitOfWork.Note.Get(Note_Remov.ID_NOTE);
                         var GetStyle = unitOfWork.Style.Get(Note_Remov.ID_NOTE);
                         int id = GetStyle.ID_STYLE_NOTE;
                         unitOfWork.Note.Delete(GetNoteForDelet.ID_NOTE);
                         unitOfWork.Style.Delete(id);
                         AllSimpleNote.Remove(Note_Remov);
                         MessageBox.Show("Data deleted successfully");

                 }
             }));


        private RelayCommand _sort;
        public RelayCommand SortByDate
        {
            get => _sort ?? (_sort = new RelayCommand(obj =>
               {
                   try
                   {
                        using(WritterModel db= new WritterModel())
                        {
                           USERS temp = HomePage.uSERS1;
                           //var res = db.NOTEs.Where(item => item.LOGIN_USER == temp.LOGIN &&
                           //                        item.TYPE_NOTE == Type_Note.Simple_Note.ToString());

                           AllSimpleNote = new ObservableCollection<NOTE>(db.NOTE.Where(i => i.TYPE_NOTE == Type_Note.Simple_Note.ToString() && i.LOGIN_USER == temp.LOGIN)
                                                                            .OrderBy(i => i.NAME_OF_NOTE));
                           
                        }
                   }
                   catch(Exception e)
                   {
                       MessageBox.Show(e.Message);
                   }
               }));
        }

        private RelayCommand _refactor;
        public RelayCommand RefactorSize => this._refactor ?? (
            _refactor = new RelayCommand(obj =>
            {
                if (IndexSizeFont > 0)
                {
                    int tempSize = FontSizeSelect[IndexSizeFont];
                    indexSize = tempSize;
                }
            }));

        //ВЫВОД SimpleNote 
        private  void GetSimpleNote()
        {
           
            try
            {
                using (WritterModel db = new WritterModel())
                {
                    USERS temp = HomePage.uSERS1;
                    var res = db.NOTE.Where(item => item.LOGIN_USER == temp.LOGIN &&
                                             item.TYPE_NOTE == Type_Note.Simple_Note.ToString());
                    foreach (var i in res)
                    {
                        _notesSimple.Add(i);
                      
                    }
                   
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
           
           


        }


        #endregion
    }
}
