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
    public class followsController : ApiController
    {
        private SMSystemConsettings db = new SMSystemConsettings();

        // GET: api/follows
        public IQueryable<follow> Getfollows()
        {
            return db.follows;
        }

        // GET: api/follows/5
        [ResponseType(typeof(follow))]
        public IHttpActionResult Getfollow(int id)
        {
            follow follow = db.follows.Find(id);
            if (follow == null)
            {
                return NotFound();
            }

            return Ok(follow);
        }

     

        // PUT: api/follows/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putfollow(int id, follow follow)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != follow.st_id)
            {
                return BadRequest();
            }

            db.Entry(follow).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!followExists(id))
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

        // POST: api/follows
        [ResponseType(typeof(follow))]
        public IHttpActionResult Postfollow(follow follow)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.follows.Add(follow);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (followExists(follow.st_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = follow.st_id }, follow);
        }

        // DELETE: api/follows/5
        [ResponseType(typeof(follow))]
        public IHttpActionResult Deletefollow(int id)
        {
           
            follow follow = db.follows.Find(id);
            if (follow == null)
            {
                return NotFound();
            }

            db.follows.Remove(follow);
            db.SaveChanges();
                      
            return Ok(follow);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool followExists(int id)
        {
            return db.follows.Count(e => e.st_id == id) > 0;
        }
    }
}