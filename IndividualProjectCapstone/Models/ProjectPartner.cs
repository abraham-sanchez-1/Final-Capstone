using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IndividualProjectCapstone.Models
{
    public class ProjectPartner
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Developer")]
        [Display(Name = "Partner")]
        public int UserId { get; set; }
        public Developer Developer { get; set; }
        [ForeignKey("Project")]
        [Display(Name = "Project Id")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }

    }
}
