using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Writter.Command;
using Writter.dbo_Writter;
using Writter.Models.UnitOfWork;

namespace Writter.ViewModels
{
    class GoalViewModel : BaseViewModel
    {
        #region Private Field
        private string goal;
        private int selectIndex;
        private string selectStatus;
        private USER _user = HomePage.uSERS1;
        private static ObservableCollection<NOTE> GetGoal()
        {
            var result = new ObservableCollection<NOTE>();
            try
            {
                USER temp = HomePage.uSERS1;
                UnitOfWork unitOfWork = new UnitOfWork();
                result = unitOfWork.Note.GetNotesWithTyle(Type_Note.Goal.ToString(), temp);
               
            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return result;

        }
        static string _foreground = Color.Black.ToString();
        static string _fontfamily = "Montserrat_Light";
        private string tell;
        private List<string> status = new List<string> {" ", "todo", "doing", "done" };
        private int index;
        #endregion

        #region Public Prop
        public string MyGoals
        {
            get => goal;
            set
            {
                goal = value;
                OnPropertyChanged("MyGoals");
            }
        }
        public string SelectedStatus
        {
            get => selectStatus;
            set
            {
                selectStatus = value;
                OnPropertyChanged("SelectedStatus");
            }
        }
        public int SelectIndex
        {
            get => selectIndex;
            set
            {
                selectIndex = value;
                OnPropertyChanged("SelectIndex");
            }
        }
        public string MyGoal
        {
            get => goal;
            set
            {
                goal = value;
                OnPropertyChanged("MyGoal");
            }
        }
        public static ObservableCollection<NOTE> _goals = GoalViewModel.GetGoal();
        public ObservableCollection<NOTE> AllGoals
        {
            get { return _goals; }
            set
            {
                _goals = value;
                OnPropertyChanged();
            }
        }
        public string GoalTell
        {
            get => tell;
            set
            {
                tell = value;
                OnPropertyChanged("GoalTell");
            }
        }
        public List<string> Status
        {
            get => status;
            set
            {
                status = value;
                OnPropertyChanged("Category");
            }



        }
        public int IndexStatus
        {
            get => index;
            set
            {
                index = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Command

        private RelayCommand save; 
        public RelayCommand SaveGoal
        {
            get
            {
                return save ??
                    (save = new RelayCommand(obj =>
                     {
                         try
                         {
                           //  USERS tempUser = _user;
                             if (goal==null)
                                 throw new Exception("Write name your goal");
                             if (IndexStatus== 0)
                                 throw new Exception("Change status Goal!");
                             foreach(var i in _goals)
                             {
                                 if(i.NAME_OF_NOTE== goal)
                                 throw new Exception("Goal with the same name already exists");
                                 
                             }
                             UnitOfWork unitOfWork = new UnitOfWork();
                             NOTE note = new NOTE
                             {
                                 LOGIN_USER = _user.LOGIN,
                                 DATE_CREATE = DateTime.Now,
                                 NAME_OF_NOTE = MyGoal,
                                 CONTENT = GoalTell,
                                 TYPE_NOTE = Type_Note.Goal.ToString(),

                             };
                             unitOfWork.Note.Create(note);
                             STYLE style = new STYLE
                             {
                                 ID_NOTE = note.ID_NOTE,

                                 FONTFAMILY = _fontfamily,
                                 FONTSIZE = 25,
                                 FOREGROUND = _foreground,
                                 STATUS = Status[IndexStatus],
                                 NOTE = note
                             };
                             unitOfWork.Style.Create(style);
                             _goals.Add(note);

                             //using (WritterModel db = new WritterModel())
                             //{
                             //    tempUser = db.USERS.Where(x => x.LOGIN == _user.LOGIN).FirstOrDefault();
                             //    if (tempUser != null)
                             //    {
                             //        NOTE note = new NOTE
                             //        {
                             //            LOGIN_USER = tempUser.LOGIN,
                             //            DATE_CREATE = DateTime.Now,
                             //            NAME_OF_NOTE = MyGoal,
                             //            CONTENT = GoalTell,
                             //            TYPE_NOTE = Type_Note.Goal.ToString(),

                             //        };
                             //        STYLE style = new STYLE
                             //        {
                             //            ID_NOTE = note.ID_NOTE,

                             //            FONTFAMILY = _fontfamily,
                             //            FONTSIZE = 25,
                             //            FOREGROUND = _foreground,
                             //            STATUS = Status[IndexStatus]
                             //        };
                             //        using (var transaction = db.Database.BeginTransaction())
                             //        {
                             //            try
                             //            {
                             //                db.NOTE.Add(note);
                             //                db.STYLE.Add(style);
                             //                db.SaveChanges();
                             //                transaction.Commit();
                             //            }
                             //            catch (Exception e)
                             //            {
                             //                transaction.Rollback();
                             //            }
                             //        }
                             //        var tmp = note;
                             //        //var idNote = db.NOTEs.ToList();
                             //        //foreach (NOTE notes in idNote)
                             //        //{
                             //        //    if (_user.LOGIN == notes.LOGIN_USER)
                             //        //        note = notes;
                             //        //}
                             //        //db.SaveChanges();
                             //        _goals.Add(note);
                             //    }
                             //}
                         } 
                         catch(Exception e)
                         {
                             MessageBox.Show(e.Message);
                         }
                     }));
            }
        }

        private RelayCommand clear;
        public RelayCommand ClearGoal
        {
            get
            {
                return clear ??
                    (clear = new RelayCommand(obj =>
                     {
                         MyGoals = null;
                         GoalTell = null;
                        IndexStatus=0;
                     }));
            }
        }

        private RelayCommand open;
        public RelayCommand OpenGoal
        {
            get
            {
                return open ??
                (open = new RelayCommand(obj =>
                 {
                     if (SelectIndex >= 0)
                     {
                         UnitOfWork unitOfWork = new UnitOfWork();
                         NOTE temp = _goals[SelectIndex] as NOTE;
                         STYLE styleTemp = unitOfWork.Style.GetIdNote(temp.ID_NOTE);

                         MyGoals = _goals[SelectIndex].NAME_OF_NOTE;
                         GoalTell = _goals[SelectIndex].CONTENT;
                         for (int i = 0; i < status.Count; i++)
                         {
                             if (status[i] == styleTemp.STATUS)
                             {
                                 IndexStatus = i;
                             }
                         }
                     }
                   
                    
                 }));
            }
        }

        private RelayCommand _deleteCommand;
        public RelayCommand DeleteTask => this._deleteCommand ?? (
            _deleteCommand = new RelayCommand(obj =>
            {
                if (SelectIndex >= 0)
                {
                    UnitOfWork unitOfWork = new UnitOfWork();
                    NOTE tmp = _goals[SelectIndex] as NOTE;
                    NOTE remove = unitOfWork.Note.Get(tmp.ID_NOTE);
                    unitOfWork.Style.Delete(remove.ID_NOTE);
                    unitOfWork.Note.Delete(remove.ID_NOTE);
                    MessageBox.Show("Data deleted successfully");
                    _goals.RemoveAt(SelectIndex);


                }
            }));

        #endregion

    }
}
