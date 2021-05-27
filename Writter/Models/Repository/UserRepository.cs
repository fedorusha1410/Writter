using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Writter.Models.dbo_Writter;

namespace Writter.Models.Repository
{
    class UserRepository : IRepository<USER>
    {
        private WritterModel db;

        public UserRepository(WritterModel context)
        {
            db = context;
        }
        public string Create(USER item)
        {
            string result = "This user already exists";

            using(var transaction=db.Database.BeginTransaction())
            try
            {
                 bool checkIsExist = db.USERS.Any(el => el.LOGIN == item.LOGIN);
                    if (!checkIsExist)
                    {
                        db.USERS.Add(item);
                        Save();
                        transaction.Commit();
                        return result = "Registration completed successfully";
                    }
                }
                catch
                {
                    transaction.Rollback();
                }
                    return result;
           
        }

        public void Delete(string login)
        {
            USER user = db.USERS.Find(login);
            if (user != null)
            {
                db.USERS.Remove(user);
                Save();
            }
        }

        public void RefactorPhoto(string login, string photo)
        {
            USER user = db.USERS.Find(login);
            if (user.PHOTO == null)
            {
                user.PHOTO = photo;
                Save();
                MessageBox.Show("Photo set and save");
            }
            else
            {
                user.PHOTO = photo;
                Save();
                MessageBox.Show("photo modified and save");
            }

        }
        public USER GetByLogin(string login, string password)
        {
            try
            {
            USER user = db.USERS.Find(login);
                if (user != null)
                {
                    if (user.STATUS_USER == StatusUser.Active.ToString())
                    {
                        return user;
                    }
                    else throw new Exception("This user is block");
                }
                else throw new Exception("Wrong data");
               
          
            } catch(Exception e)
            {
                MessageBox.Show(e.Message);

            }
                return null;
            
        }

        public List<USER> GetAll()
        {
            return db.USERS.ToList();
        }
        public ObservableCollection<USER> GetAllUser()
        {
            ObservableCollection<USER> all;
            all = new ObservableCollection<USER>(db.USERS.ToList());
            return all;
        }
        public string Update(USER item)
        {
            string result= "Failed to change data";
            USER user = db.USERS.FirstOrDefault(el => el.LOGIN == item.LOGIN);
            if (user != null)
            {
                user.NAME = item.NAME;
                user.PASSWORD = item.PASSWORD;
                Save();
                result = "Data changed successfully";
            }
            return result;
        }
        public string UpdateName(USER item, string name)
        {
            string result = "Failed to change data";
            USER user = db.USERS.FirstOrDefault(el => el.LOGIN == item.LOGIN);
            if (user != null)
            {
                user.NAME = name;
                user.PASSWORD = item.PASSWORD;
                Save();
                result = "Data changed successfully";
            }
            return result;
        }
        public string UpdateStatus(USER uSER)
        {
            string  result = "User blocked!!!";
            USER user = db.USERS.Find(uSER.LOGIN);
            if (user != null)
            {
                if (user.STATUS_USER == StatusUser.Active.ToString())
                {
                user.STATUS_USER = StatusUser.Block.ToString();

                }
                else
                {
                    user.STATUS_USER = StatusUser.Active.ToString();
                    result = "User unblocked!!!";
                }
            }
            Save();
            return result;
        }

        //public void DelUser(string login)
        //{
        //    using (WritterModel context = new WritterModel())
        //    {
        //        try
        //        {
        //            context.Database.ExecuteSqlCommand($"DELETE FROM USERS WHERE LOGIN={login}");
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //    }
        //}

        public void Save()
        {
            db.SaveChanges();
        }

        public USER Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        List<USER> IRepository<USER>.GetAll()
        {
            throw new NotImplementedException();
        }

        USER IRepository<USER>.Get(int id)
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
