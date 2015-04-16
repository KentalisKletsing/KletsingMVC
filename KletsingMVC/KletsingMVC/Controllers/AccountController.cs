using KletsingMVC.DAL;
using KletsingMVC.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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

        [HttpPost]
        public ActionResult Login(User user, FormCollection formCollection)
        {
            if (user != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
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

        /// <summary>
        /// Returns a hashed value of the entered password
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private string GetPasswordHash(string password)
        {
            if (password != null)
            {
                Console.WriteLine("Test getPassword");
                UnicodeEncoding encoding = new UnicodeEncoding();
                byte[] binaryPassword = encoding.GetBytes(password);
                byte[] hashValue = (new MD5CryptoServiceProvider()).ComputeHash(binaryPassword);
                string hashedPassword = String.Empty;
                foreach (byte b in hashValue)
                {
                    hashedPassword += b.ToString("X2", CultureInfo.InvariantCulture.NumberFormat);
                }
                return hashedPassword;
            }
            return null;
        }
    }
}