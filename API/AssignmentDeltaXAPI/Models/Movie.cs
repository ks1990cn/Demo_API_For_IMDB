using System;
using System.Collections.Generic;

#nullable disable

namespace AssignmentDeltaXAPI.Models
{
    public partial class Movie
    {
        public Movie()
        {
            Moviesactors = new HashSet<Moviesactor>();
        }

        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string Plot { get; set; }
        public DateTime? Dor { get; set; }
        public string Poster { get; set; }
        public int Producerid { get; set; }

        public virtual Producer Producer { get; set; }
        public virtual ICollection<Moviesactor> Moviesactors { get; set; }
    }
}
