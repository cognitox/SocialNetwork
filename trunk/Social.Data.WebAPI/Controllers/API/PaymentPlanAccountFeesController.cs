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
    public class PaymentPlanAccountFeesController : ApiController
    {
        private SDBOAppContext db = new SDBOAppContext();

        // GET: api/PaymentPlanAccountFees
        public IQueryable<PaymentPlanAccountFee> GetPaymentPlanAccountFees()
        {
            return db.PaymentPlanAccountFees;
        }

        // GET: api/PaymentPlanAccountFees/5
        [ResponseType(typeof(PaymentPlanAccountFee))]
        public IHttpActionResult GetPaymentPlanAccountFee(Guid id)
        {
            PaymentPlanAccountFee paymentPlanAccountFee = db.PaymentPlanAccountFees.Find(id);
            if (paymentPlanAccountFee == null)
            {
                return NotFound();
            }

            return Ok(paymentPlanAccountFee);
        }

        // PUT: api/PaymentPlanAccountFees/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPaymentPlanAccountFee(Guid id, PaymentPlanAccountFee paymentPlanAccountFee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paymentPlanAccountFee.PaymentPlanAccountFeeID)
            {
                return BadRequest();
            }

            db.Entry(paymentPlanAccountFee).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentPlanAccountFeeExists(id))
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

        // POST: api/PaymentPlanAccountFees
        [ResponseType(typeof(PaymentPlanAccountFee))]
        public IHttpActionResult PostPaymentPlanAccountFee(PaymentPlanAccountFee paymentPlanAccountFee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PaymentPlanAccountFees.Add(paymentPlanAccountFee);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PaymentPlanAccountFeeExists(paymentPlanAccountFee.PaymentPlanAccountFeeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = paymentPlanAccountFee.PaymentPlanAccountFeeID }, paymentPlanAccountFee);
        }

        // DELETE: api/PaymentPlanAccountFees/5
        [ResponseType(typeof(PaymentPlanAccountFee))]
        public IHttpActionResult DeletePaymentPlanAccountFee(Guid id)
        {
            PaymentPlanAccountFee paymentPlanAccountFee = db.PaymentPlanAccountFees.Find(id);
            if (paymentPlanAccountFee == null)
            {
                return NotFound();
            }

            db.PaymentPlanAccountFees.Remove(paymentPlanAccountFee);
            db.SaveChanges();

            return Ok(paymentPlanAccountFee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PaymentPlanAccountFeeExists(Guid id)
        {
            return db.PaymentPlanAccountFees.Count(e => e.PaymentPlanAccountFeeID == id) > 0;
        }
    }
}