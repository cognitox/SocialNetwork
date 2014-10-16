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
    public class GroupAccountSettingsTypesController : ApiController
    {
        private SDBOAppContext db = new SDBOAppContext();

        // GET: api/GroupAccountSettingsTypes
        public IQueryable<GroupAccountSettingsType> GetGroupAccountSettingsTypes()
        {
            return db.GroupAccountSettingsTypes;
        }

        // GET: api/GroupAccountSettingsTypes/5
        [ResponseType(typeof(GroupAccountSettingsType))]
        public IHttpActionResult GetGroupAccountSettingsType(Guid id)
        {
            GroupAccountSettingsType groupAccountSettingsType = db.GroupAccountSettingsTypes.Find(id);
            if (groupAccountSettingsType == null)
            {
                return NotFound();
            }

            return Ok(groupAccountSettingsType);
        }

        // PUT: api/GroupAccountSettingsTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGroupAccountSettingsType(Guid id, GroupAccountSettingsType groupAccountSettingsType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != groupAccountSettingsType.GroupAccountSettingsTypeID)
            {
                return BadRequest();
            }

            db.Entry(groupAccountSettingsType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupAccountSettingsTypeExists(id))
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

        // POST: api/GroupAccountSettingsTypes
        [ResponseType(typeof(GroupAccountSettingsType))]
        public IHttpActionResult PostGroupAccountSettingsType(GroupAccountSettingsType groupAccountSettingsType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GroupAccountSettingsTypes.Add(groupAccountSettingsType);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (GroupAccountSettingsTypeExists(groupAccountSettingsType.GroupAccountSettingsTypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = groupAccountSettingsType.GroupAccountSettingsTypeID }, groupAccountSettingsType);
        }

        // DELETE: api/GroupAccountSettingsTypes/5
        [ResponseType(typeof(GroupAccountSettingsType))]
        public IHttpActionResult DeleteGroupAccountSettingsType(Guid id)
        {
            GroupAccountSettingsType groupAccountSettingsType = db.GroupAccountSettingsTypes.Find(id);
            if (groupAccountSettingsType == null)
            {
                return NotFound();
            }

            db.GroupAccountSettingsTypes.Remove(groupAccountSettingsType);
            db.SaveChanges();

            return Ok(groupAccountSettingsType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GroupAccountSettingsTypeExists(Guid id)
        {
            return db.GroupAccountSettingsTypes.Count(e => e.GroupAccountSettingsTypeID == id) > 0;
        }
    }
}