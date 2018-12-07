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
using BatchManagementDAL;

namespace BatchManagementWebAPI.Controllers
{
    public class BatchSchedulesController : ApiController
    {
        private BatchManagementEntities db = new BatchManagementEntities();

        // GET: api/BatchSchedules
        public IQueryable<BatchSchedule> GetBatchSchedules()
        {
            return db.BatchSchedules;
        }

        // GET: api/BatchSchedules/5
        [ResponseType(typeof(BatchSchedule))]
        public IHttpActionResult GetBatchSchedule(int id)
        {
            BatchSchedule batchSchedule = db.BatchSchedules.Find(id);
            if (batchSchedule == null)
            {
                return NotFound();
            }

            return Ok(batchSchedule);
        }

        // PUT: api/BatchSchedules/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBatchSchedule(int id, BatchSchedule batchSchedule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != batchSchedule.ScheduleId)
            {
                return BadRequest();
            }

            db.Entry(batchSchedule).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BatchScheduleExists(id))
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

        // POST: api/BatchSchedules
        [ResponseType(typeof(BatchSchedule))]
        public IHttpActionResult PostBatchSchedule(BatchSchedule batchSchedule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BatchSchedules.Add(batchSchedule);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = batchSchedule.ScheduleId }, batchSchedule);
        }

        // DELETE: api/BatchSchedules/5
        [ResponseType(typeof(BatchSchedule))]
        public IHttpActionResult DeleteBatchSchedule(int id)
        {
            BatchSchedule batchSchedule = db.BatchSchedules.Find(id);
            if (batchSchedule == null)
            {
                return NotFound();
            }

            db.BatchSchedules.Remove(batchSchedule);
            db.SaveChanges();

            return Ok(batchSchedule);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BatchScheduleExists(int id)
        {
            return db.BatchSchedules.Count(e => e.ScheduleId == id) > 0;
        }
    }
}