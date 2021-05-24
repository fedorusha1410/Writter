using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Writter.Models.Repository
{
    class StyleRepository: IRepository<STYLE>
    {
        private WritterModel db;

        public StyleRepository(WritterModel db)
        {
            this.db = db;
        }

        public string Create(STYLE item)
        {
            string result = "This user already exists";
            bool checkIsExist = db.STYLEs.Any(el => el.ID_STYLE_NOTE == item.ID_STYLE_NOTE);
            if (!checkIsExist)
            {
                db.STYLEs.Add(item);
                Save();
                result = "Style add successfully";
            }
            return result;
        }

        public void Delete(int id)
        {
            var STYLE = db.STYLEs.Find(id);
            db.STYLEs.Remove(STYLE);
            Save();
        }

        private void Save()
        {
            db.SaveChanges();
        }

        public STYLE Get(int id)
        {
            var Style = db.STYLEs.Find(id);
            return Style;

        }
        public STYLE GetIdNote(int id)
        {
            var Style = db.STYLEs.Where(i => i.ID_NOTE == id).FirstOrDefault();
            return Style;
        }
        public List<STYLE> GetAll()
        {
            var result = db.STYLEs.ToList();
            return result;
        }

        public string Update(STYLE item)
        {
            throw new NotImplementedException();
        }
    }

       
}
