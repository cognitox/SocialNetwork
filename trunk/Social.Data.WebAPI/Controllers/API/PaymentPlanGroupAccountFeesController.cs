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
    public class PaymentPlanGroupAccountFeesController : ApiController
    {
        private SDBOAppContext db = new SDBOAppContext();

        // GET: api/PaymentPlanGroupAccountFees
        public IQueryable<PaymentPlanGroupAccountFee> GetPaymentPlanGroupAccountFees()
        {
            return db.PaymentPlanGroupAccountFees;
        }

        // GET: api/PaymentPlanGroupAccountFees/5
        [ResponseType(typeof(PaymentPlanGroupAccountFee))]
        public IHttpActionResult GetPaymentPlanGroupAccountFee(Guid id)
        {
            PaymentPlanGroupAccountFee paymentPlanGroupAccountFee = db.PaymentPlanGroupAccountFees.Find(id);
            if (paymentPlanGroupAccountFee == null)
            {
                return NotFound();
            }

            return Ok(paymentPlanGroupAccountFee);
        }

        // PUT: api/PaymentPlanGroupAccountFees/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPaymentPlanGroupAccountFee(Guid id, PaymentPlanGroupAccountFee paymentPlanGroupAccountFee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paymentPlanGroupAccountFee.PaymentPlanGroupAccountFeeID)
            {
                return BadRequest();
            }

            db.Entry(paymentPlanGroupAccountFee).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentPlanGroupAccountFeeExists(id))
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

        // POST: api/PaymentPlanGroupAccountFees
        [ResponseType(typeof(PaymentPlanGroupAccountFee))]
        public IHttpActionResult PostPaymentPlanGroupAccountFee(PaymentPlanGroupAccountFee paymentPlanGroupAccountFee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PaymentPlanGroupAccountFees.Add(paymentPlanGroupAccountFee);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PaymentPlanGroupAccountFeeExists(paymentPlanGroupAccountFee.PaymentPlanGroupAccountFeeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = paymentPlanGroupAccountFee.PaymentPlanGroupAccountFeeID }, paymentPlanGroupAccountFee);
        }

        // DELETE: api/PaymentPlanGroupAccountFees/5
        [ResponseType(typeof(PaymentPlanGroupAccountFee))]
        public IHttpActionResult DeletePaymentPlanGroupAccountFee(Guid id)
        {
            PaymentPlanGroupAccountFee paymentPlanGroupAccountFee = db.PaymentPlanGroupAccountFees.Find(id);
            if (paymentPlanGroupAccountFee == null)
            {
                return NotFound();
            }

            db.PaymentPlanGroupAccountFees.Remove(paymentPlanGroupAccountFee);
            db.SaveChanges();

            return Ok(paymentPlanGroupAccountFee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PaymentPlanGroupAccountFeeExists(Guid id)
        {
            return db.PaymentPlanGroupAccountFees.Count(e => e.PaymentPlanGroupAccountFeeID == id) > 0;
        }
    }
}