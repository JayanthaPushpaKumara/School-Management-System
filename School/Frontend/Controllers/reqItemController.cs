using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Frontend.Controllers
{
    public class reqItemController : Controller
    {
        // GET: reqItem
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult itemorser()
        {
            return View();
        }

        // GET: reqItem
        public ActionResult Index_reqService()
        {
            return View();
        }

        // GET: reqItem/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: reqItem/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: reqItem/Create
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

        // GET: reqItem/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: reqItem/Edit/5
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

        // GET: reqItem/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: reqItem/Delete/5
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
