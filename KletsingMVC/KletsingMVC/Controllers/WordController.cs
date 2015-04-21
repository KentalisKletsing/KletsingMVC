using KletsingMVC.DAL;
using KletsingMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KletsingMVC.Controllers
{
    public class WordController : Controller
    {
        private KletsingDbContext db = new KletsingDbContext();
        //
        // GET: /Word/
        public ActionResult Index(string letter)
        {
            List<Word> words = db.Words.ToList();
            if (letter == null || letter == "")
            {
                return View(words);
            }
            else
            {
                List<Word> wordsWithLetter = new List<Word>();
                foreach(var item in db.Words)
                {
                    if(item.Letter.ToLower() == letter.ToLower())
                    {
                        wordsWithLetter.Add(item);
                    }
                }
                return View(wordsWithLetter);
            }
        }

        [HttpPost]
        public ActionResult Search(string name)
        {
            List<Word> words = new List<Word>();
            foreach(Word word in db.Words.ToList())
            {
                if(word.Text.ToLower().Contains(name.ToLower()))
                {
                    words.Add(word);
                }
            }
            return View("Index", words);
        }

        //
        // GET: /Word/Details/5
        public ActionResult Details(string id)
        {
           Word newWord = db.getWordFromString(id);
            return View(newWord);
        }

        //
        // GET: /Word/Create
        public ActionResult Create()
        {
            WordListWordTypeViewModel vm = new WordListWordTypeViewModel { Text = "", WordTypes = db.WordTypes.ToList() };
            return View(vm);
        }

        //
        // POST: /Word/Create
        [HttpPost]
        public ActionResult Create(string name, string bijbehorendeLetter, string positie)
        {
            string message = "";
            int location = 0;
            switch(positie)
            {
                case "Begin":
                    location = -1;
                    break;
                case "Midden":
                    location = 0;
                    break;
                case "Eind":
                    location = 1;
                    break;
                default:
                    location = -1;
                    break;
            }
            db.Words.Add(new Word { Text = name , Location = location, Letter = bijbehorendeLetter });
            try
            {
                db.SaveChanges();
                message = name + " toegevoegd";
            }
            catch(Exception ex)
            {
                message = name + " niet toegevoegd";
            }
            WordListWordTypeViewModel vm = new WordListWordTypeViewModel { Text = message, WordTypes = db.WordTypes.ToList() };
                return View(vm);
        }

        //
        // GET: /Word/Edit/5
        public ActionResult Edit(string id)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // POST: /Word/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Word/Delete/5
        public ActionResult Delete(string id)
        {
            try
            {
                // TODO: Add update logic here
                Word word = new Word() ;
                List<Word> words = db.Words.ToList();
                foreach(var item in words)
                {
                    if(item.Text == id)
                    {
                        word = item;
                    }
                }
                db.Words.Remove(word);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {

                return RedirectToAction("Index");
            }
        }

        //
        // POST: /Word/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
