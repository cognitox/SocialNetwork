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
    public class CommitmentTypesController : ApiController
    {
        private SDBOAppContext db = new SDBOAppContext();

        // GET: api/CommitmentTypes
        public IQueryable<CommitmentType> GetCommitmentTypes()
        {
            return db.CommitmentTypes;
        }

        // GET: api/CommitmentTypes/5
        [ResponseType(typeof(CommitmentType))]
        public IHttpActionResult GetCommitmentType(Guid id)
        {
            CommitmentType commitmentType = db.CommitmentTypes.Find(id);
            if (commitmentType == null)
            {
                return NotFound();
            }

            return Ok(commitmentType);
        }

        // PUT: api/CommitmentTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCommitmentType(Guid id, CommitmentType commitmentType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != commitmentType.CommitmentTypeID)
            {
                return BadRequest();
            }

            db.Entry(commitmentType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommitmentTypeExists(id))
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

        // POST: api/CommitmentTypes
        [ResponseType(typeof(CommitmentType))]
        public IHttpActionResult PostCommitmentType(CommitmentType commitmentType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CommitmentTypes.Add(commitmentType);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CommitmentTypeExists(commitmentType.CommitmentTypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = commitmentType.CommitmentTypeID }, commitmentType);
        }

        // DELETE: api/CommitmentTypes/5
        [ResponseType(typeof(CommitmentType))]
        public IHttpActionResult DeleteCommitmentType(Guid id)
        {
            CommitmentType commitmentType = db.CommitmentTypes.Find(id);
            if (commitmentType == null)
            {
                return NotFound();
            }

            db.CommitmentTypes.Remove(commitmentType);
            db.SaveChanges();

            return Ok(commitmentType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CommitmentTypeExists(Guid id)
        {
            return db.CommitmentTypes.Count(e => e.CommitmentTypeID == id) > 0;
        }
    }
}