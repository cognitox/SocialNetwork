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
    public class GroupAccountTypesController : ApiController
    {
        private SDBOAppContext db = new SDBOAppContext();

        // GET: api/GroupAccountTypes
        public IQueryable<GroupAccountType> GetGroupAccountTypes()
        {
            return db.GroupAccountTypes;
        }

        // GET: api/GroupAccountTypes/5
        [ResponseType(typeof(GroupAccountType))]
        public IHttpActionResult GetGroupAccountType(Guid id)
        {
            GroupAccountType groupAccountType = db.GroupAccountTypes.Find(id);
            if (groupAccountType == null)
            {
                return NotFound();
            }

            return Ok(groupAccountType);
        }

        // PUT: api/GroupAccountTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGroupAccountType(Guid id, GroupAccountType groupAccountType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != groupAccountType.GroupAccountTypeID)
            {
                return BadRequest();
            }

            db.Entry(groupAccountType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupAccountTypeExists(id))
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

        // POST: api/GroupAccountTypes
        [ResponseType(typeof(GroupAccountType))]
        public IHttpActionResult PostGroupAccountType(GroupAccountType groupAccountType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GroupAccountTypes.Add(groupAccountType);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (GroupAccountTypeExists(groupAccountType.GroupAccountTypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = groupAccountType.GroupAccountTypeID }, groupAccountType);
        }

        // DELETE: api/GroupAccountTypes/5
        [ResponseType(typeof(GroupAccountType))]
        public IHttpActionResult DeleteGroupAccountType(Guid id)
        {
            GroupAccountType groupAccountType = db.GroupAccountTypes.Find(id);
            if (groupAccountType == null)
            {
                return NotFound();
            }

            db.GroupAccountTypes.Remove(groupAccountType);
            db.SaveChanges();

            return Ok(groupAccountType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GroupAccountTypeExists(Guid id)
        {
            return db.GroupAccountTypes.Count(e => e.GroupAccountTypeID == id) > 0;
        }
    }
}