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
    public class QuestionnaireQuestionAnswerTypesController : ApiController
    {
        private SDBOAppContext db = new SDBOAppContext();

        // GET: api/QuestionnaireQuestionAnswerTypes
        public IQueryable<QuestionnaireQuestionAnswerType> GetQuestionnaireQuestionAnswerTypes()
        {
            return db.QuestionnaireQuestionAnswerTypes;
        }

        // GET: api/QuestionnaireQuestionAnswerTypes/5
        [ResponseType(typeof(QuestionnaireQuestionAnswerType))]
        public IHttpActionResult GetQuestionnaireQuestionAnswerType(Guid id)
        {
            QuestionnaireQuestionAnswerType questionnaireQuestionAnswerType = db.QuestionnaireQuestionAnswerTypes.Find(id);
            if (questionnaireQuestionAnswerType == null)
            {
                return NotFound();
            }

            return Ok(questionnaireQuestionAnswerType);
        }

        // PUT: api/QuestionnaireQuestionAnswerTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutQuestionnaireQuestionAnswerType(Guid id, QuestionnaireQuestionAnswerType questionnaireQuestionAnswerType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != questionnaireQuestionAnswerType.QuestionnaireQuestionAnswerTypeID)
            {
                return BadRequest();
            }

            db.Entry(questionnaireQuestionAnswerType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionnaireQuestionAnswerTypeExists(id))
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

        // POST: api/QuestionnaireQuestionAnswerTypes
        [ResponseType(typeof(QuestionnaireQuestionAnswerType))]
        public IHttpActionResult PostQuestionnaireQuestionAnswerType(QuestionnaireQuestionAnswerType questionnaireQuestionAnswerType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.QuestionnaireQuestionAnswerTypes.Add(questionnaireQuestionAnswerType);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (QuestionnaireQuestionAnswerTypeExists(questionnaireQuestionAnswerType.QuestionnaireQuestionAnswerTypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = questionnaireQuestionAnswerType.QuestionnaireQuestionAnswerTypeID }, questionnaireQuestionAnswerType);
        }

        // DELETE: api/QuestionnaireQuestionAnswerTypes/5
        [ResponseType(typeof(QuestionnaireQuestionAnswerType))]
        public IHttpActionResult DeleteQuestionnaireQuestionAnswerType(Guid id)
        {
            QuestionnaireQuestionAnswerType questionnaireQuestionAnswerType = db.QuestionnaireQuestionAnswerTypes.Find(id);
            if (questionnaireQuestionAnswerType == null)
            {
                return NotFound();
            }

            db.QuestionnaireQuestionAnswerTypes.Remove(questionnaireQuestionAnswerType);
            db.SaveChanges();

            return Ok(questionnaireQuestionAnswerType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuestionnaireQuestionAnswerTypeExists(Guid id)
        {
            return db.QuestionnaireQuestionAnswerTypes.Count(e => e.QuestionnaireQuestionAnswerTypeID == id) > 0;
        }
    }
}