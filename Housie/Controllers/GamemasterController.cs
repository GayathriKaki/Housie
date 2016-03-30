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
    public class GamemasterController : ApiController
    {
        private db_housieEntities db = new db_housieEntities();

        // GET: api/Gamemaster
        public IQueryable<tbl_gamemaster> Gettbl_gamemaster()
        {
            return db.tbl_gamemaster;
        }

        // GET: api/Gamemaster/5
        [ResponseType(typeof(tbl_gamemaster))]
        public async Task<IHttpActionResult> Gettbl_gamemaster(int id)
        {
            tbl_gamemaster tbl_gamemaster = await db.tbl_gamemaster.FindAsync(id);
            if (tbl_gamemaster == null)
            {
                return NotFound();
            }

            return Ok(tbl_gamemaster);
        }

        // PUT: api/Gamemaster/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Puttbl_gamemaster(int id, tbl_gamemaster tbl_gamemaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_gamemaster.gameId)
            {
                return BadRequest();
            }

            db.Entry(tbl_gamemaster).State = System.Data.Entity.EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_gamemasterExists(id))
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

        // POST: api/Gamemaster
        [ResponseType(typeof(tbl_gamemaster))]
        public async Task<IHttpActionResult> Posttbl_gamemaster(tbl_gamemaster tbl_gamemaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_gamemaster.Add(tbl_gamemaster);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tbl_gamemaster.gameId }, tbl_gamemaster);
        }

        // DELETE: api/Gamemaster/5
        [ResponseType(typeof(tbl_gamemaster))]
        public async Task<IHttpActionResult> Deletetbl_gamemaster(int id)
        {
            tbl_gamemaster tbl_gamemaster = await db.tbl_gamemaster.FindAsync(id);
            if (tbl_gamemaster == null)
            {
                return NotFound();
            }

            db.tbl_gamemaster.Remove(tbl_gamemaster);
            await db.SaveChangesAsync();

            return Ok(tbl_gamemaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_gamemasterExists(int id)
        {
            return db.tbl_gamemaster.Count(e => e.gameId == id) > 0;
        }
    }
}