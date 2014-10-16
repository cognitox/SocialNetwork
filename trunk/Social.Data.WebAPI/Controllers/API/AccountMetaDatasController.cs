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
    public class AccountMetaDatasController : ApiController
    {
        private SDBOAppContext db = new SDBOAppContext();

        // GET: api/AccountMetaDatas
        public IQueryable<AccountMetaData> GetAccountMetaDatas()
        {
            return db.AccountMetaDatas;
        }

        // GET: api/AccountMetaDatas/5
        [ResponseType(typeof(AccountMetaData))]
        public IHttpActionResult GetAccountMetaData(Guid id)
        {
            AccountMetaData accountMetaData = db.AccountMetaDatas.Find(id);
            if (accountMetaData == null)
            {
                return NotFound();
            }

            return Ok(accountMetaData);
        }

        // PUT: api/AccountMetaDatas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAccountMetaData(Guid id, AccountMetaData accountMetaData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != accountMetaData.AccountMetaDataID)
            {
                return BadRequest();
            }

            db.Entry(accountMetaData).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountMetaDataExists(id))
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

        // POST: api/AccountMetaDatas
        [ResponseType(typeof(AccountMetaData))]
        public IHttpActionResult PostAccountMetaData(AccountMetaData accountMetaData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AccountMetaDatas.Add(accountMetaData);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AccountMetaDataExists(accountMetaData.AccountMetaDataID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = accountMetaData.AccountMetaDataID }, accountMetaData);
        }

        // DELETE: api/AccountMetaDatas/5
        [ResponseType(typeof(AccountMetaData))]
        public IHttpActionResult DeleteAccountMetaData(Guid id)
        {
            AccountMetaData accountMetaData = db.AccountMetaDatas.Find(id);
            if (accountMetaData == null)
            {
                return NotFound();
            }

            db.AccountMetaDatas.Remove(accountMetaData);
            db.SaveChanges();

            return Ok(accountMetaData);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AccountMetaDataExists(Guid id)
        {
            return db.AccountMetaDatas.Count(e => e.AccountMetaDataID == id) > 0;
        }
    }
}