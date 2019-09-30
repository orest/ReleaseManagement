using ReleaseManagement.Core.Models.Base;

namespace ReleaseManagement.Core.Models {
    public class WorkItem : BaseWorkUnit {
        public int WorkItemId { get; set; }
        public int ReleaseId { get; set; }
        public string Title { get; set; }
        public string TypeCode { get; set; } //Bug, Enhancement, Maintenance  
        public Release Release { get; set; }
    }
}