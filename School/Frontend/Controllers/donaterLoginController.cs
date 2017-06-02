using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Frontend.Controllers
{
    public class donaterLoginController : Controller
    {
        // GET: donaterLogin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index1()
        {
            return View();
        }

        public ActionResult SignuP()
        {
            return View();
        }

        public ActionResult download()
        {
            return View();
        }

        // GET: donaterLogin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: donaterLogin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: donaterLogin/Create
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

        // GET: donaterLogin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: donaterLogin/Edit/5
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

        // GET: donaterLogin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: donaterLogin/Delete/5
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
