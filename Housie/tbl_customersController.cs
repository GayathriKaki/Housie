using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Housie.Models;

namespace Housie
{
    public class tbl_customersController : Controller
    {
        private db_housieEntities db = new db_housieEntities();

        // GET: tbl_customers
        public async Task<ActionResult> Index()
        {
            return View(await db.tbl_customers.ToListAsync());
        }

        // GET: tbl_customers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_customers tbl_customers = await db.tbl_customers.FindAsync(id);
            if (tbl_customers == null)
            {
                return HttpNotFound();
            }
            return View(tbl_customers);
        }

        // GET: tbl_customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "custId,email,firstName,lastName,password,paypal_id,country,address,facebookLink,bool_emailstatus,dateTImestamp,phoneNum")] tbl_customers tbl_customers)
        {
            if (ModelState.IsValid)
            {
                db.tbl_customers.Add(tbl_customers);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tbl_customers);
        }

        // GET: tbl_customers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_customers tbl_customers = await db.tbl_customers.FindAsync(id);
            if (tbl_customers == null)
            {
                return HttpNotFound();
            }
            return View(tbl_customers);
        }

        // POST: tbl_customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "custId,email,firstName,lastName,password,paypal_id,country,address,facebookLink,bool_emailstatus,dateTImestamp,phoneNum")] tbl_customers tbl_customers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_customers).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tbl_customers);
        }

        // GET: tbl_customers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_customers tbl_customers = await db.tbl_customers.FindAsync(id);
            if (tbl_customers == null)
            {
                return HttpNotFound();
            }
            return View(tbl_customers);
        }

        // POST: tbl_customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tbl_customers tbl_customers = await db.tbl_customers.FindAsync(id);
            db.tbl_customers.Remove(tbl_customers);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
