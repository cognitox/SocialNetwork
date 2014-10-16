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
    public class GroupAccountRolesController : ApiController
    {
        private SDBOAppContext db = new SDBOAppContext();

        // GET: api/GroupAccountRoles
        public IQueryable<GroupAccountRole> GetGroupAccountRoles()
        {
            return db.GroupAccountRoles;
        }

        // GET: api/GroupAccountRoles/5
        [ResponseType(typeof(GroupAccountRole))]
        public IHttpActionResult GetGroupAccountRole(Guid id)
        {
            GroupAccountRole groupAccountRole = db.GroupAccountRoles.Find(id);
            if (groupAccountRole == null)
            {
                return NotFound();
            }

            return Ok(groupAccountRole);
        }

        // PUT: api/GroupAccountRoles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGroupAccountRole(Guid id, GroupAccountRole groupAccountRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != groupAccountRole.GroupAccountRoleID)
            {
                return BadRequest();
            }

            db.Entry(groupAccountRole).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupAccountRoleExists(id))
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

        // POST: api/GroupAccountRoles
        [ResponseType(typeof(GroupAccountRole))]
        public IHttpActionResult PostGroupAccountRole(GroupAccountRole groupAccountRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GroupAccountRoles.Add(groupAccountRole);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (GroupAccountRoleExists(groupAccountRole.GroupAccountRoleID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = groupAccountRole.GroupAccountRoleID }, groupAccountRole);
        }

        // DELETE: api/GroupAccountRoles/5
        [ResponseType(typeof(GroupAccountRole))]
        public IHttpActionResult DeleteGroupAccountRole(Guid id)
        {
            GroupAccountRole groupAccountRole = db.GroupAccountRoles.Find(id);
            if (groupAccountRole == null)
            {
                return NotFound();
            }

            db.GroupAccountRoles.Remove(groupAccountRole);
            db.SaveChanges();

            return Ok(groupAccountRole);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GroupAccountRoleExists(Guid id)
        {
            return db.GroupAccountRoles.Count(e => e.GroupAccountRoleID == id) > 0;
        }
    }
}