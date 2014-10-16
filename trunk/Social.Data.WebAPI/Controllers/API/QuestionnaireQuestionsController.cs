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
    public class QuestionnaireQuestionsController : ApiController
    {
        private SDBOAppContext db = new SDBOAppContext();

        // GET: api/QuestionnaireQuestions
        public IQueryable<QuestionnaireQuestion> GetQuestionnaireQuestions()
        {
            return db.QuestionnaireQuestions;
        }

        // GET: api/QuestionnaireQuestions/5
        [ResponseType(typeof(QuestionnaireQuestion))]
        public IHttpActionResult GetQuestionnaireQuestion(Guid id)
        {
            QuestionnaireQuestion questionnaireQuestion = db.QuestionnaireQuestions.Find(id);
            if (questionnaireQuestion == null)
            {
                return NotFound();
            }

            return Ok(questionnaireQuestion);
        }

        // PUT: api/QuestionnaireQuestions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutQuestionnaireQuestion(Guid id, QuestionnaireQuestion questionnaireQuestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != questionnaireQuestion.QuestionnaireQuestionID)
            {
                return BadRequest();
            }

            db.Entry(questionnaireQuestion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionnaireQuestionExists(id))
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

        // POST: api/QuestionnaireQuestions
        [ResponseType(typeof(QuestionnaireQuestion))]
        public IHttpActionResult PostQuestionnaireQuestion(QuestionnaireQuestion questionnaireQuestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.QuestionnaireQuestions.Add(questionnaireQuestion);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (QuestionnaireQuestionExists(questionnaireQuestion.QuestionnaireQuestionID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = questionnaireQuestion.QuestionnaireQuestionID }, questionnaireQuestion);
        }

        // DELETE: api/QuestionnaireQuestions/5
        [ResponseType(typeof(QuestionnaireQuestion))]
        public IHttpActionResult DeleteQuestionnaireQuestion(Guid id)
        {
            QuestionnaireQuestion questionnaireQuestion = db.QuestionnaireQuestions.Find(id);
            if (questionnaireQuestion == null)
            {
                return NotFound();
            }

            db.QuestionnaireQuestions.Remove(questionnaireQuestion);
            db.SaveChanges();

            return Ok(questionnaireQuestion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuestionnaireQuestionExists(Guid id)
        {
            return db.QuestionnaireQuestions.Count(e => e.QuestionnaireQuestionID == id) > 0;
        }
    }
}