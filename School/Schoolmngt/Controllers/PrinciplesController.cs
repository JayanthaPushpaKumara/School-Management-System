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
    public class PrinciplesController : ApiController
    {
        private SMSystemConsettings db = new SMSystemConsettings();

        // GET: api/Principles
        public IQueryable<Principle> GetPrinciples()
        {
            return db.Principles;
        }

        // GET: api/Principles/5
        [ResponseType(typeof(Principle))]
        public IHttpActionResult GetPrinciple(int id)
        {
            Principle principle = db.Principles.Find(id);
            if (principle == null)
            {
                return NotFound();
            }

            return Ok(principle);
        }

        // PUT: api/Principles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPrinciple(int id, Principle principle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != principle.pid)
            {
                return BadRequest();
            }

            db.Entry(principle).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrincipleExists(id))
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

        // POST: api/Principles
        [ResponseType(typeof(Principle))]
        public IHttpActionResult PostPrinciple(Principle principle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Principles.Add(principle);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = principle.pid }, principle);
        }

        // DELETE: api/Principles/5
        [ResponseType(typeof(Principle))]
        public IHttpActionResult DeletePrinciple(int id)
        {
            Principle principle = db.Principles.Find(id);
            if (principle == null)
            {
                return NotFound();
            }

            db.Principles.Remove(principle);
            db.SaveChanges();

            return Ok(principle);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PrincipleExists(int id)
        {
            return db.Principles.Count(e => e.pid == id) > 0;
        }
    }
}