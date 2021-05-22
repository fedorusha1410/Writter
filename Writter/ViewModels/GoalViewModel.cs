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
        private USERS _user = HomePage.uSERS1;
        private static ObservableCollection<NOTE> GetGoal()
        {
            var result = new ObservableCollection<NOTE>();
            try
            {
                using (WritterModel db = new WritterModel())
                {

                   
                    USERS temp = HomePage.uSERS1;
                    var res = db.NOTE.Where(item => item.LOGIN_USER == temp.LOGIN &&
                                             item.TYPE_NOTE == Type_Note.Goal.ToString());
                    foreach (var i in res)
                    {
                        result.Add(i);
                    }
                    
                }
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
                             USERS tempUser = null;
                             if (goal==null)
                                 throw new Exception("Write name your goal");
                             if (IndexStatus== 0)
                                 throw new Exception("Change status Goal!");
                             foreach(var i in _goals)
                             {
                                 if(i.NAME_OF_NOTE== goal)
                                 throw new Exception("Goal with the same name already exists");
                                 
                             }
                            using(WritterModel db= new WritterModel())
                             {
                                 tempUser = db.USERS.Where(x => x.LOGIN == _user.LOGIN).FirstOrDefault();
                                 if (tempUser != null)
                                 {
                                     NOTE note = new NOTE
                                     {
                                         LOGIN_USER = tempUser.LOGIN,
                                         DATE_CREATE = DateTime.Now,
                                         NAME_OF_NOTE = MyGoal,
                                         CONTENT = GoalTell,
                                         TYPE_NOTE = Type_Note.Goal.ToString(),

                                     };
                                    STYLE style = new STYLE
                                     {
                                         ID_NOTE = note.ID_NOTE,
                                       
                                         FONTFAMILY = _fontfamily,
                                         FONTSIZE = 25,
                                         FOREGROUND = _foreground,
                                         STATUS = Status[IndexStatus]
                                     };
                                   using( var transaction=db.Database.BeginTransaction())
                                   {
                                         try
                                         {
                                            db.NOTE.Add(note);
                                            db.STYLE.Add(style);
                                            db.SaveChanges();
                                            transaction.Commit();
                                         }catch(Exception e)
                                         {
                                             transaction.Rollback();
                                         }
                                   } 
                                     var tmp = note;
                                     //var idNote = db.NOTEs.ToList();
                                     //foreach (NOTE notes in idNote)
                                     //{
                                     //    if (_user.LOGIN == notes.LOGIN_USER)
                                     //        note = notes;
                                     //}
                                     //db.SaveChanges();
                                     _goals.Add(note);
                                 }
                             }
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
                     using(WritterModel db= new WritterModel())
                     {
                         NOTE temp = _goals[SelectIndex];
                         STYLE tempstyle = db.STYLE.Where(x => x.ID_NOTE == temp.ID_NOTE).FirstOrDefault();
                         if (tempstyle != null)
                         {
                             MyGoals = _goals[SelectIndex].NAME_OF_NOTE;
                             GoalTell = _goals[SelectIndex].CONTENT;
                             for(int i=0; i<status.Count; i++)
                             {
                                 if (status[i] == tempstyle.STATUS)
                                 {
                                     IndexStatus = i;
                                 }
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


                    //using (WritterModel db = new WritterModel())
                    //{
                    //    try
                    //    {
                    //        NOTE Note_Remove = _goals[SelectIndex] as NOTE;
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
                    //                _goals.RemoveAt(SelectIndex);
                    //                db.Dispose();
                    //                MessageBox.Show("Data deleted successfully");
                    //            }

                    //        }
                    //    }
                    //    catch (Exception e)
                    //    {
                    //        MessageBox.Show(e.Message);
                    //    }

                    //}
                }
            }));

        #endregion

    }
}
