using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IndividualProjectCapstone.Models
{
    public class Developer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        public string UserName { get; set; }
        [ForeignKey("IdentityUser")]
        [Display(Name = "Identity User")]
        public string UserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
        [ForeignKey("RoleType")]
        public int RoleId { get; set; }
        public RoleType RoleType { get; set; }
        [Required]
        [Range(1,4)]
        public int ProficiencyLevel { get; set; }
        [StringLength(100, ErrorMessage = "You have gone over the 100 character limit!")]
        public string AboutUser { get; set; }
        public string UrlPicture { get; set; }

    }
}
