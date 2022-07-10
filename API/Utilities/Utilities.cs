using AssignmentDeltaXAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class Utilities
    {
        static List<int> GetActorsInMovie(AssignmentDeltaXContext assignmentDeltaXContext,int MovieID)
        {
            var movieToActors = assignmentDeltaXContext.Moviesactors.GroupBy(a => a.Moviesid)
                                 .ToDictionary(a => a.Key.Value, b => b.Select(z => z.Actorsid.Value).ToList());
            if (movieToActors.ContainsKey(MovieID))
            {
                return movieToActors[MovieID];
            }
            return null;
        }

        static void AddIntoActorMoviesTable(AssignmentDeltaXContext assignmentDeltaXContext,List<int> actors)
        {

        }
    }
}
