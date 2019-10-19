using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using ReleaseManagement.Common;
using ReleaseManagement.Core.Models;
using ReleaseManagement.Data.Context;

namespace ReleaseManagement.Controllers {
    public class ReleasesController : ApiController {
        private ReleaseManagementContext db = new ReleaseManagementContext();

        // GET: api/Releases
        public IHttpActionResult GetReleases() {
            var releases = db.Releases.Include(p => p.Client).Include(p => p.ReleasePlatforms)
                .Include(p => p.Features)
                .Include(p => p.WorkItems)
                .OrderByDescending(p => p.QaStartDate).ToList();
            return Ok(releases);
        }

        // GET: api/Releases/5
        [ResponseType(typeof(Release))]
        public IHttpActionResult GetRelease(int id) {
            Release release = db.Releases
                .Include(p => p.Client)
                .Include(p => p.ReleasePlatforms)
                .Include(p => p.Features)
                .Include("Features.Feature")
                .Include(p => p.WorkItems)
                .FirstOrDefault(p => p.ReleaseId == id);
            if(release == null) {
                return NotFound();
            }

            return Ok(release);
        }

        // PUT: api/Releases/5
        public IHttpActionResult PutRelease(int id, Release releaseModel) {
            if(!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            if(id != releaseModel.ReleaseId) {
                return BadRequest();
            }
            Release entity = db.Releases
                .Include(p => p.ReleasePlatforms)
                .Include(p => p.Features)
                .Include(p => p.WorkItems)
                .First(p => p.ReleaseId == id);

            entity.ApplicationVersion = releaseModel.ApplicationVersion;
            entity.ClientId = releaseModel.ClientId;
            entity.StatusCode = releaseModel.StatusCode;
            entity.ClientApproverName = releaseModel.ClientApproverName;
            entity.Notes = releaseModel.Notes;
            entity.QaStartDate = releaseModel.QaStartDate;
            entity.QaEndDate = releaseModel.QaEndDate;
            entity.UatStartDate = releaseModel.UatStartDate;
            entity.UatEndDate = releaseModel.UatEndDate;
            entity.ReleaseDate = releaseModel.ReleaseDate;

            //


            var toDelete = entity.ReleasePlatforms.Where(e => releaseModel.ReleasePlatforms.Count(m => m.PlatformCode == e.PlatformCode) == 0).ToList();
            if(toDelete.Any()) {
                toDelete.ForEach(d => db.ReleasePlatforms.Remove(d));
            }


            releaseModel.ReleasePlatforms.ToList().ForEach(model => {
                var existingEntity = entity.ReleasePlatforms.SingleOrDefault(e => e.PlatformCode == model.PlatformCode);
                if(existingEntity != null) {

                    existingEntity.AvailableInStoreDate = model.AvailableInStoreDate;
                    existingEntity.SubmittedForApprovalDate = model.SubmittedForApprovalDate;
                    //db.ReleasePlatforms.Update(existingEntity);
                } else { //add                        
                    var newPlatform = new ReleasePlatform {
                        ReleaseId = model.ReleaseId,
                        PlatformCode = model.PlatformCode,
                        AvailableInStoreDate = model.AvailableInStoreDate,
                        SubmittedForApprovalDate = model.SubmittedForApprovalDate
                    };
                    db.ReleasePlatforms.Add(newPlatform);
                }
            });

            try {
                db.SaveChanges();
            } catch(DbUpdateConcurrencyException) {
                if(!ReleaseExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }


        [Route("api/Releases/{id}/assign")]
        public IHttpActionResult PostAssignFeature(int id, Feature model) {
            if(!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            //var entity = db.Releases.Include(p => p.Features).First(p => p.ReleaseId == id);
            //var feature = db.Features.Find(model.FeatureId);
            var releaseFeatute = new ReleaseFeature {
                ReleaseId = id,
                FeatureId = model.FeatureId,
                StatusCode = Enums.RelaseStatusCodes.New.ToString()
            };
            db.ReleaseFeatures.Add(releaseFeatute);

            try {
                db.SaveChanges();
            } catch(DbUpdateConcurrencyException) {
                if(!ReleaseExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return Ok(releaseFeatute);
        }



        // POST: api/Releases
        [ResponseType(typeof(Release))]
        public IHttpActionResult PostRelease(Release release) {
            if(!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            db.Releases.Add(release);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = release.ReleaseId }, release);
        }

        // DELETE: api/Releases/5
        [ResponseType(typeof(Release))]
        public IHttpActionResult DeleteRelease(int id) {
            Release release = db.Releases.Find(id);
            if(release == null) {
                return NotFound();
            }

            db.Releases.Remove(release);
            db.SaveChanges();

            return Ok(release);
        }

        protected override void Dispose(bool disposing) {
            if(disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReleaseExists(int id) {
            return db.Releases.Count(e => e.ReleaseId == id) > 0;
        }
    }
}