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
    public class RCAccountTransactionsController : ApiController
    {
        private SDBOAppContext db = new SDBOAppContext();

        // GET: api/RCAccountTransactions
        public IQueryable<RCAccountTransaction> GetRCAccountTransactions()
        {
            return db.RCAccountTransactions;
        }

        // GET: api/RCAccountTransactions/5
        [ResponseType(typeof(RCAccountTransaction))]
        public IHttpActionResult GetRCAccountTransaction(Guid id)
        {
            RCAccountTransaction rCAccountTransaction = db.RCAccountTransactions.Find(id);
            if (rCAccountTransaction == null)
            {
                return NotFound();
            }

            return Ok(rCAccountTransaction);
        }

        // PUT: api/RCAccountTransactions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRCAccountTransaction(Guid id, RCAccountTransaction rCAccountTransaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rCAccountTransaction.RCAccountTransactionID)
            {
                return BadRequest();
            }

            db.Entry(rCAccountTransaction).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RCAccountTransactionExists(id))
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

        // POST: api/RCAccountTransactions
        [ResponseType(typeof(RCAccountTransaction))]
        public IHttpActionResult PostRCAccountTransaction(RCAccountTransaction rCAccountTransaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RCAccountTransactions.Add(rCAccountTransaction);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RCAccountTransactionExists(rCAccountTransaction.RCAccountTransactionID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = rCAccountTransaction.RCAccountTransactionID }, rCAccountTransaction);
        }

        // DELETE: api/RCAccountTransactions/5
        [ResponseType(typeof(RCAccountTransaction))]
        public IHttpActionResult DeleteRCAccountTransaction(Guid id)
        {
            RCAccountTransaction rCAccountTransaction = db.RCAccountTransactions.Find(id);
            if (rCAccountTransaction == null)
            {
                return NotFound();
            }

            db.RCAccountTransactions.Remove(rCAccountTransaction);
            db.SaveChanges();

            return Ok(rCAccountTransaction);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RCAccountTransactionExists(Guid id)
        {
            return db.RCAccountTransactions.Count(e => e.RCAccountTransactionID == id) > 0;
        }
    }
}