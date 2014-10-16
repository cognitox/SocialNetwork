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
using Social.Data.WebAPI.DatabaseContext;

namespace Social.Data.WebAPI.Controllers.API
{
    [Authorize]
    public class SDBOScriptsRunsController : ApiController
    {
        private SDBOAppContext db = new SDBOAppContext();

        // GET: api/SDBOScriptsRuns
        public IQueryable<SDBOScriptsRun> GetSDBOScriptsRuns()
        {
            return db.SDBOScriptsRuns;
        }

        // GET: api/SDBOScriptsRuns/5
        [ResponseType(typeof(SDBOScriptsRun))]
        public IHttpActionResult GetSDBOScriptsRun(long id)
        {
            SDBOScriptsRun sDBOScriptsRun = db.SDBOScriptsRuns.Find(id);
            if (sDBOScriptsRun == null)
            {
                return NotFound();
            }

            return Ok(sDBOScriptsRun);
        }

        // PUT: api/SDBOScriptsRuns/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSDBOScriptsRun(long id, SDBOScriptsRun sDBOScriptsRun)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sDBOScriptsRun.id)
            {
                return BadRequest();
            }

            db.Entry(sDBOScriptsRun).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SDBOScriptsRunExists(id))
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

        // POST: api/SDBOScriptsRuns
        [ResponseType(typeof(SDBOScriptsRun))]
        public IHttpActionResult PostSDBOScriptsRun(SDBOScriptsRun sDBOScriptsRun)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SDBOScriptsRuns.Add(sDBOScriptsRun);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sDBOScriptsRun.id }, sDBOScriptsRun);
        }

        // DELETE: api/SDBOScriptsRuns/5
        [ResponseType(typeof(SDBOScriptsRun))]
        public IHttpActionResult DeleteSDBOScriptsRun(long id)
        {
            SDBOScriptsRun sDBOScriptsRun = db.SDBOScriptsRuns.Find(id);
            if (sDBOScriptsRun == null)
            {
                return NotFound();
            }

            db.SDBOScriptsRuns.Remove(sDBOScriptsRun);
            db.SaveChanges();

            return Ok(sDBOScriptsRun);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SDBOScriptsRunExists(long id)
        {
            return db.SDBOScriptsRuns.Count(e => e.id == id) > 0;
        }
    }
}