using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ReleaseManagement.Core.Models.Base;


namespace ReleaseManagement.Controllers {
    [RoutePrefix("api/lookup")]
    public class LookupController : ApiController {
        [Route("feature-status-codes")]
        public IHttpActionResult GetFeatureStatusCodes() {
            var data = new List<LookupBase>() {
                new LookupBase(){Code ="new", DisplayName = "New"},
                new LookupBase(){Code ="in-progress", DisplayName = "In Progress"},
                new LookupBase(){Code ="completed", DisplayName = "Completed"},
            };
            return Ok(data);
        }

        [Route("release-status-codes")]
        public IHttpActionResult GetReleaseStatusCodes() {
            var data = new List<LookupBase>() {
                new LookupBase(){Code ="planning", DisplayName = "Planning"},
                new LookupBase(){Code ="in-progress", DisplayName = "In Progress"},
                new LookupBase(){Code ="completed", DisplayName = "Completed"},
            };
            return Ok(data);
        }


        [Route("feature-type-codes")]
        public IHttpActionResult GetFeatureTypeCodes() {
            var data = new List<LookupBase>() {
                new LookupBase(){Code ="core", DisplayName = "core"},
                new LookupBase(){Code ="client", DisplayName = "Client"},
            };
            return Ok(data);
        }

        [Route("work-item-types")]
        public IHttpActionResult GetWorkItemTypes() {
            var data = new List<LookupBase>() {
                new LookupBase(){Code ="bug", DisplayName = "Bug"},
                new LookupBase(){Code ="enhancement", DisplayName = "Enhancement"},
                new LookupBase(){Code ="change", DisplayName = "Change"},
            };
            return Ok(data);
        }
    }
}

