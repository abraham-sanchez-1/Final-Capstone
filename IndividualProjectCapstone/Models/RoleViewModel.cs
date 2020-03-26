using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndividualProjectCapstone.Models
{
    public class RoleViewModel
    {
        public Project Project { get; set; }
        public RoleType RoleType { get; set; }
        public Opening Opening { get; set; }
    }
}
