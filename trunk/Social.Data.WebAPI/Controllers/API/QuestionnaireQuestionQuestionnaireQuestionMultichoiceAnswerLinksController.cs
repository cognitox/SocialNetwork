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
    public class QuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLinksController : ApiController
    {
        private SDBOAppContext db = new SDBOAppContext();

        // GET: api/QuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLinks
        public IQueryable<QuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLink> GetQuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLinks()
        {
            return db.QuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLinks;
        }

        // GET: api/QuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLinks/5
        [ResponseType(typeof(QuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLink))]
        public IHttpActionResult GetQuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLink(Guid id)
        {
            QuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLink questionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLink = db.QuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLinks.Find(id);
            if (questionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLink == null)
            {
                return NotFound();
            }

            return Ok(questionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLink);
        }

        // PUT: api/QuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLinks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutQuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLink(Guid id, QuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLink questionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLink)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != questionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLink.QuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLinkID)
            {
                return BadRequest();
            }

            db.Entry(questionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLink).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLinkExists(id))
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

        // POST: api/QuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLinks
        [ResponseType(typeof(QuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLink))]
        public IHttpActionResult PostQuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLink(QuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLink questionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLink)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.QuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLinks.Add(questionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLink);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (QuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLinkExists(questionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLink.QuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLinkID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = questionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLink.QuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLinkID }, questionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLink);
        }

        // DELETE: api/QuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLinks/5
        [ResponseType(typeof(QuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLink))]
        public IHttpActionResult DeleteQuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLink(Guid id)
        {
            QuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLink questionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLink = db.QuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLinks.Find(id);
            if (questionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLink == null)
            {
                return NotFound();
            }

            db.QuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLinks.Remove(questionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLink);
            db.SaveChanges();

            return Ok(questionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLink);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLinkExists(Guid id)
        {
            return db.QuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLinks.Count(e => e.QuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLinkID == id) > 0;
        }
    }
}