using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Frontend.Controllers
{
    public class DistrictController : Controller
    {

        // GET: District
        public ActionResult NewsAddDistrict()
        {
            return View();
        }

        // GET: District
        public ActionResult NewsViewDistrict()
        {
            return View();
        }
        // GET: District
        public ActionResult Index()
        {
            return View();
        }

        // GET: District/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: District/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: District/Create
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

        // GET: District/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.detailsid = id;
            // Console.Write('c');
            // ViewBag.Message = string.Format("Hello ");
            return View();
        }

        // POST: District/Edit/5
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

        // GET: District/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: District/Delete/5
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
