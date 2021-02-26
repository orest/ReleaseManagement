using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReleaseManagement.Core.Models.Report
{
    public class ClientFeatures
    {
        public string DisplayName { get; set; }
        public int? FeatureId { get; set; }
        public string ClientName { get; set; }
        public int? ClientId { get; set; }
        public string ReleaseStatus { get; set; }
        public string FeatureStatus { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? ReleaseId { get; set; }
        public string ApplicationVersion { get; set; }
    }
}
