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
    public class districtsController : ApiController
    {
        private SMSystemConsettings db = new SMSystemConsettings();

        // GET: api/districts
        public IQueryable<district> Getdistricts()
        {

            return db.districts;
        }

        // GET: api/districts/5
        [ResponseType(typeof(district))]
        public IHttpActionResult Getdistrict(int id)
        {
            district district = db.districts.Find(id);
            if (district == null)
            {
                return NotFound();
            }

            return Ok(district);
        }

        // PUT: api/districts/5
        [ResponseType(typeof(void))]

        // public IHttpActionResult Putdistrict(int id, string district_name, int district_id)  //district district
        public IHttpActionResult Getdistrict(int id, string dname)
        {
            district district = new district();

            district.district_id = id;
            district.district_name = dname;

            if (!ModelState.IsValid)
            {
                Console.WriteLine("API EF Error 1");
                return BadRequest(ModelState);
            }

            if (id != district.district_id)
            {
                Console.WriteLine("API EF Error 2");
                return BadRequest();
            }

            db.Entry(district).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                Console.WriteLine("API EF Error 3");
                if (!districtExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            //  return Json(district, js

            return StatusCode(HttpStatusCode.NoContent);
        }


        // POST: api/districts
        [ResponseType(typeof(district))]
        public IHttpActionResult Postdistrict(district district)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.districts.Add(district);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (districtExists(district.district_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = district.district_id }, district);
        }

        // DELETE: api/districts/5
        [ResponseType(typeof(district))]
        public IHttpActionResult Deletedistrict(int id)
        {
            district district = db.districts.Find(id);
            if (district == null)
            {
                return NotFound();
            }

            db.districts.Remove(district);
            db.SaveChanges();

            return Ok(district);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool districtExists(int id)
        {
            return db.districts.Count(e => e.district_id == id) > 0;
        }
    }
}