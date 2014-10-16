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
    public class RCAccountBalancesController : ApiController
    {
        private SDBOAppContext db = new SDBOAppContext();

        // GET: api/RCAccountBalances
        public IQueryable<RCAccountBalance> GetRCAccountBalances()
        {
            return db.RCAccountBalances;
        }

        // GET: api/RCAccountBalances/5
        [ResponseType(typeof(RCAccountBalance))]
        public IHttpActionResult GetRCAccountBalance(Guid id)
        {
            RCAccountBalance rCAccountBalance = db.RCAccountBalances.Find(id);
            if (rCAccountBalance == null)
            {
                return NotFound();
            }

            return Ok(rCAccountBalance);
        }

        // PUT: api/RCAccountBalances/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRCAccountBalance(Guid id, RCAccountBalance rCAccountBalance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rCAccountBalance.RCAccountBalanceID)
            {
                return BadRequest();
            }

            db.Entry(rCAccountBalance).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RCAccountBalanceExists(id))
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

        // POST: api/RCAccountBalances
        [ResponseType(typeof(RCAccountBalance))]
        public IHttpActionResult PostRCAccountBalance(RCAccountBalance rCAccountBalance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RCAccountBalances.Add(rCAccountBalance);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RCAccountBalanceExists(rCAccountBalance.RCAccountBalanceID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = rCAccountBalance.RCAccountBalanceID }, rCAccountBalance);
        }

        // DELETE: api/RCAccountBalances/5
        [ResponseType(typeof(RCAccountBalance))]
        public IHttpActionResult DeleteRCAccountBalance(Guid id)
        {
            RCAccountBalance rCAccountBalance = db.RCAccountBalances.Find(id);
            if (rCAccountBalance == null)
            {
                return NotFound();
            }

            db.RCAccountBalances.Remove(rCAccountBalance);
            db.SaveChanges();

            return Ok(rCAccountBalance);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RCAccountBalanceExists(Guid id)
        {
            return db.RCAccountBalances.Count(e => e.RCAccountBalanceID == id) > 0;
        }
    }
}