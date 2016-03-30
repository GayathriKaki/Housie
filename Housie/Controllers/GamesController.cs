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
    public class GamesController : ApiController
    {
        private db_housieEntities db = new db_housieEntities();

        // GET: api/Games
        public IQueryable<tbl_games> Gettbl_games()
        {
            return db.tbl_games;
        }

        // GET: api/Games/5
        [ResponseType(typeof(tbl_games))]
        public async Task<IHttpActionResult> Gettbl_games(int id)
        {
            tbl_games tbl_games = await db.tbl_games.FindAsync(id);
            if (tbl_games == null)
            {
                return NotFound();
            }

            return Ok(tbl_games);
        }

        // PUT: api/Games/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Puttbl_games(int id, tbl_games tbl_games)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_games.id)
            {
                return BadRequest();
            }

            db.Entry(tbl_games).State = System.Data.Entity.EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_gamesExists(id))
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

        // POST: api/Games
        [ResponseType(typeof(tbl_games))]
        public async Task<IHttpActionResult> Posttbl_games(tbl_games tbl_games)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_games.Add(tbl_games);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tbl_games.id }, tbl_games);
        }

        // DELETE: api/Games/5
        [ResponseType(typeof(tbl_games))]
        public async Task<IHttpActionResult> Deletetbl_games(int id)
        {
            tbl_games tbl_games = await db.tbl_games.FindAsync(id);
            if (tbl_games == null)
            {
                return NotFound();
            }

            db.tbl_games.Remove(tbl_games);
            await db.SaveChangesAsync();

            return Ok(tbl_games);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_gamesExists(int id)
        {
            return db.tbl_games.Count(e => e.id == id) > 0;
        }
    }
}