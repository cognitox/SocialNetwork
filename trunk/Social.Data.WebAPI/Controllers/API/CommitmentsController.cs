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
    public class CommitmentsController : ApiController
    {
        private SDBOAppContext db = new SDBOAppContext();

        // GET: api/Commitments
        public IQueryable<Commitment> GetCommitments()
        {
            return db.Commitments;
        }

        // GET: api/Commitments/5
        [ResponseType(typeof(Commitment))]
        public IHttpActionResult GetCommitment(Guid id)
        {
            Commitment commitment = db.Commitments.Find(id);
            if (commitment == null)
            {
                return NotFound();
            }

            return Ok(commitment);
        }

        // PUT: api/Commitments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCommitment(Guid id, Commitment commitment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != commitment.CommitmentID)
            {
                return BadRequest();
            }

            db.Entry(commitment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommitmentExists(id))
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

        // POST: api/Commitments
        [ResponseType(typeof(Commitment))]
        public IHttpActionResult PostCommitment(Commitment commitment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Commitments.Add(commitment);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CommitmentExists(commitment.CommitmentID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = commitment.CommitmentID }, commitment);
        }

        // DELETE: api/Commitments/5
        [ResponseType(typeof(Commitment))]
        public IHttpActionResult DeleteCommitment(Guid id)
        {
            Commitment commitment = db.Commitments.Find(id);
            if (commitment == null)
            {
                return NotFound();
            }

            db.Commitments.Remove(commitment);
            db.SaveChanges();

            return Ok(commitment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CommitmentExists(Guid id)
        {
            return db.Commitments.Count(e => e.CommitmentID == id) > 0;
        }
    }
}