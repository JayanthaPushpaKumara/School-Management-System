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
    public class reqItemController : ApiController
    {
        private SMSystemConsettings db = new SMSystemConsettings();

        // GET: api/reqItem
        public IQueryable<reqItem> GetreqItems()
        {
            return db.reqItems;
        }

        // GET: api/reqItem/5
        [ResponseType(typeof(reqItem))]
        public IHttpActionResult GetreqItem(int id)
        {
            reqItem reqItem = db.reqItems.Find(id);
            if (reqItem == null)
            {
                return NotFound();
            }

            return Ok(reqItem);
        }

        // PUT: api/reqItem/5
        [ResponseType(typeof(void))]
        public IHttpActionResult GetreqItem(int id, int st_id, string name, string quantity, string description, string iscomfirm)
        {
            reqItem reqItem = new reqItem();

            reqItem.r_id = id;
            reqItem.st_id = st_id;
            reqItem.name = name;
            reqItem.quantity = quantity;
            reqItem.description = description;
            reqItem.iscomfirm = iscomfirm;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reqItem.r_id)
            {
                return BadRequest();
            }

            db.Entry(reqItem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!reqItemExists(id))
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

        // POST: api/reqItem
        [ResponseType(typeof(reqItem))]
        public IHttpActionResult PostreqItem(reqItem reqItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.reqItems.Add(reqItem);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = reqItem.r_id }, reqItem);
        }

        // DELETE: api/reqItem/5
        [ResponseType(typeof(reqItem))]
        public IHttpActionResult DeletereqItem(int id)
        {
            reqItem reqItem = db.reqItems.Find(id);
            if (reqItem == null)
            {
                return NotFound();
            }

            db.reqItems.Remove(reqItem);
            db.SaveChanges();

            return Ok(reqItem);
        }

        [HttpGet]
        [ResponseType(typeof(reqItem))]
        public IHttpActionResult DeletereqItems(int id)
        {
            reqItem reqItem = db.reqItems.Find(id);
            if (reqItem == null)
            {
                return NotFound();
            }

            db.reqItems.Remove(reqItem);
            db.SaveChanges();

            return Ok(reqItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool reqItemExists(int id)
        {
            return db.reqItems.Count(e => e.r_id == id) > 0;
        }
    }
}