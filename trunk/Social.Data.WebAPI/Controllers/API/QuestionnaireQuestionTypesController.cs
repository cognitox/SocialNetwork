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
    public class QuestionnaireQuestionTypesController : ApiController
    {
        private SDBOAppContext db = new SDBOAppContext();

        // GET: api/QuestionnaireQuestionTypes
        public IQueryable<QuestionnaireQuestionType> GetQuestionnaireQuestionTypes()
        {
            return db.QuestionnaireQuestionTypes;
        }

        // GET: api/QuestionnaireQuestionTypes/5
        [ResponseType(typeof(QuestionnaireQuestionType))]
        public IHttpActionResult GetQuestionnaireQuestionType(Guid id)
        {
            QuestionnaireQuestionType questionnaireQuestionType = db.QuestionnaireQuestionTypes.Find(id);
            if (questionnaireQuestionType == null)
            {
                return NotFound();
            }

            return Ok(questionnaireQuestionType);
        }

        // PUT: api/QuestionnaireQuestionTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutQuestionnaireQuestionType(Guid id, QuestionnaireQuestionType questionnaireQuestionType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != questionnaireQuestionType.QuestionnaireQuestionTypeID)
            {
                return BadRequest();
            }

            db.Entry(questionnaireQuestionType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionnaireQuestionTypeExists(id))
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

        // POST: api/QuestionnaireQuestionTypes
        [ResponseType(typeof(QuestionnaireQuestionType))]
        public IHttpActionResult PostQuestionnaireQuestionType(QuestionnaireQuestionType questionnaireQuestionType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.QuestionnaireQuestionTypes.Add(questionnaireQuestionType);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (QuestionnaireQuestionTypeExists(questionnaireQuestionType.QuestionnaireQuestionTypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = questionnaireQuestionType.QuestionnaireQuestionTypeID }, questionnaireQuestionType);
        }

        // DELETE: api/QuestionnaireQuestionTypes/5
        [ResponseType(typeof(QuestionnaireQuestionType))]
        public IHttpActionResult DeleteQuestionnaireQuestionType(Guid id)
        {
            QuestionnaireQuestionType questionnaireQuestionType = db.QuestionnaireQuestionTypes.Find(id);
            if (questionnaireQuestionType == null)
            {
                return NotFound();
            }

            db.QuestionnaireQuestionTypes.Remove(questionnaireQuestionType);
            db.SaveChanges();

            return Ok(questionnaireQuestionType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuestionnaireQuestionTypeExists(Guid id)
        {
            return db.QuestionnaireQuestionTypes.Count(e => e.QuestionnaireQuestionTypeID == id) > 0;
        }
    }
}