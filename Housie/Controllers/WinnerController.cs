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
    public class WinnerController : ApiController
    {
        private db_housieEntities db = new db_housieEntities();

        // GET: api/Winner
        public IQueryable<tbl_winner> Gettbl_winner()
        {
            return db.tbl_winner;
        }

        // GET: api/Winner/5
        [ResponseType(typeof(tbl_winner))]
        public async Task<IHttpActionResult> Gettbl_winner(int id)
        {
            tbl_winner tbl_winner = await db.tbl_winner.FindAsync(id);
            if (tbl_winner == null)
            {
                return NotFound();
            }

            return Ok(tbl_winner);
        }

        // PUT: api/Winner/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Puttbl_winner(int id, tbl_winner tbl_winner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_winner.id)
            {
                return BadRequest();
            }

            db.Entry(tbl_winner).State = System.Data.Entity.EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_winnerExists(id))
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

        // POST: api/Winner
        [ResponseType(typeof(tbl_winner))]
        public async Task<IHttpActionResult> Posttbl_winner(tbl_winner tbl_winner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_winner.Add(tbl_winner);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tbl_winner.id }, tbl_winner);
        }

        // DELETE: api/Winner/5
        [ResponseType(typeof(tbl_winner))]
        public async Task<IHttpActionResult> Deletetbl_winner(int id)
        {
            tbl_winner tbl_winner = await db.tbl_winner.FindAsync(id);
            if (tbl_winner == null)
            {
                return NotFound();
            }

            db.tbl_winner.Remove(tbl_winner);
            await db.SaveChangesAsync();

            return Ok(tbl_winner);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_winnerExists(int id)
        {
            return db.tbl_winner.Count(e => e.id == id) > 0;
        }
    }
}