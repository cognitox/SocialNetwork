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
    public class AccountRolesController : ApiController
    {
        private SDBOAppContext db = new SDBOAppContext();

        // GET: api/AccountRoles
        public IQueryable<AccountRole> GetAccountRoles()
        {
            return db.AccountRoles;
        }

        // GET: api/AccountRoles/5
        [ResponseType(typeof(AccountRole))]
        public IHttpActionResult GetAccountRole(Guid id)
        {
            AccountRole accountRole = db.AccountRoles.Find(id);
            if (accountRole == null)
            {
                return NotFound();
            }

            return Ok(accountRole);
        }

        // PUT: api/AccountRoles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAccountRole(Guid id, AccountRole accountRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != accountRole.AccountRoleID)
            {
                return BadRequest();
            }

            db.Entry(accountRole).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountRoleExists(id))
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

        // POST: api/AccountRoles
        [ResponseType(typeof(AccountRole))]
        public IHttpActionResult PostAccountRole(AccountRole accountRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AccountRoles.Add(accountRole);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AccountRoleExists(accountRole.AccountRoleID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = accountRole.AccountRoleID }, accountRole);
        }

        // DELETE: api/AccountRoles/5
        [ResponseType(typeof(AccountRole))]
        public IHttpActionResult DeleteAccountRole(Guid id)
        {
            AccountRole accountRole = db.AccountRoles.Find(id);
            if (accountRole == null)
            {
                return NotFound();
            }

            db.AccountRoles.Remove(accountRole);
            db.SaveChanges();

            return Ok(accountRole);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AccountRoleExists(Guid id)
        {
            return db.AccountRoles.Count(e => e.AccountRoleID == id) > 0;
        }
    }
}