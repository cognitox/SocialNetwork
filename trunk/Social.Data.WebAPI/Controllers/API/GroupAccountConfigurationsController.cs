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
    public class GroupAccountConfigurationsController : ApiController
    {
        private SDBOAppContext db = new SDBOAppContext();

        // GET: api/GroupAccountConfigurations
        public IQueryable<GroupAccountConfiguration> GetGroupAccountConfigurations()
        {
            return db.GroupAccountConfigurations;
        }

        // GET: api/GroupAccountConfigurations/5
        [ResponseType(typeof(GroupAccountConfiguration))]
        public IHttpActionResult GetGroupAccountConfiguration(Guid id)
        {
            GroupAccountConfiguration groupAccountConfiguration = db.GroupAccountConfigurations.Find(id);
            if (groupAccountConfiguration == null)
            {
                return NotFound();
            }

            return Ok(groupAccountConfiguration);
        }

        // PUT: api/GroupAccountConfigurations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGroupAccountConfiguration(Guid id, GroupAccountConfiguration groupAccountConfiguration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != groupAccountConfiguration.GroupAccountConfigurationID)
            {
                return BadRequest();
            }

            db.Entry(groupAccountConfiguration).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupAccountConfigurationExists(id))
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

        // POST: api/GroupAccountConfigurations
        [ResponseType(typeof(GroupAccountConfiguration))]
        public IHttpActionResult PostGroupAccountConfiguration(GroupAccountConfiguration groupAccountConfiguration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GroupAccountConfigurations.Add(groupAccountConfiguration);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (GroupAccountConfigurationExists(groupAccountConfiguration.GroupAccountConfigurationID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = groupAccountConfiguration.GroupAccountConfigurationID }, groupAccountConfiguration);
        }

        // DELETE: api/GroupAccountConfigurations/5
        [ResponseType(typeof(GroupAccountConfiguration))]
        public IHttpActionResult DeleteGroupAccountConfiguration(Guid id)
        {
            GroupAccountConfiguration groupAccountConfiguration = db.GroupAccountConfigurations.Find(id);
            if (groupAccountConfiguration == null)
            {
                return NotFound();
            }

            db.GroupAccountConfigurations.Remove(groupAccountConfiguration);
            db.SaveChanges();

            return Ok(groupAccountConfiguration);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GroupAccountConfigurationExists(Guid id)
        {
            return db.GroupAccountConfigurations.Count(e => e.GroupAccountConfigurationID == id) > 0;
        }
    }
}