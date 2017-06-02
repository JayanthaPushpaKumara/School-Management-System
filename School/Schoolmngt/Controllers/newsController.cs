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
using Schoolmngt.Commen;

namespace Schoolmngt.Controllers
{
    public class newsController : ApiController
    {
        private SMSystemConsettings db = new SMSystemConsettings();

        // GET: api/news
        public IQueryable<news> Getnews()
        {
            return db.news;
        }

        // GET: api/news/5
        [ResponseType(typeof(news))]
        public IHttpActionResult Getnews(int id)
        {
            news news = db.news.Find(id);
            if (news == null)
            {
                return NotFound();
            }

            return Ok(news);
        }



        // PUT: api/news/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Getnews(int id, DateTime n_date, int t_id, int st_id, string headiline, string discription,string isConfirm, string st_name)
        {
            news news = new news();

            news.n_id = id;
            news.n_date = n_date;
            news.t_id = t_id;
            news.st_id = st_id;
            news.headiline = headiline;
            news.discription = discription;
            news.isConfirm = isConfirm;
            news.st_name = st_name;


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != news.n_id)
            {
                return BadRequest();
            }

            db.Entry(news).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!newsExists(id))
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


        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult Putnewss(int id, news news)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != news.n_id)
            {
                return BadRequest();
            }

            db.Entry(news).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!newsExists(id))
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



        // POST: api/news
        [ResponseType(typeof(news))]
        public IHttpActionResult Postnews(news news)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ImageConverter convert = new ImageConverter();
            string name = convert.SaveByteArrayAsImage(news.img);
            news.img = "http://localhost:56412/Commen/" + name + ".jpg";

            db.news.Add(news);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = news.n_id }, news);
        }

        // DELETE: api/news/5
        [ResponseType(typeof(news))]
        public IHttpActionResult Deletenews(int id)
        {
            news news = db.news.Find(id);
            if (news == null)
            {
                return NotFound();
            }

            db.news.Remove(news);
            db.SaveChanges();

            return Ok(news);
        }

        [HttpGet]
        public IHttpActionResult Delnews(int id)
        {
            news news = db.news.Find(id);
            if (news == null)
            {
                return NotFound();
            }

            db.news.Remove(news);
            db.SaveChanges();

            return Ok(news);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool newsExists(int id)
        {
            return db.news.Count(e => e.n_id == id) > 0;
        }
    }
}