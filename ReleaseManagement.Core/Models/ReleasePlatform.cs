using System;

namespace ReleaseManagement.Core.Models {
    public class ReleasePlatform {
        public int Id { get; set; }
        public string PlatformCode { get; set; }
        public int ReleaseId { get; set; }
        public DateTime? AvailableInStoreDate { get; set; }
        public DateTime? SubmittedForApprovalDate { get; set; }
        public Release Release { get; set; }

    }
}