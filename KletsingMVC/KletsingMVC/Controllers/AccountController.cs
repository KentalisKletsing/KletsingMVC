using KletsingMVC.DAL;
using KletsingMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KletsingMVC.Controllers
{
    public class AccountController : Controller
    {
        private KletsingDbContext db = new KletsingDbContext();
        //
        // GET: /Account/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            user.Role = "default";
            db.Users.Add(user);
            db.SaveChangesAsync();
            return View();
        }
	}
}