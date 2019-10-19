using System;
using System.Collections.Generic;

namespace ReleaseManagement.Core.Models {
    public class Release {
        public Release() {
            Features = new List<ReleaseFeature>();
            ReleasePlatforms = new List<ReleasePlatform>();
        }
        public int ReleaseId { get; set; }
        public string ApplicationVersion { get; set; }
        public int ClientId { get; set; }
        public string StatusCode { get; set; }
        public DateTime? QaStartDate { get; set; }
        public DateTime? QaEndDate { get; set; }
        public DateTime? UatStartDate { get; set; }
        public DateTime? UatEndDate { get; set; }
        public string ClientApproverName { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Notes { get; set; }
        public List<ReleasePlatform> ReleasePlatforms { get; set; }
        public List<ReleaseFeature> Features { get; set; }
        public List<WorkItem> WorkItems { get; set; }
        public Client Client { get; set; }

    }
}
