using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Writter.dbo_Writter;

namespace Writter.Models.Repository
{
    class NoteRepository : IRepository<NOTE>
    {
        private WritterModel db;

        public NoteRepository(WritterModel db)
        {
            this.db = db;
        }

        public string Create(NOTE item)
        {
            string result = "This note already exists";
            bool checkIsExist = db.NOTEs.Any(el => el.ID_NOTE == item.ID_NOTE);
            if (!checkIsExist)
            {
                db.NOTEs.Add(item);
                Save();
                result = "Task add successfully";
            }
            return result;
        }

        public void Delete(int id)
        {
            var Note = db.NOTEs.Find(id);
            db.NOTEs.Remove(Note);
            Save();
        }

        private void Save()
        {
            db.SaveChanges();
        }

        public NOTE Get(int id)
        {
            var Note = db.NOTEs.Find(id);
            return Note;
        }
        public ObservableCollection<NOTE> GetNotesWithTyle(string Type, USER user)
        {
            ObservableCollection<NOTE> note = new ObservableCollection<NOTE>();
            var res = db.NOTEs.Where(item => item.LOGIN_USER == user.LOGIN &&
                                              item.TYPE_NOTE == Type);
            foreach (var i in res)
            {
                note.Add(i);

            }
            return note;
        }
        public ObservableCollection<NOTE> GetSortByDate(USER user)
        {
            ObservableCollection<NOTE> notes;
            notes= new ObservableCollection<NOTE>(db.NOTEs.Where(i => i.TYPE_NOTE == Type_Note.Simple_Note.ToString() && i.LOGIN_USER == user.LOGIN)
                                                                            .OrderBy(i => i.DATE_CREATE));
            return notes;
        }

        public ObservableCollection<NOTE> GetSortByAlpha(USER user)
        {
            ObservableCollection<NOTE> notes;
            notes = new ObservableCollection<NOTE>(db.NOTEs.Where(i => i.TYPE_NOTE == Type_Note.Simple_Note.ToString() && i.LOGIN_USER == user.LOGIN)
                                                                            .OrderBy(i => i.NAME_OF_NOTE));
            return notes;
        }



        public List<NOTE> GetAll()
        {
            var result = db.NOTEs.ToList();
            return result;
        }

        public string Update(NOTE item)
        {
            throw new NotImplementedException();
        }
    }
}
