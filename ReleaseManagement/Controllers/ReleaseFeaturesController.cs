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
using ReleaseManagement.Core.Models;
using ReleaseManagement.Data.Context;

namespace ReleaseManagement.Controllers {
    public class ReleaseFeaturesController : ApiController {
        private ReleaseManagementContext db = new ReleaseManagementContext();

        // GET: api/ReleaseFeatures
        public IHttpActionResult GetReleaseFeatures() {
            return Ok(db.ReleaseFeatures.ToList());
        }

        // GET: api/ReleaseFeatures/5
        [ResponseType(typeof(ReleaseFeature))]
        public IHttpActionResult GetReleaseFeature(int id) {
            ReleaseFeature releaseFeature = db.ReleaseFeatures.Find(id);
            if(releaseFeature == null) {
                return NotFound();
            }

            return Ok(releaseFeature);
        }

        // PUT: api/ReleaseFeatures/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutReleaseFeature(int id, ReleaseFeature releaseFeature) {
            if(!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            if(id != releaseFeature.ReleaseFeatureId) {
                return BadRequest();
            }

            db.Entry(releaseFeature).State = EntityState.Modified;

            try {
                db.SaveChanges();
            } catch(DbUpdateConcurrencyException) {
                if(!ReleaseFeatureExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ReleaseFeatures
        [ResponseType(typeof(ReleaseFeature))]
        public IHttpActionResult PostReleaseFeature(ReleaseFeature releaseFeature) {
            if(!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            db.ReleaseFeatures.Add(releaseFeature);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = releaseFeature.ReleaseFeatureId }, releaseFeature);
        }

        // DELETE: api/ReleaseFeatures/5
        [ResponseType(typeof(ReleaseFeature))]
        public IHttpActionResult DeleteReleaseFeature(int id) {
            ReleaseFeature releaseFeature = db.ReleaseFeatures.Find(id);
            if(releaseFeature == null) {
                return NotFound();
            }

            db.ReleaseFeatures.Remove(releaseFeature);
            db.SaveChanges();

            return Ok(releaseFeature);
        }

        protected override void Dispose(bool disposing) {
            if(disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReleaseFeatureExists(int id) {
            return db.ReleaseFeatures.Count(e => e.ReleaseFeatureId == id) > 0;
        }
    }
}