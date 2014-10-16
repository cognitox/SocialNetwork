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
    public class GroupAccountStatusTypesController : ApiController
    {
        private SDBOAppContext db = new SDBOAppContext();

        // GET: api/GroupAccountStatusTypes
        public IQueryable<GroupAccountStatusType> GetGroupAccountStatusTypes()
        {
            return db.GroupAccountStatusTypes;
        }

        // GET: api/GroupAccountStatusTypes/5
        [ResponseType(typeof(GroupAccountStatusType))]
        public IHttpActionResult GetGroupAccountStatusType(Guid id)
        {
            GroupAccountStatusType groupAccountStatusType = db.GroupAccountStatusTypes.Find(id);
            if (groupAccountStatusType == null)
            {
                return NotFound();
            }

            return Ok(groupAccountStatusType);
        }

        // PUT: api/GroupAccountStatusTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGroupAccountStatusType(Guid id, GroupAccountStatusType groupAccountStatusType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != groupAccountStatusType.GroupAccountStatusTypeID)
            {
                return BadRequest();
            }

            db.Entry(groupAccountStatusType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupAccountStatusTypeExists(id))
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

        // POST: api/GroupAccountStatusTypes
        [ResponseType(typeof(GroupAccountStatusType))]
        public IHttpActionResult PostGroupAccountStatusType(GroupAccountStatusType groupAccountStatusType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GroupAccountStatusTypes.Add(groupAccountStatusType);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (GroupAccountStatusTypeExists(groupAccountStatusType.GroupAccountStatusTypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = groupAccountStatusType.GroupAccountStatusTypeID }, groupAccountStatusType);
        }

        // DELETE: api/GroupAccountStatusTypes/5
        [ResponseType(typeof(GroupAccountStatusType))]
        public IHttpActionResult DeleteGroupAccountStatusType(Guid id)
        {
            GroupAccountStatusType groupAccountStatusType = db.GroupAccountStatusTypes.Find(id);
            if (groupAccountStatusType == null)
            {
                return NotFound();
            }

            db.GroupAccountStatusTypes.Remove(groupAccountStatusType);
            db.SaveChanges();

            return Ok(groupAccountStatusType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GroupAccountStatusTypeExists(Guid id)
        {
            return db.GroupAccountStatusTypes.Count(e => e.GroupAccountStatusTypeID == id) > 0;
        }
    }
}