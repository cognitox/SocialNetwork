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
    public class AccountSettingsMultichoiceAnswersController : ApiController
    {
        private SDBOAppContext db = new SDBOAppContext();

        // GET: api/AccountSettingsMultichoiceAnswers
        public IQueryable<AccountSettingsMultichoiceAnswer> GetAccountSettingsMultichoiceAnswers()
        {
            return db.AccountSettingsMultichoiceAnswers;
        }

        // GET: api/AccountSettingsMultichoiceAnswers/5
        [ResponseType(typeof(AccountSettingsMultichoiceAnswer))]
        public IHttpActionResult GetAccountSettingsMultichoiceAnswer(Guid id)
        {
            AccountSettingsMultichoiceAnswer accountSettingsMultichoiceAnswer = db.AccountSettingsMultichoiceAnswers.Find(id);
            if (accountSettingsMultichoiceAnswer == null)
            {
                return NotFound();
            }

            return Ok(accountSettingsMultichoiceAnswer);
        }

        // PUT: api/AccountSettingsMultichoiceAnswers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAccountSettingsMultichoiceAnswer(Guid id, AccountSettingsMultichoiceAnswer accountSettingsMultichoiceAnswer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != accountSettingsMultichoiceAnswer.AccountSettingsMultichoiceAnswerID)
            {
                return BadRequest();
            }

            db.Entry(accountSettingsMultichoiceAnswer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountSettingsMultichoiceAnswerExists(id))
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

        // POST: api/AccountSettingsMultichoiceAnswers
        [ResponseType(typeof(AccountSettingsMultichoiceAnswer))]
        public IHttpActionResult PostAccountSettingsMultichoiceAnswer(AccountSettingsMultichoiceAnswer accountSettingsMultichoiceAnswer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AccountSettingsMultichoiceAnswers.Add(accountSettingsMultichoiceAnswer);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AccountSettingsMultichoiceAnswerExists(accountSettingsMultichoiceAnswer.AccountSettingsMultichoiceAnswerID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = accountSettingsMultichoiceAnswer.AccountSettingsMultichoiceAnswerID }, accountSettingsMultichoiceAnswer);
        }

        // DELETE: api/AccountSettingsMultichoiceAnswers/5
        [ResponseType(typeof(AccountSettingsMultichoiceAnswer))]
        public IHttpActionResult DeleteAccountSettingsMultichoiceAnswer(Guid id)
        {
            AccountSettingsMultichoiceAnswer accountSettingsMultichoiceAnswer = db.AccountSettingsMultichoiceAnswers.Find(id);
            if (accountSettingsMultichoiceAnswer == null)
            {
                return NotFound();
            }

            db.AccountSettingsMultichoiceAnswers.Remove(accountSettingsMultichoiceAnswer);
            db.SaveChanges();

            return Ok(accountSettingsMultichoiceAnswer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AccountSettingsMultichoiceAnswerExists(Guid id)
        {
            return db.AccountSettingsMultichoiceAnswers.Count(e => e.AccountSettingsMultichoiceAnswerID == id) > 0;
        }
    }
}