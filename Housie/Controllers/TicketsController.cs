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
using Housie.Models;

namespace Housie.Controllers
{
    public class TicketsController : ApiController
    {
        private db_housieEntities db = new db_housieEntities();

        // GET: api/Tickets
        public IQueryable<tb_tickets> Gettb_tickets()
        {
            return db.tb_tickets;
        }

        // GET: api/Tickets/5
        [ResponseType(typeof(tb_tickets))]
        public IHttpActionResult Gettb_tickets(int id)
        {
            tb_tickets tb_tickets = db.tb_tickets.Find(id);
            if (tb_tickets == null)
            {
                return NotFound();
            }

            return Ok(tb_tickets);
        }

        // PUT: api/Tickets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttb_tickets(int id, tb_tickets tb_tickets)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tb_tickets.ticketId)
            {
                return BadRequest();
            }

            db.Entry(tb_tickets).State = System.Data.Entity.EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tb_ticketsExists(id))
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

        // POST: api/Tickets
        [ResponseType(typeof(tb_tickets))]
        public IHttpActionResult Posttb_tickets(tb_tickets tb_tickets)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tb_tickets.Add(tb_tickets);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tb_tickets.ticketId }, tb_tickets);
        }

        // DELETE: api/Tickets/5
        [ResponseType(typeof(tb_tickets))]
        public IHttpActionResult Deletetb_tickets(int id)
        {
            tb_tickets tb_tickets = db.tb_tickets.Find(id);
            if (tb_tickets == null)
            {
                return NotFound();
            }

            db.tb_tickets.Remove(tb_tickets);
            db.SaveChanges();

            return Ok(tb_tickets);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tb_ticketsExists(int id)
        {
            return db.tb_tickets.Count(e => e.ticketId == id) > 0;
        }
    }
}