using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReleaseManagement.Core.Models.Base {
    public class BaseWorkUnit {
        public bool? IsApiCompleted { get; set; }
        public bool IsUiCompleted { get; set; }
        public string StatusCode { get; set; } // New, InProgress, Completed 
    }
}
