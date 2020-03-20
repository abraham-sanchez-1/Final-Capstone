using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IndividualProjectCapstone.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set;}
        [Required]
        [StringLength(200, MinimumLength = 50, ErrorMessage = "Description must have at least 50 characters and no more than 200 characters")]
        public string ReviewContent { get; set; }
        public bool LeftProjectEarly { get; set; }
        [Required]
        [Range(0, 10)]
        public int ReviewScore { get; set; }

    }
}
