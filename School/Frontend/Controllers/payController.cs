using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Frontend.Controllers
{
    public class payController : Controller
    {
        // GET: pay
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult markorview()
        {
            return View();
        }

        // GET: pay/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.deatailsid = id;
            return View();
        }

        // GET: pay/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult teaclog()
        {
            return View();
        }

        // POST: pay/Create
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

        // GET: pay/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: pay/Edit/5
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

        // GET: pay/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: pay/Delete/5
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
