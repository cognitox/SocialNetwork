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
    public class QuestionnaireQuestionMultichoiceAnswersController : ApiController
    {
        private SDBOAppContext db = new SDBOAppContext();

        // GET: api/QuestionnaireQuestionMultichoiceAnswers
        public IQueryable<QuestionnaireQuestionMultichoiceAnswer> GetQuestionnaireQuestionMultichoiceAnswers()
        {
            return db.QuestionnaireQuestionMultichoiceAnswers;
        }

        // GET: api/QuestionnaireQuestionMultichoiceAnswers/5
        [ResponseType(typeof(QuestionnaireQuestionMultichoiceAnswer))]
        public IHttpActionResult GetQuestionnaireQuestionMultichoiceAnswer(Guid id)
        {
            QuestionnaireQuestionMultichoiceAnswer questionnaireQuestionMultichoiceAnswer = db.QuestionnaireQuestionMultichoiceAnswers.Find(id);
            if (questionnaireQuestionMultichoiceAnswer == null)
            {
                return NotFound();
            }

            return Ok(questionnaireQuestionMultichoiceAnswer);
        }

        // PUT: api/QuestionnaireQuestionMultichoiceAnswers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutQuestionnaireQuestionMultichoiceAnswer(Guid id, QuestionnaireQuestionMultichoiceAnswer questionnaireQuestionMultichoiceAnswer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != questionnaireQuestionMultichoiceAnswer.QuestionnaireQuestionMultichoiceAnswerID)
            {
                return BadRequest();
            }

            db.Entry(questionnaireQuestionMultichoiceAnswer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionnaireQuestionMultichoiceAnswerExists(id))
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

        // POST: api/QuestionnaireQuestionMultichoiceAnswers
        [ResponseType(typeof(QuestionnaireQuestionMultichoiceAnswer))]
        public IHttpActionResult PostQuestionnaireQuestionMultichoiceAnswer(QuestionnaireQuestionMultichoiceAnswer questionnaireQuestionMultichoiceAnswer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.QuestionnaireQuestionMultichoiceAnswers.Add(questionnaireQuestionMultichoiceAnswer);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (QuestionnaireQuestionMultichoiceAnswerExists(questionnaireQuestionMultichoiceAnswer.QuestionnaireQuestionMultichoiceAnswerID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = questionnaireQuestionMultichoiceAnswer.QuestionnaireQuestionMultichoiceAnswerID }, questionnaireQuestionMultichoiceAnswer);
        }

        // DELETE: api/QuestionnaireQuestionMultichoiceAnswers/5
        [ResponseType(typeof(QuestionnaireQuestionMultichoiceAnswer))]
        public IHttpActionResult DeleteQuestionnaireQuestionMultichoiceAnswer(Guid id)
        {
            QuestionnaireQuestionMultichoiceAnswer questionnaireQuestionMultichoiceAnswer = db.QuestionnaireQuestionMultichoiceAnswers.Find(id);
            if (questionnaireQuestionMultichoiceAnswer == null)
            {
                return NotFound();
            }

            db.QuestionnaireQuestionMultichoiceAnswers.Remove(questionnaireQuestionMultichoiceAnswer);
            db.SaveChanges();

            return Ok(questionnaireQuestionMultichoiceAnswer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuestionnaireQuestionMultichoiceAnswerExists(Guid id)
        {
            return db.QuestionnaireQuestionMultichoiceAnswers.Count(e => e.QuestionnaireQuestionMultichoiceAnswerID == id) > 0;
        }
    }
}