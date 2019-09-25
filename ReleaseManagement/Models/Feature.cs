using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReleaseManagement.Models {
    public class Feature {
        public int FeatureId { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string TypeCode { get; set; } // Core/Custom
        public string StatusCode { get; set; } // New, InProgress, Completed 
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; } 
        public bool IsCompleted { get; set; } 

    }
}
