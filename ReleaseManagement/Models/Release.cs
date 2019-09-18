using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReleaseManagement.Models {
    public class Release {
        public Release() {
            Features = new List<Feature>();
            ReleasePlatforms = new List<ReleasePlatform>();
        }
        public int ReleaseId { get; set; }
        public int ApplicationVersion { get; set; }
        public int ClientId { get; set; }
        public DateTime? QaStartDate { get; set; }
        public DateTime? QatEndDate { get; set; }
        public DateTime? UatStartDate { get; set; }
        public DateTime? UatEndDate { get; set; }
        public string ClientApproverName { get; set; }
        public List<ReleasePlatform> ReleasePlatforms { get; set; }
        public List<Feature> Features { get; set; }
        public Client Client { get; set; }


    }
}