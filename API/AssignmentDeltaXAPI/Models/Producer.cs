using System;
using System.Collections.Generic;

#nullable disable

namespace AssignmentDeltaXAPI.Models
{
    public partial class Producer
    {
        public Producer()
        {
            Movies = new HashSet<Movie>();
        }

        public int ProducerId { get; set; }
        public string ProducerName { get; set; }
        public string Bio { get; set; }
        public DateTime? Dob { get; set; }
        public string Company { get; set; }
        public string Gender { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
