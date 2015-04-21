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
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}