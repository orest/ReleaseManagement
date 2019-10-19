using System;
using System.Collections;
using System.Collections.Generic;
using ReleaseManagement.Core.Models.Base;

namespace ReleaseManagement.Core.Models {
    public class Feature : BaseWorkUnit {
        public Feature() {
            Releases = new List<ReleaseFeature>();
        }
        public int FeatureId { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ICollection<ReleaseFeature> Releases { get; set; }
    }
}


