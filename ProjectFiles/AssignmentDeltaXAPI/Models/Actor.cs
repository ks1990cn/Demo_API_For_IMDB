using System;
using System.Collections.Generic;

#nullable disable

namespace AssignmentDeltaXAPI.Models
{
    public partial class Actor
    {
        public Actor()
        {
            Moviesactors = new HashSet<Moviesactor>();
        }

        public int ActorId { get; set; }
        public string ActorName { get; set; }
        public string Bio { get; set; }
        public DateTime? Dob { get; set; }
        public string Company { get; set; }
        public string Gender { get; set; }

        public virtual ICollection<Moviesactor> Moviesactors { get; set; }
    }
}
