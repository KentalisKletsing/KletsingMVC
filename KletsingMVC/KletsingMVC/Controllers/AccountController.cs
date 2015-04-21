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
using System.Web.Security;

namespace KletsingMVC.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        [Authorize]
        public ActionResult Index()
        {
            using (KletsingDbContext db = new KletsingDbContext())
            {
                string username = HttpContext.User.Identity.Name;
                User user = db.Users.SingleOrDefault(u => u.Email == username);
                return View(user);
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                using (KletsingDbContext db = new KletsingDbContext())
                {
                    string username = model.Email;
                    string password = GetPasswordHash(model.Password);
                    bool userValid = db.Users.Any(user => user.Email == username && user.Password == password);
                    if (userValid)
                    {
                        FormsAuthentication.SetAuthCookie(username, false);
                        if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/") && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "De gebruikersnaam of het wachtwoord is incorrect.");
                        return View();
                    }
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            user.Roles = "default";
            user.Password = GetPasswordHash(user.Password);
            using (KletsingDbContext db = new KletsingDbContext())
            {
                db.Users.Add(user);
                db.SaveChangesAsync();
            }
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