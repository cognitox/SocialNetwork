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
    public class PaymentPlanGroupAccountsController : ApiController
    {
        private SDBOAppContext db = new SDBOAppContext();

        // GET: api/PaymentPlanGroupAccounts
        public IQueryable<PaymentPlanGroupAccount> GetPaymentPlanGroupAccounts()
        {
            return db.PaymentPlanGroupAccounts;
        }

        // GET: api/PaymentPlanGroupAccounts/5
        [ResponseType(typeof(PaymentPlanGroupAccount))]
        public IHttpActionResult GetPaymentPlanGroupAccount(Guid id)
        {
            PaymentPlanGroupAccount paymentPlanGroupAccount = db.PaymentPlanGroupAccounts.Find(id);
            if (paymentPlanGroupAccount == null)
            {
                return NotFound();
            }

            return Ok(paymentPlanGroupAccount);
        }

        // PUT: api/PaymentPlanGroupAccounts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPaymentPlanGroupAccount(Guid id, PaymentPlanGroupAccount paymentPlanGroupAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paymentPlanGroupAccount.PaymentPlanGroupAccountID)
            {
                return BadRequest();
            }

            db.Entry(paymentPlanGroupAccount).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentPlanGroupAccountExists(id))
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

        // POST: api/PaymentPlanGroupAccounts
        [ResponseType(typeof(PaymentPlanGroupAccount))]
        public IHttpActionResult PostPaymentPlanGroupAccount(PaymentPlanGroupAccount paymentPlanGroupAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PaymentPlanGroupAccounts.Add(paymentPlanGroupAccount);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PaymentPlanGroupAccountExists(paymentPlanGroupAccount.PaymentPlanGroupAccountID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = paymentPlanGroupAccount.PaymentPlanGroupAccountID }, paymentPlanGroupAccount);
        }

        // DELETE: api/PaymentPlanGroupAccounts/5
        [ResponseType(typeof(PaymentPlanGroupAccount))]
        public IHttpActionResult DeletePaymentPlanGroupAccount(Guid id)
        {
            PaymentPlanGroupAccount paymentPlanGroupAccount = db.PaymentPlanGroupAccounts.Find(id);
            if (paymentPlanGroupAccount == null)
            {
                return NotFound();
            }

            db.PaymentPlanGroupAccounts.Remove(paymentPlanGroupAccount);
            db.SaveChanges();

            return Ok(paymentPlanGroupAccount);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PaymentPlanGroupAccountExists(Guid id)
        {
            return db.PaymentPlanGroupAccounts.Count(e => e.PaymentPlanGroupAccountID == id) > 0;
        }
    }
}