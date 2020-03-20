using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IndividualProjectCapstone.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 50, ErrorMessage = "Description must have at least 50 characters and no more than 200 characters")]
        public string Description { get; set; }
        [Display(Name = "Creation Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime EndDate { get; set; }
        [Required]
        [Display(Name = "Primary Technology")]
        public string PrimaryTechnology { get; set; }
        public string SecondaryTechnology { get; set; }
        public bool IsComplete { get; set; }
        [ForeignKey("Developer")]
        [Display(Name = "Project Owner")]
        public int DeveloperId { get; set; }
        public Developer Developer { get; set; }

        [NotMapped]
        public List<Opening> Openings { get; set; }
        [NotMapped]
        public List<ProjectMember> ProjectMembers { get; set; }
    }
}
