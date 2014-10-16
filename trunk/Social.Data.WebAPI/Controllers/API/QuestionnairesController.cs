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
    public class QuestionnairesController : ApiController
    {
        private SDBOAppContext db = new SDBOAppContext();

        // GET: api/Questionnaires
        public IQueryable<Questionnaire> GetQuestionnaires()
        {
            return db.Questionnaires;
        }

        // GET: api/Questionnaires/5
        [ResponseType(typeof(Questionnaire))]
        public IHttpActionResult GetQuestionnaire(Guid id)
        {
            Questionnaire questionnaire = db.Questionnaires.Find(id);
            if (questionnaire == null)
            {
                return NotFound();
            }

            return Ok(questionnaire);
        }

        // PUT: api/Questionnaires/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutQuestionnaire(Guid id, Questionnaire questionnaire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != questionnaire.QuestionnaireID)
            {
                return BadRequest();
            }

            db.Entry(questionnaire).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionnaireExists(id))
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

        // POST: api/Questionnaires
        [ResponseType(typeof(Questionnaire))]
        public IHttpActionResult PostQuestionnaire(Questionnaire questionnaire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Questionnaires.Add(questionnaire);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (QuestionnaireExists(questionnaire.QuestionnaireID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = questionnaire.QuestionnaireID }, questionnaire);
        }

        // DELETE: api/Questionnaires/5
        [ResponseType(typeof(Questionnaire))]
        public IHttpActionResult DeleteQuestionnaire(Guid id)
        {
            Questionnaire questionnaire = db.Questionnaires.Find(id);
            if (questionnaire == null)
            {
                return NotFound();
            }

            db.Questionnaires.Remove(questionnaire);
            db.SaveChanges();

            return Ok(questionnaire);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuestionnaireExists(Guid id)
        {
            return db.Questionnaires.Count(e => e.QuestionnaireID == id) > 0;
        }
    }
}