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
    public class AccountSettingsAccountSettingsMultichoiceAnswerLinksController : ApiController
    {
        private SDBOAppContext db = new SDBOAppContext();

        // GET: api/AccountSettingsAccountSettingsMultichoiceAnswerLinks
        public IQueryable<AccountSettingsAccountSettingsMultichoiceAnswerLink> GetAccountSettingsAccountSettingsMultichoiceAnswerLinks()
        {
            return db.AccountSettingsAccountSettingsMultichoiceAnswerLinks;
        }

        // GET: api/AccountSettingsAccountSettingsMultichoiceAnswerLinks/5
        [ResponseType(typeof(AccountSettingsAccountSettingsMultichoiceAnswerLink))]
        public IHttpActionResult GetAccountSettingsAccountSettingsMultichoiceAnswerLink(Guid id)
        {
            AccountSettingsAccountSettingsMultichoiceAnswerLink accountSettingsAccountSettingsMultichoiceAnswerLink = db.AccountSettingsAccountSettingsMultichoiceAnswerLinks.Find(id);
            if (accountSettingsAccountSettingsMultichoiceAnswerLink == null)
            {
                return NotFound();
            }

            return Ok(accountSettingsAccountSettingsMultichoiceAnswerLink);
        }

        // PUT: api/AccountSettingsAccountSettingsMultichoiceAnswerLinks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAccountSettingsAccountSettingsMultichoiceAnswerLink(Guid id, AccountSettingsAccountSettingsMultichoiceAnswerLink accountSettingsAccountSettingsMultichoiceAnswerLink)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != accountSettingsAccountSettingsMultichoiceAnswerLink.AccountSettingsAccountSettingsMultichoiceAnswerLinkID)
            {
                return BadRequest();
            }

            db.Entry(accountSettingsAccountSettingsMultichoiceAnswerLink).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountSettingsAccountSettingsMultichoiceAnswerLinkExists(id))
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

        // POST: api/AccountSettingsAccountSettingsMultichoiceAnswerLinks
        [ResponseType(typeof(AccountSettingsAccountSettingsMultichoiceAnswerLink))]
        public IHttpActionResult PostAccountSettingsAccountSettingsMultichoiceAnswerLink(AccountSettingsAccountSettingsMultichoiceAnswerLink accountSettingsAccountSettingsMultichoiceAnswerLink)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AccountSettingsAccountSettingsMultichoiceAnswerLinks.Add(accountSettingsAccountSettingsMultichoiceAnswerLink);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AccountSettingsAccountSettingsMultichoiceAnswerLinkExists(accountSettingsAccountSettingsMultichoiceAnswerLink.AccountSettingsAccountSettingsMultichoiceAnswerLinkID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = accountSettingsAccountSettingsMultichoiceAnswerLink.AccountSettingsAccountSettingsMultichoiceAnswerLinkID }, accountSettingsAccountSettingsMultichoiceAnswerLink);
        }

        // DELETE: api/AccountSettingsAccountSettingsMultichoiceAnswerLinks/5
        [ResponseType(typeof(AccountSettingsAccountSettingsMultichoiceAnswerLink))]
        public IHttpActionResult DeleteAccountSettingsAccountSettingsMultichoiceAnswerLink(Guid id)
        {
            AccountSettingsAccountSettingsMultichoiceAnswerLink accountSettingsAccountSettingsMultichoiceAnswerLink = db.AccountSettingsAccountSettingsMultichoiceAnswerLinks.Find(id);
            if (accountSettingsAccountSettingsMultichoiceAnswerLink == null)
            {
                return NotFound();
            }

            db.AccountSettingsAccountSettingsMultichoiceAnswerLinks.Remove(accountSettingsAccountSettingsMultichoiceAnswerLink);
            db.SaveChanges();

            return Ok(accountSettingsAccountSettingsMultichoiceAnswerLink);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AccountSettingsAccountSettingsMultichoiceAnswerLinkExists(Guid id)
        {
            return db.AccountSettingsAccountSettingsMultichoiceAnswerLinks.Count(e => e.AccountSettingsAccountSettingsMultichoiceAnswerLinkID == id) > 0;
        }
    }
}