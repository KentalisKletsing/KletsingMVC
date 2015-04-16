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
    //[DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class KletsingDbContext : DbContext
    {
        public KletsingDbContext()
            : base("name=KletsingDbContextConnectionString")
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