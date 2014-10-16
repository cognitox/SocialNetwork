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
    public class AccountSettingsTypesController : ApiController
    {
        private SDBOAppContext db = new SDBOAppContext();

        // GET: api/AccountSettingsTypes
        public IQueryable<AccountSettingsType> GetAccountSettingsTypes()
        {
            return db.AccountSettingsTypes;
        }

        // GET: api/AccountSettingsTypes/5
        [ResponseType(typeof(AccountSettingsType))]
        public IHttpActionResult GetAccountSettingsType(Guid id)
        {
            AccountSettingsType accountSettingsType = db.AccountSettingsTypes.Find(id);
            if (accountSettingsType == null)
            {
                return NotFound();
            }

            return Ok(accountSettingsType);
        }

        // PUT: api/AccountSettingsTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAccountSettingsType(Guid id, AccountSettingsType accountSettingsType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != accountSettingsType.AccountSettingsTypeID)
            {
                return BadRequest();
            }

            db.Entry(accountSettingsType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountSettingsTypeExists(id))
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

        // POST: api/AccountSettingsTypes
        [ResponseType(typeof(AccountSettingsType))]
        public IHttpActionResult PostAccountSettingsType(AccountSettingsType accountSettingsType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AccountSettingsTypes.Add(accountSettingsType);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AccountSettingsTypeExists(accountSettingsType.AccountSettingsTypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = accountSettingsType.AccountSettingsTypeID }, accountSettingsType);
        }

        // DELETE: api/AccountSettingsTypes/5
        [ResponseType(typeof(AccountSettingsType))]
        public IHttpActionResult DeleteAccountSettingsType(Guid id)
        {
            AccountSettingsType accountSettingsType = db.AccountSettingsTypes.Find(id);
            if (accountSettingsType == null)
            {
                return NotFound();
            }

            db.AccountSettingsTypes.Remove(accountSettingsType);
            db.SaveChanges();

            return Ok(accountSettingsType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AccountSettingsTypeExists(Guid id)
        {
            return db.AccountSettingsTypes.Count(e => e.AccountSettingsTypeID == id) > 0;
        }
    }
}