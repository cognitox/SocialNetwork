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
    public class CommitmentNotesController : ApiController
    {
        private SDBOAppContext db = new SDBOAppContext();

        // GET: api/CommitmentNotes
        public IQueryable<CommitmentNote> GetCommitmentNotes()
        {
            return db.CommitmentNotes;
        }

        // GET: api/CommitmentNotes/5
        [ResponseType(typeof(CommitmentNote))]
        public IHttpActionResult GetCommitmentNote(Guid id)
        {
            CommitmentNote commitmentNote = db.CommitmentNotes.Find(id);
            if (commitmentNote == null)
            {
                return NotFound();
            }

            return Ok(commitmentNote);
        }

        // PUT: api/CommitmentNotes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCommitmentNote(Guid id, CommitmentNote commitmentNote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != commitmentNote.CommitmentNoteID)
            {
                return BadRequest();
            }

            db.Entry(commitmentNote).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommitmentNoteExists(id))
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

        // POST: api/CommitmentNotes
        [ResponseType(typeof(CommitmentNote))]
        public IHttpActionResult PostCommitmentNote(CommitmentNote commitmentNote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CommitmentNotes.Add(commitmentNote);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CommitmentNoteExists(commitmentNote.CommitmentNoteID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = commitmentNote.CommitmentNoteID }, commitmentNote);
        }

        // DELETE: api/CommitmentNotes/5
        [ResponseType(typeof(CommitmentNote))]
        public IHttpActionResult DeleteCommitmentNote(Guid id)
        {
            CommitmentNote commitmentNote = db.CommitmentNotes.Find(id);
            if (commitmentNote == null)
            {
                return NotFound();
            }

            db.CommitmentNotes.Remove(commitmentNote);
            db.SaveChanges();

            return Ok(commitmentNote);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CommitmentNoteExists(Guid id)
        {
            return db.CommitmentNotes.Count(e => e.CommitmentNoteID == id) > 0;
        }
    }
}