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
    public class CommitmentNoteTypesController : ApiController
    {
        private SDBOAppContext db = new SDBOAppContext();

        // GET: api/CommitmentNoteTypes
        public IQueryable<CommitmentNoteType> GetCommitmentNoteTypes()
        {
            return db.CommitmentNoteTypes;
        }

        // GET: api/CommitmentNoteTypes/5
        [ResponseType(typeof(CommitmentNoteType))]
        public IHttpActionResult GetCommitmentNoteType(Guid id)
        {
            CommitmentNoteType commitmentNoteType = db.CommitmentNoteTypes.Find(id);
            if (commitmentNoteType == null)
            {
                return NotFound();
            }

            return Ok(commitmentNoteType);
        }

        // PUT: api/CommitmentNoteTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCommitmentNoteType(Guid id, CommitmentNoteType commitmentNoteType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != commitmentNoteType.CommitmentNoteTypeID)
            {
                return BadRequest();
            }

            db.Entry(commitmentNoteType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommitmentNoteTypeExists(id))
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

        // POST: api/CommitmentNoteTypes
        [ResponseType(typeof(CommitmentNoteType))]
        public IHttpActionResult PostCommitmentNoteType(CommitmentNoteType commitmentNoteType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CommitmentNoteTypes.Add(commitmentNoteType);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CommitmentNoteTypeExists(commitmentNoteType.CommitmentNoteTypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = commitmentNoteType.CommitmentNoteTypeID }, commitmentNoteType);
        }

        // DELETE: api/CommitmentNoteTypes/5
        [ResponseType(typeof(CommitmentNoteType))]
        public IHttpActionResult DeleteCommitmentNoteType(Guid id)
        {
            CommitmentNoteType commitmentNoteType = db.CommitmentNoteTypes.Find(id);
            if (commitmentNoteType == null)
            {
                return NotFound();
            }

            db.CommitmentNoteTypes.Remove(commitmentNoteType);
            db.SaveChanges();

            return Ok(commitmentNoteType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CommitmentNoteTypeExists(Guid id)
        {
            return db.CommitmentNoteTypes.Count(e => e.CommitmentNoteTypeID == id) > 0;
        }
    }
}