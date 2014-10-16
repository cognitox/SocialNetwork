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
    public class CommitmentStatusTypesController : ApiController
    {
        private SDBOAppContext db = new SDBOAppContext();

        // GET: api/CommitmentStatusTypes
        public IQueryable<CommitmentStatusType> GetCommitmentStatusTypes()
        {
            return db.CommitmentStatusTypes;
        }

        // GET: api/CommitmentStatusTypes/5
        [ResponseType(typeof(CommitmentStatusType))]
        public IHttpActionResult GetCommitmentStatusType(Guid id)
        {
            CommitmentStatusType commitmentStatusType = db.CommitmentStatusTypes.Find(id);
            if (commitmentStatusType == null)
            {
                return NotFound();
            }

            return Ok(commitmentStatusType);
        }

        // PUT: api/CommitmentStatusTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCommitmentStatusType(Guid id, CommitmentStatusType commitmentStatusType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != commitmentStatusType.CommitmentStatusTypeID)
            {
                return BadRequest();
            }

            db.Entry(commitmentStatusType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommitmentStatusTypeExists(id))
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

        // POST: api/CommitmentStatusTypes
        [ResponseType(typeof(CommitmentStatusType))]
        public IHttpActionResult PostCommitmentStatusType(CommitmentStatusType commitmentStatusType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CommitmentStatusTypes.Add(commitmentStatusType);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CommitmentStatusTypeExists(commitmentStatusType.CommitmentStatusTypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = commitmentStatusType.CommitmentStatusTypeID }, commitmentStatusType);
        }

        // DELETE: api/CommitmentStatusTypes/5
        [ResponseType(typeof(CommitmentStatusType))]
        public IHttpActionResult DeleteCommitmentStatusType(Guid id)
        {
            CommitmentStatusType commitmentStatusType = db.CommitmentStatusTypes.Find(id);
            if (commitmentStatusType == null)
            {
                return NotFound();
            }

            db.CommitmentStatusTypes.Remove(commitmentStatusType);
            db.SaveChanges();

            return Ok(commitmentStatusType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CommitmentStatusTypeExists(Guid id)
        {
            return db.CommitmentStatusTypes.Count(e => e.CommitmentStatusTypeID == id) > 0;
        }
    }
}