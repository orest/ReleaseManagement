namespace ReleaseManagement.Core.Models {
    public class WorkItem {
        public int WorkItemId { get; set; }
        public int ReleaseId { get; set; }
        public string Title { get; set; }
        public string TypeCode { get; set; }
        
        public Release Release { get; set; }
    }
}