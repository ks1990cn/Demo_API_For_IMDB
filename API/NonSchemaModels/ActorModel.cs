using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonSchemaModels
{
    /// <summary>
    /// This is Actor model for parameter
    /// </summary>
    public class ActorModel
    {
        public string ActorName { get; set; }
        public string Bio { get; set; }
        public DateTime? Dob { get; set; }
        public string Company { get; set; }
        public string Gender { get; set; }

    }
}
