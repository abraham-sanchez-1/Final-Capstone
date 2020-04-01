using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndividualProjectCapstone.Models
{
    public class DeveloperReviewViewModel
    {
        public Developer Developer { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
