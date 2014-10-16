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
    public class CommitmentQuestionnaireLinkTypesController : ApiController
    {
        private SDBOAppContext db = new SDBOAppContext();

        // GET: api/CommitmentQuestionnaireLinkTypes
        public IQueryable<CommitmentQuestionnaireLinkType> GetCommitmentQuestionnaireLinkTypes()
        {
            return db.CommitmentQuestionnaireLinkTypes;
        }

        // GET: api/CommitmentQuestionnaireLinkTypes/5
        [ResponseType(typeof(CommitmentQuestionnaireLinkType))]
        public IHttpActionResult GetCommitmentQuestionnaireLinkType(Guid id)
        {
            CommitmentQuestionnaireLinkType commitmentQuestionnaireLinkType = db.CommitmentQuestionnaireLinkTypes.Find(id);
            if (commitmentQuestionnaireLinkType == null)
            {
                return NotFound();
            }

            return Ok(commitmentQuestionnaireLinkType);
        }

        // PUT: api/CommitmentQuestionnaireLinkTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCommitmentQuestionnaireLinkType(Guid id, CommitmentQuestionnaireLinkType commitmentQuestionnaireLinkType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != commitmentQuestionnaireLinkType.CommitmentQuestionnaireLinkTypeID)
            {
                return BadRequest();
            }

            db.Entry(commitmentQuestionnaireLinkType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommitmentQuestionnaireLinkTypeExists(id))
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

        // POST: api/CommitmentQuestionnaireLinkTypes
        [ResponseType(typeof(CommitmentQuestionnaireLinkType))]
        public IHttpActionResult PostCommitmentQuestionnaireLinkType(CommitmentQuestionnaireLinkType commitmentQuestionnaireLinkType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CommitmentQuestionnaireLinkTypes.Add(commitmentQuestionnaireLinkType);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CommitmentQuestionnaireLinkTypeExists(commitmentQuestionnaireLinkType.CommitmentQuestionnaireLinkTypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = commitmentQuestionnaireLinkType.CommitmentQuestionnaireLinkTypeID }, commitmentQuestionnaireLinkType);
        }

        // DELETE: api/CommitmentQuestionnaireLinkTypes/5
        [ResponseType(typeof(CommitmentQuestionnaireLinkType))]
        public IHttpActionResult DeleteCommitmentQuestionnaireLinkType(Guid id)
        {
            CommitmentQuestionnaireLinkType commitmentQuestionnaireLinkType = db.CommitmentQuestionnaireLinkTypes.Find(id);
            if (commitmentQuestionnaireLinkType == null)
            {
                return NotFound();
            }

            db.CommitmentQuestionnaireLinkTypes.Remove(commitmentQuestionnaireLinkType);
            db.SaveChanges();

            return Ok(commitmentQuestionnaireLinkType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CommitmentQuestionnaireLinkTypeExists(Guid id)
        {
            return db.CommitmentQuestionnaireLinkTypes.Count(e => e.CommitmentQuestionnaireLinkTypeID == id) > 0;
        }
    }
}