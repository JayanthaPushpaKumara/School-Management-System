using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Frontend.Controllers
{
    public class principleLoginController : Controller
    {
        // GET: principleLogin
        public ActionResult Index()
        {
            return View();
        }


       

        // GET: principleLogin/Details/5
        public ActionResult Details(int id)
        {
           
            return View();
        }

        // GET: principleLogin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: principleLogin/Create
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

        // GET: principleLogin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: principleLogin/Edit/5
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

        // GET: principleLogin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: principleLogin/Delete/5
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
