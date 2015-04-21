using KletsingMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KletsingMVC.Controllers
{
    public class SongController : Controller
    {
        //
        // GET: /Song/
        public ActionResult Index(string id)
        {
            if(id != "" || id != null)
            {
                Song song = new Song { Name = id };
                return View(song);
            }
            else
            {
                return RedirectToAction("Index", "Word");
            }
            
        }
	}
}