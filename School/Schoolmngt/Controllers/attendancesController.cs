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
    public class attendancesController : ApiController
    {
        private SMSystemConsettings db = new SMSystemConsettings();

        // GET: api/attendances
        public IQueryable<attendance> Getattendances()
        {
            return db.attendances;
        }

        // GET: api/attendances/5
        [ResponseType(typeof(attendance))]
        public IHttpActionResult Getattendance(int id)
        {
            attendance attendance = db.attendances.Find(id);
            if (attendance == null)
            {
                return NotFound();
            }

            return Ok(attendance);
        }

        // PUT: api/attendances/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putattendance(int id, attendance attendance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != attendance.st_id)
            {
                return BadRequest();
            }

            db.Entry(attendance).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!attendanceExists(id))
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

        // POST: api/attendances
        [ResponseType(typeof(attendance))]
        public IHttpActionResult Postattendance(attendance attendance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           
            db.attendances.Add(attendance);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (attendanceExists(attendance.st_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = attendance.st_id }, attendance);
        }

        // DELETE: api/attendances/5
        [ResponseType(typeof(attendance))]
        public IHttpActionResult Deleteattendance(int id)
        {
            attendance attendance = db.attendances.Find(id);
            if (attendance == null)
            {
                return NotFound();
            }

            db.attendances.Remove(attendance);
            db.SaveChanges();

            return Ok(attendance);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool attendanceExists(int id)
        {
            return db.attendances.Count(e => e.st_id == id) > 0;
        }
    }
}