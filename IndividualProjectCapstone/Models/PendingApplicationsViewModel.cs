using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndividualProjectCapstone.Models
{
    public class PendingApplicationsViewModel
    {
        public Opening Opening { get; set; }
        public List<PendingApplication> PendingApplications { get; set; }
    }
}
