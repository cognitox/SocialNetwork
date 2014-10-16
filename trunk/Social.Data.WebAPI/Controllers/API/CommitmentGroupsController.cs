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
    public class CommitmentGroupsController : ApiController
    {
        private SDBOAppContext db = new SDBOAppContext();

        // GET: api/CommitmentGroups
        public IQueryable<CommitmentGroup> GetCommitmentGroups()
        {
            return db.CommitmentGroups;
        }

        // GET: api/CommitmentGroups/5
        [ResponseType(typeof(CommitmentGroup))]
        public IHttpActionResult GetCommitmentGroup(Guid id)
        {
            CommitmentGroup commitmentGroup = db.CommitmentGroups.Find(id);
            if (commitmentGroup == null)
            {
                return NotFound();
            }

            return Ok(commitmentGroup);
        }

        // PUT: api/CommitmentGroups/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCommitmentGroup(Guid id, CommitmentGroup commitmentGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != commitmentGroup.CommitmentGroupID)
            {
                return BadRequest();
            }

            db.Entry(commitmentGroup).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommitmentGroupExists(id))
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

        // POST: api/CommitmentGroups
        [ResponseType(typeof(CommitmentGroup))]
        public IHttpActionResult PostCommitmentGroup(CommitmentGroup commitmentGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CommitmentGroups.Add(commitmentGroup);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CommitmentGroupExists(commitmentGroup.CommitmentGroupID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = commitmentGroup.CommitmentGroupID }, commitmentGroup);
        }

        // DELETE: api/CommitmentGroups/5
        [ResponseType(typeof(CommitmentGroup))]
        public IHttpActionResult DeleteCommitmentGroup(Guid id)
        {
            CommitmentGroup commitmentGroup = db.CommitmentGroups.Find(id);
            if (commitmentGroup == null)
            {
                return NotFound();
            }

            db.CommitmentGroups.Remove(commitmentGroup);
            db.SaveChanges();

            return Ok(commitmentGroup);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CommitmentGroupExists(Guid id)
        {
            return db.CommitmentGroups.Count(e => e.CommitmentGroupID == id) > 0;
        }
    }
}