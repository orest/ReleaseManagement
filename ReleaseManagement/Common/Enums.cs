using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReleaseManagement.Common {
    public static class Enums {
        public enum FeatureTypeCodes {
            Core,
            Custom
        }

        public enum FeatureStatusCodes {
            New, InProgress, Completed
        }
    }
}