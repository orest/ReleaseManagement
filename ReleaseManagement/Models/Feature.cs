using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReleaseManagement.Models {
    public class Feature {
        public int FeatureId { get; set; }
        public int DisplayName { get; set; }
        public int Description { get; set; }
        public int TypeCode { get; set; } // Core/Custom
        public string StatusCode { get; set; } // New, InProgress, Completed 
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; } 
        public bool IsCompleted { get; set; } 

    }
}