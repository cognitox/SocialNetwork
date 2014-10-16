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
    public class CommitmentTypeSubTypesController : ApiController
    {
        private SDBOAppContext db = new SDBOAppContext();

        // GET: api/CommitmentTypeSubTypes
        public IQueryable<CommitmentTypeSubType> GetCommitmentTypeSubTypes()
        {
            return db.CommitmentTypeSubTypes;
        }

        // GET: api/CommitmentTypeSubTypes/5
        [ResponseType(typeof(CommitmentTypeSubType))]
        public IHttpActionResult GetCommitmentTypeSubType(Guid id)
        {
            CommitmentTypeSubType commitmentTypeSubType = db.CommitmentTypeSubTypes.Find(id);
            if (commitmentTypeSubType == null)
            {
                return NotFound();
            }

            return Ok(commitmentTypeSubType);
        }

        // PUT: api/CommitmentTypeSubTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCommitmentTypeSubType(Guid id, CommitmentTypeSubType commitmentTypeSubType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != commitmentTypeSubType.CommitmentTypeSubTypeID)
            {
                return BadRequest();
            }

            db.Entry(commitmentTypeSubType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommitmentTypeSubTypeExists(id))
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

        // POST: api/CommitmentTypeSubTypes
        [ResponseType(typeof(CommitmentTypeSubType))]
        public IHttpActionResult PostCommitmentTypeSubType(CommitmentTypeSubType commitmentTypeSubType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CommitmentTypeSubTypes.Add(commitmentTypeSubType);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CommitmentTypeSubTypeExists(commitmentTypeSubType.CommitmentTypeSubTypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = commitmentTypeSubType.CommitmentTypeSubTypeID }, commitmentTypeSubType);
        }

        // DELETE: api/CommitmentTypeSubTypes/5
        [ResponseType(typeof(CommitmentTypeSubType))]
        public IHttpActionResult DeleteCommitmentTypeSubType(Guid id)
        {
            CommitmentTypeSubType commitmentTypeSubType = db.CommitmentTypeSubTypes.Find(id);
            if (commitmentTypeSubType == null)
            {
                return NotFound();
            }

            db.CommitmentTypeSubTypes.Remove(commitmentTypeSubType);
            db.SaveChanges();

            return Ok(commitmentTypeSubType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CommitmentTypeSubTypeExists(Guid id)
        {
            return db.CommitmentTypeSubTypes.Count(e => e.CommitmentTypeSubTypeID == id) > 0;
        }
    }
}