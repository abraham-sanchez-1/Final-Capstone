using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndividualProjectCapstone.Models
{
    public class ActiveProjectViewModel
    {
        public Developer CurrentUser { get; set; }
        public List<Project> ActiveProjects { get; set; }
        public List<Project> CompletedProjects { get; set; }
    }
}
