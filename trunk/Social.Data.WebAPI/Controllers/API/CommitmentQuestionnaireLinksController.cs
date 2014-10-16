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
    public class CommitmentQuestionnaireLinksController : ApiController
    {
        private SDBOAppContext db = new SDBOAppContext();

        // GET: api/CommitmentQuestionnaireLinks
        public IQueryable<CommitmentQuestionnaireLink> GetCommitmentQuestionnaireLinks()
        {
            return db.CommitmentQuestionnaireLinks;
        }

        // GET: api/CommitmentQuestionnaireLinks/5
        [ResponseType(typeof(CommitmentQuestionnaireLink))]
        public IHttpActionResult GetCommitmentQuestionnaireLink(Guid id)
        {
            CommitmentQuestionnaireLink commitmentQuestionnaireLink = db.CommitmentQuestionnaireLinks.Find(id);
            if (commitmentQuestionnaireLink == null)
            {
                return NotFound();
            }

            return Ok(commitmentQuestionnaireLink);
        }

        // PUT: api/CommitmentQuestionnaireLinks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCommitmentQuestionnaireLink(Guid id, CommitmentQuestionnaireLink commitmentQuestionnaireLink)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != commitmentQuestionnaireLink.CommitmentQuestionnaireLinkID)
            {
                return BadRequest();
            }

            db.Entry(commitmentQuestionnaireLink).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommitmentQuestionnaireLinkExists(id))
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

        // POST: api/CommitmentQuestionnaireLinks
        [ResponseType(typeof(CommitmentQuestionnaireLink))]
        public IHttpActionResult PostCommitmentQuestionnaireLink(CommitmentQuestionnaireLink commitmentQuestionnaireLink)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CommitmentQuestionnaireLinks.Add(commitmentQuestionnaireLink);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CommitmentQuestionnaireLinkExists(commitmentQuestionnaireLink.CommitmentQuestionnaireLinkID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = commitmentQuestionnaireLink.CommitmentQuestionnaireLinkID }, commitmentQuestionnaireLink);
        }

        // DELETE: api/CommitmentQuestionnaireLinks/5
        [ResponseType(typeof(CommitmentQuestionnaireLink))]
        public IHttpActionResult DeleteCommitmentQuestionnaireLink(Guid id)
        {
            CommitmentQuestionnaireLink commitmentQuestionnaireLink = db.CommitmentQuestionnaireLinks.Find(id);
            if (commitmentQuestionnaireLink == null)
            {
                return NotFound();
            }

            db.CommitmentQuestionnaireLinks.Remove(commitmentQuestionnaireLink);
            db.SaveChanges();

            return Ok(commitmentQuestionnaireLink);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CommitmentQuestionnaireLinkExists(Guid id)
        {
            return db.CommitmentQuestionnaireLinks.Count(e => e.CommitmentQuestionnaireLinkID == id) > 0;
        }
    }
}