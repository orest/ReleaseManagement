using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReleaseManagement.Core.Models {
    public class ReleaseFeature {
        public int ReleaseFeatureId { get; set; }
        public int ReleaseId { get; set; }
        public int FeatureId { get; set; }
        public string StatusCode { get; set; }
        public Release Release { get; set; }
        public Feature Feature { get; set; }
    }
}
