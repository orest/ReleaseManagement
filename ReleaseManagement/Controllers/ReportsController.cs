using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ReleaseManagement.Data.Context;

namespace ReleaseManagement.Controllers {
    public class ReportsController : ApiController {
        private ReleaseManagementContext db = new ReleaseManagementContext();

        // GET: api/Reports
        public IHttpActionResult Get() {

            var releases = db.Releases
               .Include(p => p.Client)
               .Where(p => p.StatusCode == "completed")
               .GroupBy(p => p.ClientId)
               .Select(grp => new
               {
                   grp.Key, release = grp.OrderByDescending(p => p.ReleaseDate)
                   .Select(p => new { p.ApplicationVersion, p.Client.ClientName, p.StatusCode, p.ReleaseDate })
                   .FirstOrDefault()
               }).ToList();
                   
               
            return Ok(releases);

        }
    }
}
