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
    public class HourlyReadsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: HourlyReads + filter
        public async Task<ActionResult> Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            var hourlyReads = from hr in db.HourlyReads
                              select hr;
            if (!String.IsNullOrEmpty(searchString))
            {
                hourlyReads = hourlyReads.Where(hr => hr.MeterMeasureType.Contains(searchString)
                                       || hr.HourCounter.Contains(searchString));
            }
            return View(await hourlyReads.AsNoTracking().ToListAsync());
        }

        // GET: HourlyReads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HourlyRead hourlyRead = db.HourlyReads.Find(id);
            if (hourlyRead == null)
            {
                return HttpNotFound();
            }
            return View(hourlyRead);
        }

        // GET: HourlyReads/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HourlyReads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MeterNumber,MeterMeasureType,InstallationNumber,Timestamp,InfoCode,Comment,Energy,EnergyUnit,Volume,VolumeUnit,HourCounter,HourCounterUnit,TempForward,TempForwardUnit,TempReturn,TempReturnUnit,valueTempDiff,TempDiffUnit,Power,PowerUnit,Flow,FlowUnit,Peak,PeakUnit,ForwardedUsage,ForwardedUsageUnit,ReturnedUsage,ReturnedUsageUnit")] HourlyRead hourlyRead)
        {
            if (ModelState.IsValid)
            {
                db.HourlyReads.Add(hourlyRead);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hourlyRead);
        }

        // GET: HourlyReads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HourlyRead hourlyRead = db.HourlyReads.Find(id);
            if (hourlyRead == null)
            {
                return HttpNotFound();
            }
            return View(hourlyRead);
        }

        // POST: HourlyReads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MeterNumber,MeterMeasureType,InstallationNumber,Timestamp,InfoCode,Comment,Energy,EnergyUnit,Volume,VolumeUnit,HourCounter,HourCounterUnit,TempForward,TempForwardUnit,TempReturn,TempReturnUnit,valueTempDiff,TempDiffUnit,Power,PowerUnit,Flow,FlowUnit,Peak,PeakUnit,ForwardedUsage,ForwardedUsageUnit,ReturnedUsage,ReturnedUsageUnit")] HourlyRead hourlyRead)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hourlyRead).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hourlyRead);
        }

        // GET: HourlyReads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HourlyRead hourlyRead = db.HourlyReads.Find(id);
            if (hourlyRead == null)
            {
                return HttpNotFound();
            }
            return View(hourlyRead);
        }

        // POST: HourlyReads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HourlyRead hourlyRead = db.HourlyReads.Find(id);
            db.HourlyReads.Remove(hourlyRead);
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
