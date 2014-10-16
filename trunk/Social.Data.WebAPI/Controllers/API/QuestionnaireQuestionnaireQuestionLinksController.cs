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
    public class QuestionnaireQuestionnaireQuestionLinksController : ApiController
    {
        private SDBOAppContext db = new SDBOAppContext();

        // GET: api/QuestionnaireQuestionnaireQuestionLinks
        public IQueryable<QuestionnaireQuestionnaireQuestionLink> GetQuestionnaireQuestionnaireQuestionLinks()
        {
            return db.QuestionnaireQuestionnaireQuestionLinks;
        }

        // GET: api/QuestionnaireQuestionnaireQuestionLinks/5
        [ResponseType(typeof(QuestionnaireQuestionnaireQuestionLink))]
        public IHttpActionResult GetQuestionnaireQuestionnaireQuestionLink(Guid id)
        {
            QuestionnaireQuestionnaireQuestionLink questionnaireQuestionnaireQuestionLink = db.QuestionnaireQuestionnaireQuestionLinks.Find(id);
            if (questionnaireQuestionnaireQuestionLink == null)
            {
                return NotFound();
            }

            return Ok(questionnaireQuestionnaireQuestionLink);
        }

        // PUT: api/QuestionnaireQuestionnaireQuestionLinks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutQuestionnaireQuestionnaireQuestionLink(Guid id, QuestionnaireQuestionnaireQuestionLink questionnaireQuestionnaireQuestionLink)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != questionnaireQuestionnaireQuestionLink.QuestionnaireQuestionnaireQuestionLinkID)
            {
                return BadRequest();
            }

            db.Entry(questionnaireQuestionnaireQuestionLink).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionnaireQuestionnaireQuestionLinkExists(id))
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

        // POST: api/QuestionnaireQuestionnaireQuestionLinks
        [ResponseType(typeof(QuestionnaireQuestionnaireQuestionLink))]
        public IHttpActionResult PostQuestionnaireQuestionnaireQuestionLink(QuestionnaireQuestionnaireQuestionLink questionnaireQuestionnaireQuestionLink)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.QuestionnaireQuestionnaireQuestionLinks.Add(questionnaireQuestionnaireQuestionLink);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (QuestionnaireQuestionnaireQuestionLinkExists(questionnaireQuestionnaireQuestionLink.QuestionnaireQuestionnaireQuestionLinkID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = questionnaireQuestionnaireQuestionLink.QuestionnaireQuestionnaireQuestionLinkID }, questionnaireQuestionnaireQuestionLink);
        }

        // DELETE: api/QuestionnaireQuestionnaireQuestionLinks/5
        [ResponseType(typeof(QuestionnaireQuestionnaireQuestionLink))]
        public IHttpActionResult DeleteQuestionnaireQuestionnaireQuestionLink(Guid id)
        {
            QuestionnaireQuestionnaireQuestionLink questionnaireQuestionnaireQuestionLink = db.QuestionnaireQuestionnaireQuestionLinks.Find(id);
            if (questionnaireQuestionnaireQuestionLink == null)
            {
                return NotFound();
            }

            db.QuestionnaireQuestionnaireQuestionLinks.Remove(questionnaireQuestionnaireQuestionLink);
            db.SaveChanges();

            return Ok(questionnaireQuestionnaireQuestionLink);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuestionnaireQuestionnaireQuestionLinkExists(Guid id)
        {
            return db.QuestionnaireQuestionnaireQuestionLinks.Count(e => e.QuestionnaireQuestionnaireQuestionLinkID == id) > 0;
        }
    }
}