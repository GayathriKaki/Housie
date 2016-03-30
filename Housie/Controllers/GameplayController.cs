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
    public class GameplayController : ApiController
    {
        private db_housieEntities db = new db_housieEntities();

        // GET: api/Gameplay
        public IQueryable<tbl_gameplay> Gettbl_gameplay()
        {
            return db.tbl_gameplay;
        }

        // GET: api/Gameplay/5
        [ResponseType(typeof(tbl_gameplay))]
        public async Task<IHttpActionResult> Gettbl_gameplay(int id)
        {
            tbl_gameplay tbl_gameplay = await db.tbl_gameplay.FindAsync(id);
            if (tbl_gameplay == null)
            {
                return NotFound();
            }

            return Ok(tbl_gameplay);
        }

        // PUT: api/Gameplay/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Puttbl_gameplay(int id, tbl_gameplay tbl_gameplay)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_gameplay.id)
            {
                return BadRequest();
            }

            db.Entry(tbl_gameplay).State = System.Data.Entity.EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_gameplayExists(id))
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

        // POST: api/Gameplay
        [ResponseType(typeof(tbl_gameplay))]
        public async Task<IHttpActionResult> Posttbl_gameplay(tbl_gameplay tbl_gameplay)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_gameplay.Add(tbl_gameplay);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tbl_gameplay.id }, tbl_gameplay);
        }

        // DELETE: api/Gameplay/5
        [ResponseType(typeof(tbl_gameplay))]
        public async Task<IHttpActionResult> Deletetbl_gameplay(int id)
        {
            tbl_gameplay tbl_gameplay = await db.tbl_gameplay.FindAsync(id);
            if (tbl_gameplay == null)
            {
                return NotFound();
            }

            db.tbl_gameplay.Remove(tbl_gameplay);
            await db.SaveChangesAsync();

            return Ok(tbl_gameplay);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_gameplayExists(int id)
        {
            return db.tbl_gameplay.Count(e => e.id == id) > 0;
        }
    }
}