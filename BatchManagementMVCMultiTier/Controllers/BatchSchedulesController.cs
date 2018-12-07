using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net; 
using System.Web;
using System.Web.Mvc;
using BatchManagementDAL;

namespace BatchManagementMVCMultiTier.Controllers
{
    public class BatchSchedulesController : Controller
    {
        private BatchManagementEntities db = new BatchManagementEntities();

        // GET: BatchSchedules
        public ActionResult Index()
        {
            var batchSchedules = db.BatchSchedules.Include(b => b.Batch);
            return View(batchSchedules.ToList());
        }

        // GET: BatchSchedules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BatchSchedule batchSchedule = db.BatchSchedules.Find(id);
            if (batchSchedule == null)
            {
                return HttpNotFound();
            }
            return View(batchSchedule);
        }

        // GET: BatchSchedules/Create
        public ActionResult Create()
        {
            ViewBag.BatchId = new SelectList(db.Batches, "BatchId", "BatchName");
            return View();
        }

        // POST: BatchSchedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ScheduleId,BatchId,Date,HoursTaken,TopicsTaken")] BatchSchedule batchSchedule)
        {
            if (ModelState.IsValid)
            {
                db.BatchSchedules.Add(batchSchedule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BatchId = new SelectList(db.Batches, "BatchId", "BatchName", batchSchedule.BatchId);
            return View(batchSchedule);
        }

        // GET: BatchSchedules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BatchSchedule batchSchedule = db.BatchSchedules.Find(id);
            if (batchSchedule == null)
            {
                return HttpNotFound();
            }
            ViewBag.BatchId = new SelectList(db.Batches, "BatchId", "BatchName", batchSchedule.BatchId);
            return View(batchSchedule);
        }

        // POST: BatchSchedules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ScheduleId,BatchId,Date,HoursTaken,TopicsTaken")] BatchSchedule batchSchedule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(batchSchedule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BatchId = new SelectList(db.Batches, "BatchId", "BatchName", batchSchedule.BatchId);
            return View(batchSchedule);
        }

        // GET: BatchSchedules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BatchSchedule batchSchedule = db.BatchSchedules.Find(id);
            if (batchSchedule == null)
            {
                return HttpNotFound();
            }
            return View(batchSchedule);
        }

        // POST: BatchSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BatchSchedule batchSchedule = db.BatchSchedules.Find(id);
            db.BatchSchedules.Remove(batchSchedule);
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
