using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonSchemaModels
{
   public class GetMovieModel
    {
        public string MovieName { get; set; }
        public string Plot { get; set; }
        public DateTime? Dor { get; set; }
        public string Poster { get; set; }
        public List<ActorModel> actorModels { get; set; }

        public AddProducer Producer { get; set; }
    }
}
