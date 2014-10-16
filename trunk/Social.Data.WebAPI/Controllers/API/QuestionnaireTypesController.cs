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
    public class QuestionnaireTypesController : ApiController
    {
        private SDBOAppContext db = new SDBOAppContext();

        // GET: api/QuestionnaireTypes
        public IQueryable<QuestionnaireType> GetQuestionnaireTypes()
        {
            return db.QuestionnaireTypes;
        }

        // GET: api/QuestionnaireTypes/5
        [ResponseType(typeof(QuestionnaireType))]
        public IHttpActionResult GetQuestionnaireType(Guid id)
        {
            QuestionnaireType questionnaireType = db.QuestionnaireTypes.Find(id);
            if (questionnaireType == null)
            {
                return NotFound();
            }

            return Ok(questionnaireType);
        }

        // PUT: api/QuestionnaireTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutQuestionnaireType(Guid id, QuestionnaireType questionnaireType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != questionnaireType.QuestionnaireTypeID)
            {
                return BadRequest();
            }

            db.Entry(questionnaireType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionnaireTypeExists(id))
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

        // POST: api/QuestionnaireTypes
        [ResponseType(typeof(QuestionnaireType))]
        public IHttpActionResult PostQuestionnaireType(QuestionnaireType questionnaireType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.QuestionnaireTypes.Add(questionnaireType);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (QuestionnaireTypeExists(questionnaireType.QuestionnaireTypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = questionnaireType.QuestionnaireTypeID }, questionnaireType);
        }

        // DELETE: api/QuestionnaireTypes/5
        [ResponseType(typeof(QuestionnaireType))]
        public IHttpActionResult DeleteQuestionnaireType(Guid id)
        {
            QuestionnaireType questionnaireType = db.QuestionnaireTypes.Find(id);
            if (questionnaireType == null)
            {
                return NotFound();
            }

            db.QuestionnaireTypes.Remove(questionnaireType);
            db.SaveChanges();

            return Ok(questionnaireType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuestionnaireTypeExists(Guid id)
        {
            return db.QuestionnaireTypes.Count(e => e.QuestionnaireTypeID == id) > 0;
        }
    }
}