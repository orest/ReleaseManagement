using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Web.Http;
using Microsoft.Ajax.Utilities;
using ReleaseManagement.Core.Models;
using ReleaseManagement.Data.Context;
using ReleaseManagement.Core.Models.Report;
using System.Web.Http.Description;
using System.Dynamic;
using WebGrease.Css.Visitor;

namespace ReleaseManagement.Controllers
{
    public class ReportsController : ApiController
    {
        private ReleaseManagementContext db = new ReleaseManagementContext();

        // GET: api/Reports
        public IHttpActionResult Get()
        {

            using (var context = new ReleaseManagementContext())
            {
                var releases = context.Releases
                .Include(p => p.Client)
                .Where(p => p.StatusCode == "completed")
                .GroupBy(p => p.ClientId)
                .Select(grp => new
                {
                    grp.Key,
                    release = grp.OrderByDescending(p => p.ReleaseDate)
                    .Select(p => new { p.ApplicationVersion, p.Client.ClientName, p.StatusCode, p.ReleaseDate, p.ReleaseId })
                    .FirstOrDefault()
                }).ToList();

                return Ok(releases);
            }


        }

        [Route("api/Reports/GetClientFeatures")]
        public IHttpActionResult GetClientFeatures()
        {
            List<ClientFeatures> clientFeatures = db.Database.SqlQuery<ClientFeatures>("dbo.GetClientFeatures").ToList();

            var features = db.Features.OrderBy(p => p.FeatureId).ToList();
            var clients = db.Clients.OrderBy(p => p.ClientId).ToList();

            for (int i = 0; i < features.Count; i++)
            {
                var feature = features[i];
                var row = new ExpandoObject() as IDictionary<string, Object>;

                var featureClients = clientFeatures.Where(c => c.FeatureId == feature.FeatureId).ToList();

                List<string> prop = clients.Select(o => o.ClientName).ToList();              

                foreach (var client in clients)
                {
                    var featureClient = featureClients.FirstOrDefault(p => p.ClientId == client.ClientId);

                    if (featureClient != null)
                    {
                        row.Add(featureClient.ClientName, featureClient.ReleaseStatus);
                    }
                }
            }

            return Ok(clientFeatures);
        }
    }
}
