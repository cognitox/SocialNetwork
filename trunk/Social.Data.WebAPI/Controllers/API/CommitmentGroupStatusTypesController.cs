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
    public class CommitmentGroupStatusTypesController : ApiController
    {
        private SDBOAppContext db = new SDBOAppContext();

        // GET: api/CommitmentGroupStatusTypes
        public IQueryable<CommitmentGroupStatusType> GetCommitmentGroupStatusTypes()
        {
            return db.CommitmentGroupStatusTypes;
        }

        // GET: api/CommitmentGroupStatusTypes/5
        [ResponseType(typeof(CommitmentGroupStatusType))]
        public IHttpActionResult GetCommitmentGroupStatusType(Guid id)
        {
            CommitmentGroupStatusType commitmentGroupStatusType = db.CommitmentGroupStatusTypes.Find(id);
            if (commitmentGroupStatusType == null)
            {
                return NotFound();
            }

            return Ok(commitmentGroupStatusType);
        }

        // PUT: api/CommitmentGroupStatusTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCommitmentGroupStatusType(Guid id, CommitmentGroupStatusType commitmentGroupStatusType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != commitmentGroupStatusType.CommitmentGroupStatusTypeID)
            {
                return BadRequest();
            }

            db.Entry(commitmentGroupStatusType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommitmentGroupStatusTypeExists(id))
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

        // POST: api/CommitmentGroupStatusTypes
        [ResponseType(typeof(CommitmentGroupStatusType))]
        public IHttpActionResult PostCommitmentGroupStatusType(CommitmentGroupStatusType commitmentGroupStatusType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CommitmentGroupStatusTypes.Add(commitmentGroupStatusType);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CommitmentGroupStatusTypeExists(commitmentGroupStatusType.CommitmentGroupStatusTypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = commitmentGroupStatusType.CommitmentGroupStatusTypeID }, commitmentGroupStatusType);
        }

        // DELETE: api/CommitmentGroupStatusTypes/5
        [ResponseType(typeof(CommitmentGroupStatusType))]
        public IHttpActionResult DeleteCommitmentGroupStatusType(Guid id)
        {
            CommitmentGroupStatusType commitmentGroupStatusType = db.CommitmentGroupStatusTypes.Find(id);
            if (commitmentGroupStatusType == null)
            {
                return NotFound();
            }

            db.CommitmentGroupStatusTypes.Remove(commitmentGroupStatusType);
            db.SaveChanges();

            return Ok(commitmentGroupStatusType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CommitmentGroupStatusTypeExists(Guid id)
        {
            return db.CommitmentGroupStatusTypes.Count(e => e.CommitmentGroupStatusTypeID == id) > 0;
        }
    }
}