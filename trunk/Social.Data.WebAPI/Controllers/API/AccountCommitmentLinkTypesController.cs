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
    public class AccountCommitmentLinkTypesController : ApiController
    {
        private SDBOAppContext db = new SDBOAppContext();

        // GET: api/AccountCommitmentLinkTypes
        public IQueryable<AccountCommitmentLinkType> GetAccountCommitmentLinkTypes()
        {
            return db.AccountCommitmentLinkTypes;
        }

        // GET: api/AccountCommitmentLinkTypes/5
        [ResponseType(typeof(AccountCommitmentLinkType))]
        public IHttpActionResult GetAccountCommitmentLinkType(Guid id)
        {
            AccountCommitmentLinkType accountCommitmentLinkType = db.AccountCommitmentLinkTypes.Find(id);
            if (accountCommitmentLinkType == null)
            {
                return NotFound();
            }

            return Ok(accountCommitmentLinkType);
        }

        // PUT: api/AccountCommitmentLinkTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAccountCommitmentLinkType(Guid id, AccountCommitmentLinkType accountCommitmentLinkType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != accountCommitmentLinkType.AccountCommitmentLinkTypeID)
            {
                return BadRequest();
            }

            db.Entry(accountCommitmentLinkType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountCommitmentLinkTypeExists(id))
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

        // POST: api/AccountCommitmentLinkTypes
        [ResponseType(typeof(AccountCommitmentLinkType))]
        public IHttpActionResult PostAccountCommitmentLinkType(AccountCommitmentLinkType accountCommitmentLinkType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AccountCommitmentLinkTypes.Add(accountCommitmentLinkType);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AccountCommitmentLinkTypeExists(accountCommitmentLinkType.AccountCommitmentLinkTypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = accountCommitmentLinkType.AccountCommitmentLinkTypeID }, accountCommitmentLinkType);
        }

        // DELETE: api/AccountCommitmentLinkTypes/5
        [ResponseType(typeof(AccountCommitmentLinkType))]
        public IHttpActionResult DeleteAccountCommitmentLinkType(Guid id)
        {
            AccountCommitmentLinkType accountCommitmentLinkType = db.AccountCommitmentLinkTypes.Find(id);
            if (accountCommitmentLinkType == null)
            {
                return NotFound();
            }

            db.AccountCommitmentLinkTypes.Remove(accountCommitmentLinkType);
            db.SaveChanges();

            return Ok(accountCommitmentLinkType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AccountCommitmentLinkTypeExists(Guid id)
        {
            return db.AccountCommitmentLinkTypes.Count(e => e.AccountCommitmentLinkTypeID == id) > 0;
        }
    }
}