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
    public class AccountTypesController : ApiController
    {
        private SDBOAppContext db = new SDBOAppContext();

        // GET: api/AccountTypes
        public IQueryable<AccountType> GetAccountTypes()
        {
            return db.AccountTypes;
        }

        // GET: api/AccountTypes/5
        [ResponseType(typeof(AccountType))]
        public IHttpActionResult GetAccountType(Guid id)
        {
            AccountType accountType = db.AccountTypes.Find(id);
            if (accountType == null)
            {
                return NotFound();
            }

            return Ok(accountType);
        }

        // PUT: api/AccountTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAccountType(Guid id, AccountType accountType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != accountType.AccountTypeID)
            {
                return BadRequest();
            }

            db.Entry(accountType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountTypeExists(id))
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

        // POST: api/AccountTypes
        [ResponseType(typeof(AccountType))]
        public IHttpActionResult PostAccountType(AccountType accountType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AccountTypes.Add(accountType);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AccountTypeExists(accountType.AccountTypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = accountType.AccountTypeID }, accountType);
        }

        // DELETE: api/AccountTypes/5
        [ResponseType(typeof(AccountType))]
        public IHttpActionResult DeleteAccountType(Guid id)
        {
            AccountType accountType = db.AccountTypes.Find(id);
            if (accountType == null)
            {
                return NotFound();
            }

            db.AccountTypes.Remove(accountType);
            db.SaveChanges();

            return Ok(accountType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AccountTypeExists(Guid id)
        {
            return db.AccountTypes.Count(e => e.AccountTypeID == id) > 0;
        }
    }
}