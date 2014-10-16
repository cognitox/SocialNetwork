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
    public class GroupAccountsController : ApiController
    {
        private SDBOAppContext db = new SDBOAppContext();

        // GET: api/GroupAccounts
        public IQueryable<GroupAccount> GetGroupAccounts()
        {
            return db.GroupAccounts;
        }

        // GET: api/GroupAccounts/5
        [ResponseType(typeof(GroupAccount))]
        public IHttpActionResult GetGroupAccount(Guid id)
        {
            GroupAccount groupAccount = db.GroupAccounts.Find(id);
            if (groupAccount == null)
            {
                return NotFound();
            }

            return Ok(groupAccount);
        }

        // PUT: api/GroupAccounts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGroupAccount(Guid id, GroupAccount groupAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != groupAccount.GroupAccountID)
            {
                return BadRequest();
            }

            db.Entry(groupAccount).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupAccountExists(id))
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

        // POST: api/GroupAccounts
        [ResponseType(typeof(GroupAccount))]
        public IHttpActionResult PostGroupAccount(GroupAccount groupAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GroupAccounts.Add(groupAccount);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (GroupAccountExists(groupAccount.GroupAccountID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = groupAccount.GroupAccountID }, groupAccount);
        }

        // DELETE: api/GroupAccounts/5
        [ResponseType(typeof(GroupAccount))]
        public IHttpActionResult DeleteGroupAccount(Guid id)
        {
            GroupAccount groupAccount = db.GroupAccounts.Find(id);
            if (groupAccount == null)
            {
                return NotFound();
            }

            db.GroupAccounts.Remove(groupAccount);
            db.SaveChanges();

            return Ok(groupAccount);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GroupAccountExists(Guid id)
        {
            return db.GroupAccounts.Count(e => e.GroupAccountID == id) > 0;
        }
    }
}