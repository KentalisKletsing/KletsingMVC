using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KletsingMVC.Models;
using KletsingMVC.DAL;

namespace KletsingMVC.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            KletsingDbContext db = new KletsingDbContext();
            WordType type = new WordType {Text = "b", Location = -1};
            //db.WordTypes.Add(type);
            db.Words.Add(new Word { Text = "Bus", Type = type, Songs = new List<Song>() });
            db.SaveChanges();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}