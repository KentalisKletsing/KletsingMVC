using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using KletsingMVC.Models;

namespace KletsingMVC.DAL
{
    public class KletsingDbInitializer : DropCreateDatabaseIfModelChanges<KletsingDbContext>
    {
        protected override void Seed(KletsingDbContext context)
        {
            context.Users.Add(new User { Email = "jorisdouven@hotmail.com", Password = "test", Role = "super" });
            string alphabet = "abcdefghijklmnoprstuvwyz";
            foreach(char c in alphabet){
                context.WordTypes.Add(new WordType { Text = c.ToString(), Location = -1 });
                context.WordTypes.Add(new WordType { Text = c.ToString(), Location = 0 });
                context.WordTypes.Add(new WordType { Text = c.ToString(), Location = 1 });
            }
            
            base.Seed(context);
        }
    }
}