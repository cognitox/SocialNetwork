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
    public class AccountAccountSettingsLinksController : ApiController
    {
        private SDBOAppContext db = new SDBOAppContext();

        // GET: api/AccountAccountSettingsLinks
        public IQueryable<AccountAccountSettingsLink> GetAccountAccountSettingsLinks()
        {
            return db.AccountAccountSettingsLinks;
        }

        // GET: api/AccountAccountSettingsLinks/5
        [ResponseType(typeof(AccountAccountSettingsLink))]
        public IHttpActionResult GetAccountAccountSettingsLink(Guid id)
        {
            AccountAccountSettingsLink accountAccountSettingsLink = db.AccountAccountSettingsLinks.Find(id);
            if (accountAccountSettingsLink == null)
            {
                return NotFound();
            }

            return Ok(accountAccountSettingsLink);
        }

        // PUT: api/AccountAccountSettingsLinks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAccountAccountSettingsLink(Guid id, AccountAccountSettingsLink accountAccountSettingsLink)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != accountAccountSettingsLink.AccountAccountSettingsLinkID)
            {
                return BadRequest();
            }

            db.Entry(accountAccountSettingsLink).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountAccountSettingsLinkExists(id))
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

        // POST: api/AccountAccountSettingsLinks
        [ResponseType(typeof(AccountAccountSettingsLink))]
        public IHttpActionResult PostAccountAccountSettingsLink(AccountAccountSettingsLink accountAccountSettingsLink)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AccountAccountSettingsLinks.Add(accountAccountSettingsLink);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AccountAccountSettingsLinkExists(accountAccountSettingsLink.AccountAccountSettingsLinkID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = accountAccountSettingsLink.AccountAccountSettingsLinkID }, accountAccountSettingsLink);
        }

        // DELETE: api/AccountAccountSettingsLinks/5
        [ResponseType(typeof(AccountAccountSettingsLink))]
        public IHttpActionResult DeleteAccountAccountSettingsLink(Guid id)
        {
            AccountAccountSettingsLink accountAccountSettingsLink = db.AccountAccountSettingsLinks.Find(id);
            if (accountAccountSettingsLink == null)
            {
                return NotFound();
            }

            db.AccountAccountSettingsLinks.Remove(accountAccountSettingsLink);
            db.SaveChanges();

            return Ok(accountAccountSettingsLink);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AccountAccountSettingsLinkExists(Guid id)
        {
            return db.AccountAccountSettingsLinks.Count(e => e.AccountAccountSettingsLinkID == id) > 0;
        }
    }
}