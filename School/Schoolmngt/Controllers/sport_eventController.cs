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
    public class sport_eventController : ApiController
    {
        private SMSystemConsettings db = new SMSystemConsettings();

        // GET: api/sport_event
        public IQueryable<sport_event> Getsport_event()
        {
            return db.sport_event;
        }

        // GET: api/sport_event/5
        [ResponseType(typeof(sport_event))]
        public IHttpActionResult Getsport_event(int id)
        {
            sport_event sport_event = db.sport_event.Find(id);
            if (sport_event == null)
            {
                return NotFound();
            }

            return Ok(sport_event);
        }

        // PUT: api/sport_event/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Getsport_event(int id, string sp_name, string sp_event, string place, string recode, string ranks, string sp_description)
        {
            sport_event sport_event = new sport_event();

            sport_event.sportId = id;
            sport_event.sp_name = sp_name;
            sport_event.sp_event = sp_event;
            sport_event.place = place;
            sport_event.recode = recode;
            sport_event.ranks = ranks;
            sport_event.sp_description = sp_description;


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sport_event.sportId)
            {
                return BadRequest();
            }

            db.Entry(sport_event).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!sport_eventExists(id))
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

        // POST: api/sport_event
        [ResponseType(typeof(sport_event))]
        public IHttpActionResult Postsport_event(sport_event sport_event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.sport_event.Add(sport_event);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sport_event.sportId }, sport_event);
        }

        // DELETE: api/sport_event/5
       // [ResponseType(typeof(sport_event))]
       
        public IHttpActionResult Deletesport_event(int id)
        {
            sport_event sport_event = db.sport_event.Find(id);
            if (sport_event == null)
            {
                return Ok();
                //return NotFound();
            }

            db.sport_event.Remove(sport_event);
            db.SaveChanges();

            return Ok(sport_event);
        }
        [HttpGet]
        public IHttpActionResult Delsport_event(int id)
        {
            sport_event sport_event = db.sport_event.Find(id);
            if (sport_event == null)
            {
                return NotFound();
            }

            db.sport_event.Remove(sport_event);
            db.SaveChanges();

            return Ok(sport_event);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool sport_eventExists(int id)
        {
            return db.sport_event.Count(e => e.sportId == id) > 0;
        }
    }
}