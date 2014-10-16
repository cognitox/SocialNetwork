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
    public class AccountStatusTypesController : ApiController
    {
        private SDBOAppContext db = new SDBOAppContext();

        // GET: api/AccountStatusTypes
        public IQueryable<AccountStatusType> GetAccountStatusTypes()
        {
            return db.AccountStatusTypes;
        }

        // GET: api/AccountStatusTypes/5
        [ResponseType(typeof(AccountStatusType))]
        public IHttpActionResult GetAccountStatusType(Guid id)
        {
            AccountStatusType accountStatusType = db.AccountStatusTypes.Find(id);
            if (accountStatusType == null)
            {
                return NotFound();
            }

            return Ok(accountStatusType);
        }

        // PUT: api/AccountStatusTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAccountStatusType(Guid id, AccountStatusType accountStatusType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != accountStatusType.AccountStatusTypeID)
            {
                return BadRequest();
            }

            db.Entry(accountStatusType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountStatusTypeExists(id))
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

        // POST: api/AccountStatusTypes
        [ResponseType(typeof(AccountStatusType))]
        public IHttpActionResult PostAccountStatusType(AccountStatusType accountStatusType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AccountStatusTypes.Add(accountStatusType);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AccountStatusTypeExists(accountStatusType.AccountStatusTypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = accountStatusType.AccountStatusTypeID }, accountStatusType);
        }

        // DELETE: api/AccountStatusTypes/5
        [ResponseType(typeof(AccountStatusType))]
        public IHttpActionResult DeleteAccountStatusType(Guid id)
        {
            AccountStatusType accountStatusType = db.AccountStatusTypes.Find(id);
            if (accountStatusType == null)
            {
                return NotFound();
            }

            db.AccountStatusTypes.Remove(accountStatusType);
            db.SaveChanges();

            return Ok(accountStatusType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AccountStatusTypeExists(Guid id)
        {
            return db.AccountStatusTypes.Count(e => e.AccountStatusTypeID == id) > 0;
        }
    }
}