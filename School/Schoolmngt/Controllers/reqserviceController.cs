using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Schoolmngt.Models;

namespace Schoolmngt.Controllers
{
    public class reqserviceController : ApiController
    {
        private SMSystemConsettings db = new SMSystemConsettings();

        // GET: api/reqservice
        public IQueryable<reqservice> Getreqservices()
        {
            return db.reqservices;
        }

        // GET: api/reqservice/5
        [ResponseType(typeof(reqservice))]
        public IHttpActionResult Getreqservice(int id)
        {
            reqservice reqservice = db.reqservices.Find(id);
            if (reqservice == null)
            {
                return NotFound();
            }

            return Ok(reqservice);
        }





        // PUT: api/reqservice/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Getreqservice(int id, int st_id, string name, DateTime ser_date, string description, string isconfirm)
        {
            reqservice reqservice = new reqservice();

            reqservice.r_id = id;
            reqservice.st_id = st_id;
            reqservice.name = name;
            reqservice.ser_date = ser_date;
            reqservice.description = description;
            reqservice.isconfirm = isconfirm;




            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reqservice.r_id)
            {
                return BadRequest();
            }

            db.Entry(reqservice).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!reqserviceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/reqservice
        [ResponseType(typeof(reqservice))]
        public IHttpActionResult Postreqservice(reqservice reqservice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.reqservices.Add(reqservice);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = reqservice.r_id }, reqservice);
        }

        // DELETE: api/reqservice/5
        [HttpGet]
        [ResponseType(typeof(reqservice))]
        public IHttpActionResult Deletereqservice(int id)
        {
            reqservice reqservice = db.reqservices.Find(id);
            if (reqservice == null)
            {
                return NotFound();
            }

            db.reqservices.Remove(reqservice);
            db.SaveChanges();

            return Ok(reqservice);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool reqserviceExists(int id)
        {
            return db.reqservices.Count(e => e.r_id == id) > 0;
        }
    }
}