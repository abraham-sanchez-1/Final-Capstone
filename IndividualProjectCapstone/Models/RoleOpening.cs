using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IndividualProjectCapstone.Models
{
    public class RoleOpening
    {
        [Key]
        public int Id { get; set; }
        public string DeveloperTypeNeeded { get; set; }
        public int ProficiencyLevelNeeded { get; set; }
        public string ExampleUserStory { get; set; }
        public bool HasPendingApplication { get; set; }
        [ForeignKey("Project")]
        [Display(Name = "Project Id")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }

    }
}
