using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReleaseManagement.Common {
    public static class Enums {

        public enum FeatureStatusCodes {
            New, InProgress, Completed
        }

        public enum ReleaseFeatureStatusCodes {
            New, InProgress, Completed
        }

        public enum WorkItemTypeCodes {

            Unknown, Bug, Enhancement, Maintenance
        }
    }
}