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
    public class GroupAccountSettingsController : ApiController
    {
        private SDBOAppContext db = new SDBOAppContext();

        // GET: api/GroupAccountSettings
        public IQueryable<GroupAccountSetting> GetGroupAccountSettings()
        {
            return db.GroupAccountSettings;
        }

        // GET: api/GroupAccountSettings/5
        [ResponseType(typeof(GroupAccountSetting))]
        public IHttpActionResult GetGroupAccountSetting(Guid id)
        {
            GroupAccountSetting groupAccountSetting = db.GroupAccountSettings.Find(id);
            if (groupAccountSetting == null)
            {
                return NotFound();
            }

            return Ok(groupAccountSetting);
        }

        // PUT: api/GroupAccountSettings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGroupAccountSetting(Guid id, GroupAccountSetting groupAccountSetting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != groupAccountSetting.GroupAccountSettingsID)
            {
                return BadRequest();
            }

            db.Entry(groupAccountSetting).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupAccountSettingExists(id))
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

        // POST: api/GroupAccountSettings
        [ResponseType(typeof(GroupAccountSetting))]
        public IHttpActionResult PostGroupAccountSetting(GroupAccountSetting groupAccountSetting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GroupAccountSettings.Add(groupAccountSetting);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (GroupAccountSettingExists(groupAccountSetting.GroupAccountSettingsID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = groupAccountSetting.GroupAccountSettingsID }, groupAccountSetting);
        }

        // DELETE: api/GroupAccountSettings/5
        [ResponseType(typeof(GroupAccountSetting))]
        public IHttpActionResult DeleteGroupAccountSetting(Guid id)
        {
            GroupAccountSetting groupAccountSetting = db.GroupAccountSettings.Find(id);
            if (groupAccountSetting == null)
            {
                return NotFound();
            }

            db.GroupAccountSettings.Remove(groupAccountSetting);
            db.SaveChanges();

            return Ok(groupAccountSetting);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GroupAccountSettingExists(Guid id)
        {
            return db.GroupAccountSettings.Count(e => e.GroupAccountSettingsID == id) > 0;
        }
    }
}