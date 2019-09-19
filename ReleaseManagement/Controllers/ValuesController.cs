using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using ReleaseManagement.Models;

namespace ReleaseManagement.Controllers {
    public class ValuesController : ApiController {
        // GET api/values
        public IHttpActionResult Get() {
            var releases = new List<Release>()
            {
                new Release() {
                    ApplicationVersion = "3.5.3",
                    ClientId = 1,
                    ClientApproverName = "Bob the approver",
                    ReleaseId = 1,
                    QaStartDate = DateTime.Now,
                    QatEndDate = DateTime.Now.AddDays(30),
                    UatStartDate = DateTime.Now.AddDays(30),
                    UatEndDate = DateTime.Now.AddDays(60),
                    Notes = "Release Notes"

                },

                new Release() {
                    ReleaseId = 2,
                    ApplicationVersion = "3.6.4",
                    ClientId = 2,
                    ClientApproverName = "Jane ",
                    QaStartDate = DateTime.Now,
                    QatEndDate = DateTime.Now.AddDays(30),
                    UatStartDate = DateTime.Now.AddDays(30),
                    UatEndDate = DateTime.Now.AddDays(60),
                    Notes = "Release Notes 2"

                },
            };
            return Ok(releases);
        }

        // GET api/values/5
        public string Get(int id) {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value) {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value) {
        }

        // DELETE api/values/5
        public void Delete(int id) {
        }
    }
}
