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
    public class PaymentPlanAccountsController : ApiController
    {
        private SDBOAppContext db = new SDBOAppContext();

        // GET: api/PaymentPlanAccounts
        public IQueryable<PaymentPlanAccount> GetPaymentPlanAccounts()
        {
            return db.PaymentPlanAccounts;
        }

        // GET: api/PaymentPlanAccounts/5
        [ResponseType(typeof(PaymentPlanAccount))]
        public IHttpActionResult GetPaymentPlanAccount(Guid id)
        {
            PaymentPlanAccount paymentPlanAccount = db.PaymentPlanAccounts.Find(id);
            if (paymentPlanAccount == null)
            {
                return NotFound();
            }

            return Ok(paymentPlanAccount);
        }

        // PUT: api/PaymentPlanAccounts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPaymentPlanAccount(Guid id, PaymentPlanAccount paymentPlanAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paymentPlanAccount.PaymentPlanAccountID)
            {
                return BadRequest();
            }

            db.Entry(paymentPlanAccount).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentPlanAccountExists(id))
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

        // POST: api/PaymentPlanAccounts
        [ResponseType(typeof(PaymentPlanAccount))]
        public IHttpActionResult PostPaymentPlanAccount(PaymentPlanAccount paymentPlanAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PaymentPlanAccounts.Add(paymentPlanAccount);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PaymentPlanAccountExists(paymentPlanAccount.PaymentPlanAccountID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = paymentPlanAccount.PaymentPlanAccountID }, paymentPlanAccount);
        }

        // DELETE: api/PaymentPlanAccounts/5
        [ResponseType(typeof(PaymentPlanAccount))]
        public IHttpActionResult DeletePaymentPlanAccount(Guid id)
        {
            PaymentPlanAccount paymentPlanAccount = db.PaymentPlanAccounts.Find(id);
            if (paymentPlanAccount == null)
            {
                return NotFound();
            }

            db.PaymentPlanAccounts.Remove(paymentPlanAccount);
            db.SaveChanges();

            return Ok(paymentPlanAccount);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PaymentPlanAccountExists(Guid id)
        {
            return db.PaymentPlanAccounts.Count(e => e.PaymentPlanAccountID == id) > 0;
        }
    }
}