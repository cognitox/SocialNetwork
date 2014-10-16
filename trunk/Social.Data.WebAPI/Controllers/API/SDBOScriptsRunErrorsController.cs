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
    public class SDBOScriptsRunErrorsController : ApiController
    {
        private SDBOAppContext db = new SDBOAppContext();

        // GET: api/SDBOScriptsRunErrors
        public IQueryable<SDBOScriptsRunError> GetSDBOScriptsRunErrors()
        {
            return db.SDBOScriptsRunErrors;
        }

        // GET: api/SDBOScriptsRunErrors/5
        [ResponseType(typeof(SDBOScriptsRunError))]
        public IHttpActionResult GetSDBOScriptsRunError(long id)
        {
            SDBOScriptsRunError sDBOScriptsRunError = db.SDBOScriptsRunErrors.Find(id);
            if (sDBOScriptsRunError == null)
            {
                return NotFound();
            }

            return Ok(sDBOScriptsRunError);
        }

        // PUT: api/SDBOScriptsRunErrors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSDBOScriptsRunError(long id, SDBOScriptsRunError sDBOScriptsRunError)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sDBOScriptsRunError.id)
            {
                return BadRequest();
            }

            db.Entry(sDBOScriptsRunError).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SDBOScriptsRunErrorExists(id))
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

        // POST: api/SDBOScriptsRunErrors
        [ResponseType(typeof(SDBOScriptsRunError))]
        public IHttpActionResult PostSDBOScriptsRunError(SDBOScriptsRunError sDBOScriptsRunError)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SDBOScriptsRunErrors.Add(sDBOScriptsRunError);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sDBOScriptsRunError.id }, sDBOScriptsRunError);
        }

        // DELETE: api/SDBOScriptsRunErrors/5
        [ResponseType(typeof(SDBOScriptsRunError))]
        public IHttpActionResult DeleteSDBOScriptsRunError(long id)
        {
            SDBOScriptsRunError sDBOScriptsRunError = db.SDBOScriptsRunErrors.Find(id);
            if (sDBOScriptsRunError == null)
            {
                return NotFound();
            }

            db.SDBOScriptsRunErrors.Remove(sDBOScriptsRunError);
            db.SaveChanges();

            return Ok(sDBOScriptsRunError);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SDBOScriptsRunErrorExists(long id)
        {
            return db.SDBOScriptsRunErrors.Count(e => e.id == id) > 0;
        }
    }
}