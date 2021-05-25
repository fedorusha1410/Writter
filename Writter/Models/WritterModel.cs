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

        public virtual DbSet<NOTE> NOTEs { get; set; }
        public virtual DbSet<STYLE> STYLEs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<USER> USERS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<USER>()
                .Property(e => e.PHOTO)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .HasMany(e => e.NOTEs)
                .WithOptional(e => e.USER)
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
