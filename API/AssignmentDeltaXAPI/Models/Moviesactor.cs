using System;
using System.Collections.Generic;

#nullable disable

namespace AssignmentDeltaXAPI.Models
{
    public partial class Moviesactor
    {
        public int Moviesid { get; set; }
        public int Actorsid { get; set; }

        public virtual Actor Actors { get; set; }
        public virtual Movie Movies { get; set; }
    }
}
