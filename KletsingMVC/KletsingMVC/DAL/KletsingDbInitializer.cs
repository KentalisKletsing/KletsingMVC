using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using KletsingMVC.Models;

namespace KletsingMVC.DAL
{
    public class KletsingDbInitializer : DropCreateDatabaseAlways<KletsingDbContext>
    {
        protected override void Seed(KletsingDbContext context)
        {
            context.Users.Add(new User { Email = "jorisdouven@hotmail.com", Password = "test", Role = "super" });
            string alphabet = "abcdefghijklmnoprstuvwyz";
            foreach (char c in alphabet)
            {
                context.WordTypes.Add(new WordType { Text = c.ToString(), Location = -1 });
                context.WordTypes.Add(new WordType { Text = c.ToString(), Location = 0 });
                context.WordTypes.Add(new WordType { Text = c.ToString(), Location = 1 });
            }

            Word klaas = new Word { Text = "Klaas", Songs = new List<Song>(), Letter = "k", Location = -1 };
            Word bus = new Word { Text = "Bus", Songs = new List<Song>(), Letter = "b", Location = -1};
            Word kaas = new Word { Text = "Kaas", Songs = new List<Song>(), Letter = "s", Location = 1};
            Word blaas = new Word { Text = "Blaas", Songs = new List<Song>(), Letter = "s", Location = 1};
            Word henk = new Word { Text = "Henk", Songs = new List<Song>(), Letter = "h", Location = -1};

            context.Words.Add(klaas);
            context.Words.Add(bus);
            context.Words.Add(kaas);
            context.Words.Add(blaas);
            context.Words.Add(henk);

            context.SaveChanges();

            context.Songs.Add(new Song { Name = "Rijden", Words = new List<Word>() });
            context.Songs.Add(new Song { Name = "Blazen", Words = new List<Word>() });
            context.Songs.Add(new Song { Name = "Vliegen", Words = new List<Word>() });
            context.Songs.Add(new Song { Name = "Vangen", Words = new List<Word>() });
            context.Songs.Add(new Song { Name = "Hollen", Words = new List<Word>() });

            context.SaveChanges();

            AddOrUpdateSong(context, "Klaas", "Rijden");
            AddOrUpdateSong(context, "Klaas", "Blazen");
            AddOrUpdateSong(context, "Klaas", "Vliegen");
            AddOrUpdateSong(context, "Klaas", "Vangen");
            AddOrUpdateSong(context, "Klaas", "Hollen");
            AddOrUpdateSong(context, "Henk", "Rijden");

            context.SaveChanges();

            base.Seed(context);
        }

        void AddOrUpdateSong(KletsingDbContext context, string wordPar, string songPar)
        {
            var word = context.Words.SingleOrDefault(w => w.Text == wordPar);
            var song = context.Songs.SingleOrDefault(s => s.Name == songPar);
            if (song == null)
            {
                word.Songs.Add(context.Songs.Single(s => s.Name == songPar));
            }
        }
    }
}