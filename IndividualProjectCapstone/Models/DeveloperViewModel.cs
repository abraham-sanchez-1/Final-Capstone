using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndividualProjectCapstone.Models
{
    public class DeveloperViewModel
    {
        public Developer Developer { get; set; }
        public List<ProjectMember> ProjectMembers { get; set; }
        public List<Project> Projects { get; set; }
        public List<Opening> RoleOpenings { get; set; }
    }
}
