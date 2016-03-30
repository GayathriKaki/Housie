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
    public class CustomersController : ApiController
    {
        private db_housieEntities db = new db_housieEntities();

        // GET: api/Customers
        public IQueryable<tbl_customers> Gettbl_customers()
        {
            return db.tbl_customers;
        }

        // GET: api/Customers/5
        [ResponseType(typeof(tbl_customers))]
        public async Task<IHttpActionResult> Gettbl_customers(int id)
        {
            tbl_customers tbl_customers = await db.tbl_customers.FindAsync(id);
            if (tbl_customers == null)
            {
                return NotFound();
            }

            return Ok(tbl_customers);
        }

        // GET: api/Customers/5
        [ResponseType(typeof(tbl_customers))]
        public  async Task<IHttpActionResult> Logintbl_customers(tbl_customers tbl_cust)
        {
          

            // var  cust = await db.tbl_customers(){ email=tbl_cust.email ,password=tbl_cust.password}
            var cust=  new tbl_customers() { email = tbl_cust.email,  password = tbl_cust.password };

            // var custdata = await cust;
            if (cust == null)
            {
                return NotFound();
            }

            return Ok(cust);
        }

        // PUT: api/Customers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Puttbl_customers(int id, tbl_customers tbl_customers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_customers.custId)
            {
                return BadRequest();
            }

            db.Entry(tbl_customers).State = System.Data.Entity.EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_customersExists(id))
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

        // POST: api/Customers
        [ResponseType(typeof(tbl_customers))]
        public async Task<IHttpActionResult> Posttbl_customers(tbl_customers tbl_customers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_customers.Add(tbl_customers);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tbl_customers.custId }, tbl_customers);
        }

        // DELETE: api/Customers/5
        [ResponseType(typeof(tbl_customers))]
        public async Task<IHttpActionResult> Deletetbl_customers(int id)
        {
            tbl_customers tbl_customers = await db.tbl_customers.FindAsync(id);
            if (tbl_customers == null)
            {
                return NotFound();
            }

            db.tbl_customers.Remove(tbl_customers);
            await db.SaveChangesAsync();

            return Ok(tbl_customers);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_customersExists(int id)
        {
            return db.tbl_customers.Count(e => e.custId == id) > 0;
        }
    }
}