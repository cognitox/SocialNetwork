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
    public class GroupAccountMetaDatasController : ApiController
    {
        private SDBOAppContext db = new SDBOAppContext();

        // GET: api/GroupAccountMetaDatas
        public IQueryable<GroupAccountMetaData> GetGroupAccountMetaDatas()
        {
            return db.GroupAccountMetaDatas;
        }

        // GET: api/GroupAccountMetaDatas/5
        [ResponseType(typeof(GroupAccountMetaData))]
        public IHttpActionResult GetGroupAccountMetaData(Guid id)
        {
            GroupAccountMetaData groupAccountMetaData = db.GroupAccountMetaDatas.Find(id);
            if (groupAccountMetaData == null)
            {
                return NotFound();
            }

            return Ok(groupAccountMetaData);
        }

        // PUT: api/GroupAccountMetaDatas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGroupAccountMetaData(Guid id, GroupAccountMetaData groupAccountMetaData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != groupAccountMetaData.GroupAccountMetaDataID)
            {
                return BadRequest();
            }

            db.Entry(groupAccountMetaData).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupAccountMetaDataExists(id))
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

        // POST: api/GroupAccountMetaDatas
        [ResponseType(typeof(GroupAccountMetaData))]
        public IHttpActionResult PostGroupAccountMetaData(GroupAccountMetaData groupAccountMetaData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GroupAccountMetaDatas.Add(groupAccountMetaData);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (GroupAccountMetaDataExists(groupAccountMetaData.GroupAccountMetaDataID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = groupAccountMetaData.GroupAccountMetaDataID }, groupAccountMetaData);
        }

        // DELETE: api/GroupAccountMetaDatas/5
        [ResponseType(typeof(GroupAccountMetaData))]
        public IHttpActionResult DeleteGroupAccountMetaData(Guid id)
        {
            GroupAccountMetaData groupAccountMetaData = db.GroupAccountMetaDatas.Find(id);
            if (groupAccountMetaData == null)
            {
                return NotFound();
            }

            db.GroupAccountMetaDatas.Remove(groupAccountMetaData);
            db.SaveChanges();

            return Ok(groupAccountMetaData);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GroupAccountMetaDataExists(Guid id)
        {
            return db.GroupAccountMetaDatas.Count(e => e.GroupAccountMetaDataID == id) > 0;
        }
    }
}