using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IndividualProjectCapstone.Models
{
    public class Opening
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Proficiency Level Needed")]
        public int ProficiencyLevelNeeded { get; set; }
        public string ExampleUserStory { get; set; }
        public bool HasPendingApplication { get; set; }
        public bool IsFilled { get; set; }

        [ForeignKey("Project")]
        [Display(Name = "Project Id")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        [ForeignKey("RoleType")]
        public int RoleId { get; set; }
        public RoleType RoleType { get; set; }
        

    }
}
