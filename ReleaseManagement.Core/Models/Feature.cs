using System;
using System.Collections;
using System.Collections.Generic;

namespace ReleaseManagement.Core.Models {
    public class Feature {
        public Feature()
        {
            Releases=new List<Release>();
        }
        public int FeatureId { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string TypeCode { get; set; } 
        public string StatusCode { get; set; } // New, InProgress, Completed 
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsCompleted { get; set; }
        public ICollection<Release> Releases { get; set; }

    }
}


