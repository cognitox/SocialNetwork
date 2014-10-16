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
    public class SDBOVersionsController : ApiController
    {
        private SDBOAppContext db = new SDBOAppContext();

        // GET: api/SDBOVersions
        public IQueryable<SDBOVersion> GetSDBOVersions()
        {
            return db.SDBOVersions;
        }

        // GET: api/SDBOVersions/5
        [ResponseType(typeof(SDBOVersion))]
        public IHttpActionResult GetSDBOVersion(long id)
        {
            SDBOVersion sDBOVersion = db.SDBOVersions.Find(id);
            if (sDBOVersion == null)
            {
                return NotFound();
            }

            return Ok(sDBOVersion);
        }

        // PUT: api/SDBOVersions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSDBOVersion(long id, SDBOVersion sDBOVersion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sDBOVersion.id)
            {
                return BadRequest();
            }

            db.Entry(sDBOVersion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SDBOVersionExists(id))
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

        // POST: api/SDBOVersions
        [ResponseType(typeof(SDBOVersion))]
        public IHttpActionResult PostSDBOVersion(SDBOVersion sDBOVersion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SDBOVersions.Add(sDBOVersion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sDBOVersion.id }, sDBOVersion);
        }

        // DELETE: api/SDBOVersions/5
        [ResponseType(typeof(SDBOVersion))]
        public IHttpActionResult DeleteSDBOVersion(long id)
        {
            SDBOVersion sDBOVersion = db.SDBOVersions.Find(id);
            if (sDBOVersion == null)
            {
                return NotFound();
            }

            db.SDBOVersions.Remove(sDBOVersion);
            db.SaveChanges();

            return Ok(sDBOVersion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SDBOVersionExists(long id)
        {
            return db.SDBOVersions.Count(e => e.id == id) > 0;
        }
    }
}