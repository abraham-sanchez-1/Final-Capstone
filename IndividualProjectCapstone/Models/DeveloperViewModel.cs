using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndividualProjectCapstone.Models
{
    public class DeveloperViewModel
    {
        public Developer CurrentUser { get; set; }
        public List<Project> AllProjects {get; set;}
    }
}
