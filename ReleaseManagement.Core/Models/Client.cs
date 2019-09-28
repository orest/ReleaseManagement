using System.Collections;
using System.Collections.Generic;

namespace ReleaseManagement.Core.Models {
    public class Client {
        public Client() {
            Releases = new List<Release>();
        }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Release> Releases { get; set; }

    }
}


