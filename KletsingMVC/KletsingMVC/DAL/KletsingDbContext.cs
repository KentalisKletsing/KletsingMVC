using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using KletsingMVC.Models;
using System.Data.Entity.ModelConfiguration.Conventions;
using MySql.Data.Entity;

namespace KletsingMVC.DAL
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class KletsingDbContext : DbContext
    {
        public KletsingDbContext() : base("Server=84.28.193.115;Port=3306;Database=kletsing2;Uid=remoteuser;Pwd=420blaze")
        {
            Database.SetInitializer<KletsingDbContext>(new KletsingDbInitializer());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<WordType> WordTypes { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Lesson> Lessons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}