using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Writter.Models.dbo_Writter;

namespace Writter.Models.Repository
{
    class UserRepository : IRepository<USERS>
    {
        private WritterModel db;
        public UserRepository(WritterModel context)
        {
            db = context;
        }
        public string Create(USERS item)
        {
            string result = "This user already exists";
            bool checkIsExist = db.USERS.Any(el => el.LOGIN == item.LOGIN);
            if (!checkIsExist)
            {
                db.USERS.Add(item);
                Save();
                result = "Registration completed successfully";
            }
            return result;
        }

        public void Delete(string login)
        {
            USERS user = db.USERS.Find(login);
            if (user != null)
            {
                db.USERS.Remove(user);
                Save();
            }
        }

        public USERS GetByLogin(string login, string password)
        {
            USERS user = db.USERS.Find(login);
            if (user.PASSWORD == password && user.STATUS_USER==StatusUser.Active.ToString()) {
                return user;
            }
            return null;
            
        }

        public List<USERS> GetAll()
        {
            return db.USERS.ToList();
        }

        public string Update(USERS item)
        {
            string result= "Failed to change data";
            USERS user = db.USERS.FirstOrDefault(el => el.LOGIN == item.LOGIN);
            if (user != null)
            {
                
                user.PASSWORD = item.PASSWORD;
                Save();
                result = "Data changed successfully";
            }
            return result;
        }
        public string UpdateName(USERS item, string name)
        {
            string result = "Failed to change data";
            USERS user = db.USERS.FirstOrDefault(el => el.LOGIN == item.LOGIN);
            if (user != null)
            {
                user.NAME = name;
                user.PASSWORD = item.PASSWORD;
                Save();
                result = "Data changed successfully";
            }
            return result;
        }
        public string UpdateStatus(USERS uSER)
        {
            string result = "Failed to change data";
            USERS user = db.USERS.FirstOrDefault(elem => elem.LOGIN == uSER.LOGIN);
            if (user != null)
            {
                user.STATUS_USER = StatusUser.Block.ToString();
                Save();
            }
            result = "User blocked!!!";
            return result;
        }
        public void Save()
        {
            db.SaveChanges();
        }

        public USERS Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        List<USERS> IRepository<USERS>.GetAll()
        {
            throw new NotImplementedException();
        }

        USERS IRepository<USERS>.Get(int id)
        {
            throw new NotImplementedException();
        }

        //public string Create(USERS item)
        //{
        //    throw new NotImplementedException();
        //}

        //public string Update(USERS item)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
