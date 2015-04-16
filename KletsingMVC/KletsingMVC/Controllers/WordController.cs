using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KletsingMVC.Controllers
{
    public class WordController : Controller
    {
        //
        // GET: /Word/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Word/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Word/Create
        public ActionResult Create()
        {
            return View();
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
