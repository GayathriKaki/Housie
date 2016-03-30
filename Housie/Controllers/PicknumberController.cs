using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Housie.Models;

namespace Housie.Controllers
{
    public class PicknumberController : ApiController
    {
        private db_housieEntities db = new db_housieEntities();

        // GET: api/Picknumber
        public IQueryable<tbl_picknumber> Gettbl_picknumber()
        {
            return db.tbl_picknumber;
        }

        // GET: api/Picknumber/5
        [ResponseType(typeof(tbl_picknumber))]
        public async Task<IHttpActionResult> Gettbl_picknumber(int id)
        {
            tbl_picknumber tbl_picknumber = await db.tbl_picknumber.FindAsync(id);
            if (tbl_picknumber == null)
            {
                return NotFound();
            }

            return Ok(tbl_picknumber);
        }

        // PUT: api/Picknumber/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Puttbl_picknumber(int id, tbl_picknumber tbl_picknumber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_picknumber.id)
            {
                return BadRequest();
            }

            db.Entry(tbl_picknumber).State = System.Data.Entity.EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_picknumberExists(id))
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

        // POST: api/Picknumber
        [ResponseType(typeof(tbl_picknumber))]
        public async Task<IHttpActionResult> Posttbl_picknumber(tbl_picknumber tbl_picknumber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_picknumber.Add(tbl_picknumber);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tbl_picknumber.id }, tbl_picknumber);
        }

        // DELETE: api/Picknumber/5
        [ResponseType(typeof(tbl_picknumber))]
        public async Task<IHttpActionResult> Deletetbl_picknumber(int id)
        {
            tbl_picknumber tbl_picknumber = await db.tbl_picknumber.FindAsync(id);
            if (tbl_picknumber == null)
            {
                return NotFound();
            }

            db.tbl_picknumber.Remove(tbl_picknumber);
            await db.SaveChangesAsync();

            return Ok(tbl_picknumber);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_picknumberExists(int id)
        {
            return db.tbl_picknumber.Count(e => e.id == id) > 0;
        }
    }
}