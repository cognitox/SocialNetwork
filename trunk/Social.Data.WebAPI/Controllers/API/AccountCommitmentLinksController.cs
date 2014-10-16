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
    public class AccountCommitmentLinksController : ApiController
    {
        private SDBOAppContext db = new SDBOAppContext();

        // GET: api/AccountCommitmentLinks
        public IQueryable<AccountCommitmentLink> GetAccountCommitmentLinks()
        {
            return db.AccountCommitmentLinks;
        }

        // GET: api/AccountCommitmentLinks/5
        [ResponseType(typeof(AccountCommitmentLink))]
        public IHttpActionResult GetAccountCommitmentLink(Guid id)
        {
            AccountCommitmentLink accountCommitmentLink = db.AccountCommitmentLinks.Find(id);
            if (accountCommitmentLink == null)
            {
                return NotFound();
            }

            return Ok(accountCommitmentLink);
        }

        // PUT: api/AccountCommitmentLinks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAccountCommitmentLink(Guid id, AccountCommitmentLink accountCommitmentLink)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != accountCommitmentLink.AccountCommitmentLinkID)
            {
                return BadRequest();
            }

            db.Entry(accountCommitmentLink).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountCommitmentLinkExists(id))
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

        // POST: api/AccountCommitmentLinks
        [ResponseType(typeof(AccountCommitmentLink))]
        public IHttpActionResult PostAccountCommitmentLink(AccountCommitmentLink accountCommitmentLink)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AccountCommitmentLinks.Add(accountCommitmentLink);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AccountCommitmentLinkExists(accountCommitmentLink.AccountCommitmentLinkID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = accountCommitmentLink.AccountCommitmentLinkID }, accountCommitmentLink);
        }

        // DELETE: api/AccountCommitmentLinks/5
        [ResponseType(typeof(AccountCommitmentLink))]
        public IHttpActionResult DeleteAccountCommitmentLink(Guid id)
        {
            AccountCommitmentLink accountCommitmentLink = db.AccountCommitmentLinks.Find(id);
            if (accountCommitmentLink == null)
            {
                return NotFound();
            }

            db.AccountCommitmentLinks.Remove(accountCommitmentLink);
            db.SaveChanges();

            return Ok(accountCommitmentLink);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AccountCommitmentLinkExists(Guid id)
        {
            return db.AccountCommitmentLinks.Count(e => e.AccountCommitmentLinkID == id) > 0;
        }
    }
}