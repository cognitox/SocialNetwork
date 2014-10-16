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
    public class AccountSettingsController : ApiController
    {
        private SDBOAppContext db = new SDBOAppContext();

        // GET: api/AccountSettings
        public IQueryable<AccountSetting> GetAccountSettings()
        {
            return db.AccountSettings;
        }

        // GET: api/AccountSettings/5
        [ResponseType(typeof(AccountSetting))]
        public IHttpActionResult GetAccountSetting(Guid id)
        {
            AccountSetting accountSetting = db.AccountSettings.Find(id);
            if (accountSetting == null)
            {
                return NotFound();
            }

            return Ok(accountSetting);
        }

        // PUT: api/AccountSettings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAccountSetting(Guid id, AccountSetting accountSetting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != accountSetting.AccountSettingsID)
            {
                return BadRequest();
            }

            db.Entry(accountSetting).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountSettingExists(id))
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

        // POST: api/AccountSettings
        [ResponseType(typeof(AccountSetting))]
        public IHttpActionResult PostAccountSetting(AccountSetting accountSetting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AccountSettings.Add(accountSetting);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AccountSettingExists(accountSetting.AccountSettingsID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = accountSetting.AccountSettingsID }, accountSetting);
        }

        // DELETE: api/AccountSettings/5
        [ResponseType(typeof(AccountSetting))]
        public IHttpActionResult DeleteAccountSetting(Guid id)
        {
            AccountSetting accountSetting = db.AccountSettings.Find(id);
            if (accountSetting == null)
            {
                return NotFound();
            }

            db.AccountSettings.Remove(accountSetting);
            db.SaveChanges();

            return Ok(accountSetting);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AccountSettingExists(Guid id)
        {
            return db.AccountSettings.Count(e => e.AccountSettingsID == id) > 0;
        }
    }
}