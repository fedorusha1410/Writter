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
            bool checkIsExist = db.STYLE.Any(el => el.ID_STYLE_NOTE == item.ID_STYLE_NOTE);
            if (!checkIsExist)
            {
                db.STYLE.Add(item);
                Save();
                result = "Style add successfully";
            }
            return result;
        }

        public void Delete(int id)
        {
            var STYLE = db.STYLE.Find(id);
            db.STYLE.Remove(STYLE);
            Save();
        }

        private void Save()
        {
            db.SaveChanges();
        }

        public STYLE Get(int id)
        {
            var Style = db.STYLE.Find(id);
            return Style;

        }

        public List<STYLE> GetAll()
        {
            throw new NotImplementedException();
        }

        public string Update(STYLE item)
        {
            throw new NotImplementedException();
        }
    }

       
}
