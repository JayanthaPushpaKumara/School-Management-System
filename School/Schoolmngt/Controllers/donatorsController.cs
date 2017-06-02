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
    public class donatorsController : ApiController
    {
        private SMSystemConsettings db = new SMSystemConsettings();

        // GET: api/donators
        public IQueryable<donator> Getdonators()
        {
            return db.donators;
        }

        // GET: api/donators/5
        [ResponseType(typeof(donator))]
        public IHttpActionResult Getdonator(int id)
        {
            donator donator = db.donators.Find(id);
            if (donator == null)
            {
                return NotFound();
            }

            return Ok(donator);
        }

        // PUT: api/donators/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putdonator(int id, donator donator)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != donator.d_id)
            {
                return BadRequest();
            }

            db.Entry(donator).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!donatorExists(id))
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

        // POST: api/donators
        [ResponseType(typeof(donator))]
        public IHttpActionResult Postdonator(donator donator)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.donators.Add(donator);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = donator.d_id }, donator);
        }

        // DELETE: api/donators/5
        [ResponseType(typeof(donator))]
        public IHttpActionResult Deletedonator(int id)
        {
            donator donator = db.donators.Find(id);
            if (donator == null)
            {
                return NotFound();
            }

            db.donators.Remove(donator);
            db.SaveChanges();

            return Ok(donator);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool donatorExists(int id)
        {
            return db.donators.Count(e => e.d_id == id) > 0;
        }
    }
}