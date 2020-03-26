using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IndividualProjectCapstone.Models
{
    public class PendingApplication
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Developer")]
        public int DeveloperId { get; set; }
        public Developer Developer { get; set; }
        [ForeignKey("Opening")]
        public int OpeningId { get; set; }
        public Opening Opening { get; set; }

    }
}
