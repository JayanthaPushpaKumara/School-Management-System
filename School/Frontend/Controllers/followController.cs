using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Frontend.Controllers
{
    public class followController : Controller
    {
        // GET: follow
        public ActionResult Index()
        {
            return View();
        }

       


        public ActionResult addorview()
        {
            return View();
        }
        public ActionResult studentprom(int id)
        {
            ViewBag.detailsid = id;
            return View();
        }

        public ActionResult marksadd()
        {
            return View();
        }
        // GET: follow/Details/5
        public ActionResult Details(int id)
        {
          
            return View();
        }

        // GET: follow/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: follow/Create
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

        // GET: follow/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: follow/Edit/5
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

        // GET: follow/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.detailsid = id;
            return View();
        }

        // POST: follow/Delete/5
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
