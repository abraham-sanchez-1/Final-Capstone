using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IndividualProjectCapstone.Models
{
    public class ProjectMember
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("DeveloperId")]
        [Display(Name = "Project Member")]
        public int UserId { get; set; }
        public Developer Developer { get; set; }
        [ForeignKey("ProjectId")]
        [Display(Name = "Project Id")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        //making values here nullable also doesn't appear to resolve the issue
    }
}
