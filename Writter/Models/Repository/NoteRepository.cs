using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            string result = "This user already exists";
            bool checkIsExist = db.NOTE.Any(el => el.ID_NOTE == item.ID_NOTE);
            if (!checkIsExist)
            {
                db.NOTE.Add(item);
                Save();
                result = "Task add successfully";
            }
            return result;
        }

        public void Delete(int id)
        {
            var Note = db.NOTE.Find(id);
            db.NOTE.Remove(Note);
            Save();
        }

        private void Save()
        {
            db.SaveChanges();
        }

        public NOTE Get(int id)
        {
            var Note = db.NOTE.Find(id);
            return Note;
        }

        public List<NOTE> GetAll()
        {
            throw new NotImplementedException();
        }

        public string Update(NOTE item)
        {
            throw new NotImplementedException();
        }
    }
}
