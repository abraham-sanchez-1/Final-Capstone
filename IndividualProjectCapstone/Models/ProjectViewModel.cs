using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndividualProjectCapstone.Models
{
    public class ProjectViewModel
    {
        //Will not be used for the time being
        public Project Project { get; set; }
        public List<Opening> Openings { get; set; }
        public List<Developer> DevelopersInProject { get; set; }
    }
}
