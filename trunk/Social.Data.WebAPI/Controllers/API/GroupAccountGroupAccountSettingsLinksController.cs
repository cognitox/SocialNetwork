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
    public class GroupAccountGroupAccountSettingsLinksController : ApiController
    {
        private SDBOAppContext db = new SDBOAppContext();

        // GET: api/GroupAccountGroupAccountSettingsLinks
        public IQueryable<GroupAccountGroupAccountSettingsLink> GetGroupAccountGroupAccountSettingsLinks()
        {
            return db.GroupAccountGroupAccountSettingsLinks;
        }

        // GET: api/GroupAccountGroupAccountSettingsLinks/5
        [ResponseType(typeof(GroupAccountGroupAccountSettingsLink))]
        public IHttpActionResult GetGroupAccountGroupAccountSettingsLink(Guid id)
        {
            GroupAccountGroupAccountSettingsLink groupAccountGroupAccountSettingsLink = db.GroupAccountGroupAccountSettingsLinks.Find(id);
            if (groupAccountGroupAccountSettingsLink == null)
            {
                return NotFound();
            }

            return Ok(groupAccountGroupAccountSettingsLink);
        }

        // PUT: api/GroupAccountGroupAccountSettingsLinks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGroupAccountGroupAccountSettingsLink(Guid id, GroupAccountGroupAccountSettingsLink groupAccountGroupAccountSettingsLink)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != groupAccountGroupAccountSettingsLink.GroupAccountGroupAccountSettingsLinkID)
            {
                return BadRequest();
            }

            db.Entry(groupAccountGroupAccountSettingsLink).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupAccountGroupAccountSettingsLinkExists(id))
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

        // POST: api/GroupAccountGroupAccountSettingsLinks
        [ResponseType(typeof(GroupAccountGroupAccountSettingsLink))]
        public IHttpActionResult PostGroupAccountGroupAccountSettingsLink(GroupAccountGroupAccountSettingsLink groupAccountGroupAccountSettingsLink)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GroupAccountGroupAccountSettingsLinks.Add(groupAccountGroupAccountSettingsLink);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (GroupAccountGroupAccountSettingsLinkExists(groupAccountGroupAccountSettingsLink.GroupAccountGroupAccountSettingsLinkID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = groupAccountGroupAccountSettingsLink.GroupAccountGroupAccountSettingsLinkID }, groupAccountGroupAccountSettingsLink);
        }

        // DELETE: api/GroupAccountGroupAccountSettingsLinks/5
        [ResponseType(typeof(GroupAccountGroupAccountSettingsLink))]
        public IHttpActionResult DeleteGroupAccountGroupAccountSettingsLink(Guid id)
        {
            GroupAccountGroupAccountSettingsLink groupAccountGroupAccountSettingsLink = db.GroupAccountGroupAccountSettingsLinks.Find(id);
            if (groupAccountGroupAccountSettingsLink == null)
            {
                return NotFound();
            }

            db.GroupAccountGroupAccountSettingsLinks.Remove(groupAccountGroupAccountSettingsLink);
            db.SaveChanges();

            return Ok(groupAccountGroupAccountSettingsLink);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GroupAccountGroupAccountSettingsLinkExists(Guid id)
        {
            return db.GroupAccountGroupAccountSettingsLinks.Count(e => e.GroupAccountGroupAccountSettingsLinkID == id) > 0;
        }
    }
}