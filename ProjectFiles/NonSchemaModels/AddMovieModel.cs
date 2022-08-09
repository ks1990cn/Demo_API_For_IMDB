using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonSchemaModels
{
    public class AddMovieModel
    {
        public string MovieName { get; set; }
        public string Plot { get; set; }
        public DateTime? Dor { get; set; }
        public string Poster { get; set; }
        public List<int> actorID { get; set; }

        public int ProducerID { get; set; }
    }
}
