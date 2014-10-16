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
    public class AccountGroupAccountLinksController : ApiController
    {
        private SDBOAppContext db = new SDBOAppContext();

        // GET: api/AccountGroupAccountLinks
        public IQueryable<AccountGroupAccountLink> GetAccountGroupAccountLinks()
        {
            return db.AccountGroupAccountLinks;
        }

        // GET: api/AccountGroupAccountLinks/5
        [ResponseType(typeof(AccountGroupAccountLink))]
        public IHttpActionResult GetAccountGroupAccountLink(Guid id)
        {
            AccountGroupAccountLink accountGroupAccountLink = db.AccountGroupAccountLinks.Find(id);
            if (accountGroupAccountLink == null)
            {
                return NotFound();
            }

            return Ok(accountGroupAccountLink);
        }

        // PUT: api/AccountGroupAccountLinks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAccountGroupAccountLink(Guid id, AccountGroupAccountLink accountGroupAccountLink)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != accountGroupAccountLink.AccountGroupAccountLinkID)
            {
                return BadRequest();
            }

            db.Entry(accountGroupAccountLink).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountGroupAccountLinkExists(id))
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

        // POST: api/AccountGroupAccountLinks
        [ResponseType(typeof(AccountGroupAccountLink))]
        public IHttpActionResult PostAccountGroupAccountLink(AccountGroupAccountLink accountGroupAccountLink)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AccountGroupAccountLinks.Add(accountGroupAccountLink);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AccountGroupAccountLinkExists(accountGroupAccountLink.AccountGroupAccountLinkID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = accountGroupAccountLink.AccountGroupAccountLinkID }, accountGroupAccountLink);
        }

        // DELETE: api/AccountGroupAccountLinks/5
        [ResponseType(typeof(AccountGroupAccountLink))]
        public IHttpActionResult DeleteAccountGroupAccountLink(Guid id)
        {
            AccountGroupAccountLink accountGroupAccountLink = db.AccountGroupAccountLinks.Find(id);
            if (accountGroupAccountLink == null)
            {
                return NotFound();
            }

            db.AccountGroupAccountLinks.Remove(accountGroupAccountLink);
            db.SaveChanges();

            return Ok(accountGroupAccountLink);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AccountGroupAccountLinkExists(Guid id)
        {
            return db.AccountGroupAccountLinks.Count(e => e.AccountGroupAccountLinkID == id) > 0;
        }
    }
}