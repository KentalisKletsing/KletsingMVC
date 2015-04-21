using KletsingMVC.DAL;
using KletsingMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KletsingMVC.Controllers
{
    public class LetterController : Controller
    {
        private KletsingDbContext db = new KletsingDbContext();
        //
        // GET: /Letter/
        [Authorize(Roles = "default")]
        public ActionResult Index()
        {
            WordListWordTypeViewModel vm = new WordListWordTypeViewModel { WordTypes = db.WordTypes.ToList() };
            return View(vm);
        }

        [Authorize(Roles = "default")]
        public ActionResult SelectLetter(string letter)
        {
            return RedirectToAction("Index", "Word", new { letter = letter });
        }
	}
}