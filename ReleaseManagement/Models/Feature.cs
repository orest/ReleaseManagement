using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReleaseManagement.Models {
    public class Feature {
        public int FeatureId { get; set; }
        public int FeatureName { get; set; }
        public int Description { get; set; }
        public int TypeCode { get; set; } // Core/Custom
    }
}