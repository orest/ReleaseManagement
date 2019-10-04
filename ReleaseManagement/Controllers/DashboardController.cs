using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ReleaseManagement.Data.Context;

namespace ReleaseManagement.Controllers {
    public class DashboardController : ApiController {


        public IHttpActionResult Get() {
            using (var db = new ReleaseManagementContext()) {
                var releaseCutoffDay = DateTime.Now.AddDays(-5);
                var releases = db.Releases.Include(p => p.Client).Include(p => p.ReleasePlatforms)
                    .Include(p => p.Features)
                    .Include(p => p.WorkItems)
                    .Where(p => p.ReleaseDate > releaseCutoffDay)
                    .OrderBy(p => p.ReleaseDate).ToList();
                return Ok(releases);
            }

        }
    }
}
