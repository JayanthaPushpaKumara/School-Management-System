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
    public class schoolsController : ApiController
    {
        private SMSystemConsettings db = new SMSystemConsettings();

        // GET: api/schools
        public IQueryable<school> Getschools()
        {
            return db.schools;
        }

        // GET: api/schools/5
        [ResponseType(typeof(school))]
        public IHttpActionResult Getschool(int id)
        {
            school school = db.schools.Find(id);
            if (school == null)
            {
                return NotFound();
            }

            return Ok(school);
        }

        [HttpPost]
        public bool checkNic(school obj)
        {
            school pNic = db.schools.SingleOrDefault(user => user.pNic == obj.pNic);
            if (pNic == null)
            {
                return false;
            }else
            {
                if (pNic.pNic.Equals(obj.pNic))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }


    


        // PUT: api/schools/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putschool(int id, school school)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != school.school_id)
            {
                return BadRequest();
            }

            db.Entry(school).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!schoolExists(id))
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

  /*      // POST: api/schools
        [ResponseType(typeof(school))]
        public IHttpActionResult Postschool(school school)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.schools.Add(school);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (schoolExists(school.school_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = school.school_id }, school);
        }
        */
        // DELETE: api/schools/5
        [ResponseType(typeof(school))]
        public IHttpActionResult Deleteschool(int id)
        {
            school school = db.schools.Find(id);
            if (school == null)
            {
                return NotFound();
            }

            db.schools.Remove(school);
            db.SaveChanges();

            return Ok(school);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool schoolExists(int id)
        {
            return db.schools.Count(e => e.school_id == id) > 0;
        }
    }
}