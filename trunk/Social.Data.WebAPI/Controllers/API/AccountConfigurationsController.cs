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
    public class AccountConfigurationsController : ApiController
    {
        private SDBOAppContext db = new SDBOAppContext();

        // GET: api/AccountConfigurations
        public IQueryable<AccountConfiguration> GetAccountConfigurations()
        {
            return db.AccountConfigurations;
        }

        // GET: api/AccountConfigurations/5
        [ResponseType(typeof(AccountConfiguration))]
        public IHttpActionResult GetAccountConfiguration(Guid id)
        {
            AccountConfiguration accountConfiguration = db.AccountConfigurations.Find(id);
            if (accountConfiguration == null)
            {
                return NotFound();
            }

            return Ok(accountConfiguration);
        }

        // PUT: api/AccountConfigurations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAccountConfiguration(Guid id, AccountConfiguration accountConfiguration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != accountConfiguration.AccountConfigurationID)
            {
                return BadRequest();
            }

            db.Entry(accountConfiguration).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountConfigurationExists(id))
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

        // POST: api/AccountConfigurations
        [ResponseType(typeof(AccountConfiguration))]
        public IHttpActionResult PostAccountConfiguration(AccountConfiguration accountConfiguration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AccountConfigurations.Add(accountConfiguration);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AccountConfigurationExists(accountConfiguration.AccountConfigurationID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = accountConfiguration.AccountConfigurationID }, accountConfiguration);
        }

        // DELETE: api/AccountConfigurations/5
        [ResponseType(typeof(AccountConfiguration))]
        public IHttpActionResult DeleteAccountConfiguration(Guid id)
        {
            AccountConfiguration accountConfiguration = db.AccountConfigurations.Find(id);
            if (accountConfiguration == null)
            {
                return NotFound();
            }

            db.AccountConfigurations.Remove(accountConfiguration);
            db.SaveChanges();

            return Ok(accountConfiguration);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AccountConfigurationExists(Guid id)
        {
            return db.AccountConfigurations.Count(e => e.AccountConfigurationID == id) > 0;
        }
    }
}