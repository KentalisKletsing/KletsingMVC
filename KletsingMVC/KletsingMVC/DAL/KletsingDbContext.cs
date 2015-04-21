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
        public DbSet<Song> Songs { get; set; }
        public DbSet<WordType> WordTypes { get; set; }
        public DbSet<Lesson> Lessons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Word>().HasMany(w => w.Songs).WithMany(s => s.Words).Map(t => t.MapLeftKey("Word").MapRightKey("Song").ToTable("wordsong"));
        }

        public Word getWordFromString(string wordString)
        {
            var word = Words.Include(i => i.Songs).Where(i => i.Text == wordString).SingleOrDefault();
            if(word == null)
            {
                
            }
            return word;
        }
    }
}