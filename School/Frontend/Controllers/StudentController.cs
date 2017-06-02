using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Frontend.Controllers
{
    public class StudentController : Controller
    {

        

        // GET: Student main interface
        public ActionResult Index()
        {
            return View();
        }


        // GET: Student /Add news
        public ActionResult News_Add()
        {
            return View();
        }


        // GET: Student/Delete/5
        public ActionResult News_Delete(int id)
        {
            ViewBag.detailsid = id;
            return View();
        }

        // PUT: /Student/Edit
        [HttpPut]
        public JsonResult News_Edit(int id, FormCollection collection)
        {
            return Json("Response from Edit");
        }


        // GET: Student/Edit News/5
        public ActionResult News_Edit(int id)
        {
            ViewBag.detailsid = id;
            return View();
        }

        // GET: Student /View News/5
        public ActionResult News_View()
        {

            return View();
        }


        // GET: Student /vNews_ReadMore
        public ActionResult News_ReadMore(int id)
        {
            ViewBag.detailsid = id;
            return View();
        }

        // GET: Student/profile/5
        public ActionResult profile(int id)
        {
            ViewBag.detailsid = id;
            return View();
        }

        // GET: Student /Add Sport
        public ActionResult Sport_Add()
        {
            return View();
        }


        // GET: Student/Delete/5
        public ActionResult Sport_Delete(int id)
        {
            ViewBag.detailsid = id;
            return View();
        }


        // GET: Student/Edit sport/5
        public ActionResult Sport_Edit(int id)
        {
            ViewBag.detailsid = id;
            return View();
        }



        public ActionResult Sport_view(int id)
        {
            ViewBag.detailsid = id;
            return View();
        }






        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
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


        // POST: Student/Edit/5
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



        // POST: Student/Delete/5
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
