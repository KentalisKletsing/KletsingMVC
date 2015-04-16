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
        public ActionResult Index()
        {

            return View(db.Words.ToList());
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
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Word/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Word/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
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
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Word/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
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
