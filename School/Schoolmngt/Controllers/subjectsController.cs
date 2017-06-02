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
    public class subjectsController : ApiController
    {
        private SMSystemConsettings db = new SMSystemConsettings();

        // GET: api/subjects
        public IQueryable<subject> Getsubjects()
        {
            return db.subjects;
        }

        // GET: api/subjects/5
        [ResponseType(typeof(subject))]
        public IHttpActionResult Getsubject(int id)
        {
            subject subject = db.subjects.Find(id);
            if (subject == null)
            {
                return NotFound();
            }

            return Ok(subject);
        }

        // PUT: api/subjects/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putsubject(int id, subject subject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subject.sub_id)
            {
                return BadRequest();
            }

            db.Entry(subject).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!subjectExists(id))
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

        // POST: api/subjects
        [ResponseType(typeof(subject))]
        public IHttpActionResult Postsubject(subject subject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.subjects.Add(subject);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (subjectExists(subject.sub_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = subject.sub_id }, subject);
        }

        // DELETE: api/subjects/5
        [ResponseType(typeof(subject))]
        public IHttpActionResult Deletesubject(int id)
        {
            subject subject = db.subjects.Find(id);
            if (subject == null)
            {
                return NotFound();
            }

            db.subjects.Remove(subject);
            db.SaveChanges();

            return Ok(subject);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool subjectExists(int id)
        {
            return db.subjects.Count(e => e.sub_id == id) > 0;
        }
    }
}