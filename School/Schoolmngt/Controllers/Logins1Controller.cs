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
using Newtonsoft.Json.Linq;

namespace Schoolmngt.Controllers
{
    public class Logins1Controller : ApiController
    {
        private SMSystemConsettings db = new SMSystemConsettings();

        // GET: api/Logins1
        public IQueryable<Login> GetLogins()
        {
            return db.Logins;
        }

        // GET: api/Logins1/5
        [ResponseType(typeof(Login))]
        public IHttpActionResult GetLogin(string id)
        {
            Login login = db.Logins.Find(id);
            if (login == null)
            {
                return NotFound();
            }

            return Ok(login);
        }

        [HttpPost]
        public JArray loginDetail(Login obj)
        {
            JArray newArray = new JArray();
            Login email = db.Logins.Find(obj.email);
            if (email == null)
            {
                JObject object1 = JObject.Parse(@"{""error"":""Wrong Email Entered""}");
                newArray.Add(object1);
                return newArray;
            }


            Login detail = db.Logins.Find(obj.email);
            
            if(detail != null)
            {
                JObject object1 = JObject.FromObject(detail);
                newArray.Add(object1);
            }else
            {
                JObject object1 = JObject.FromObject("Wrong Email Entered");
                newArray.Add(object1);
                return newArray;
            }
            
            if (detail.password.Equals(obj.password))
            {
                if (detail.type.Equals("principle"))
                {
                    JObject object2 = JObject.FromObject(db.Principles.SingleOrDefault(user => user.email == obj.email));
                    newArray.Add(object2);
                    
                }
                else if (detail.type.Equals("student"))
                {
                    JObject object3 = JObject.FromObject(db.students.SingleOrDefault(user => user.email == obj.email));
                    newArray.Add(object3);
                }
                else
                {
                    JObject object4 = JObject.FromObject(db.teachers.SingleOrDefault(user => user.email == obj.email));
                    newArray.Add(object4);
                }
                return (newArray);
            }
            else
            {
                return null;
            }
        }

        // PUT: api/Logins1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLogin(string id, Login login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != login.email)
            {
                return BadRequest();
            }

            db.Entry(login).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginExists(id))
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

 /*       // POST: api/Logins1
        [ResponseType(typeof(Login))]
        public IHttpActionResult PostLogin(Login login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Logins.Add(login);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (LoginExists(login.email))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = login.email }, login);
        }
        */
        // DELETE: api/Logins1/5
        [ResponseType(typeof(Login))]
        public IHttpActionResult DeleteLogin(string id)
        {
            Login login = db.Logins.Find(id);
            if (login == null)
            {
                return NotFound();
            }

            db.Logins.Remove(login);
            db.SaveChanges();

            return Ok(login);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LoginExists(string id)
        {
            return db.Logins.Count(e => e.email == id) > 0;
        }
    }
}