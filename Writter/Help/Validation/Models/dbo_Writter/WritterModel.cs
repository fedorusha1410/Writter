using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Writter
{
    public partial class WritterModel : DbContext
    {
        public WritterModel()
            : base("name=WritterDataBase")
        {
        }

        public virtual DbSet<NOTE> NOTE { get; set; }
        public virtual DbSet<STYLE> STYLE { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<USERS> USERS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<USERS>()
                .Property(e => e.PHOTO)
                .IsUnicode(false);

            modelBuilder.Entity<USERS>()
                .HasMany(e => e.NOTE)
                .WithOptional(e => e.USERS)
                .HasForeignKey(e => e.LOGIN_USER);
        }
    }
    interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T Get(int id);
        string Create(T item);
        string Update(T item);
        void Delete(int id);
    }
}
