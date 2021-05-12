using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TAO_CSV_v06.Models;

namespace TAO_CSV_v06.Controllers
{
    public class DailyReadsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize]
        // GET: DailyReads
        public async Task<ActionResult> Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            var dailyReads = from hr in db.DailyReads
                             select hr;
            if (!String.IsNullOrEmpty(searchString))
            {
                dailyReads = dailyReads.Where(hr => hr.Col_2.Contains(searchString)
                                       || hr.Col_6.Contains(searchString));
            }
            return View(await dailyReads.AsNoTracking().ToListAsync());
        }

        // GET: DailyReads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DailyRead dailyRead = db.DailyReads.Find(id);
            if (dailyRead == null)
            {
                return HttpNotFound();
            }
            return View(dailyRead);
        }

        // GET: DailyReads/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DailyReads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Col_0,Col_1,Col_2,Col_3,Col_4,Col_5,Col_6,Col_7,Col_8,Col_9,Col_10,Col_11,Col_12,Col_13,Col_14,Col_15,Col_16,Col_17,Col_18,Col_19,Col_20,Col_21,Col_22,Col_23,Col_24,Col_25,Col_26,Col_27,Col_28,Col_29,Col_30")] DailyRead dailyRead)
        {
            if (ModelState.IsValid)
            {
                db.DailyReads.Add(dailyRead);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dailyRead);
        }

        // GET: DailyReads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DailyRead dailyRead = db.DailyReads.Find(id);
            if (dailyRead == null)
            {
                return HttpNotFound();
            }
            return View(dailyRead);
        }

        // POST: DailyReads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Col_0,Col_1,Col_2,Col_3,Col_4,Col_5,Col_6,Col_7,Col_8,Col_9,Col_10,Col_11,Col_12,Col_13,Col_14,Col_15,Col_16,Col_17,Col_18,Col_19,Col_20,Col_21,Col_22,Col_23,Col_24,Col_25,Col_26,Col_27,Col_28,Col_29,Col_30")] DailyRead dailyRead)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dailyRead).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dailyRead);
        }

        // GET: DailyReads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DailyRead dailyRead = db.DailyReads.Find(id);
            if (dailyRead == null)
            {
                return HttpNotFound();
            }
            return View(dailyRead);
        }

        // POST: DailyReads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DailyRead dailyRead = db.DailyReads.Find(id);
            db.DailyReads.Remove(dailyRead);
            db.SaveChanges();
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
