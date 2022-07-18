using AssignmentDeltaXAPI.Models;
using Microsoft.EntityFrameworkCore;
using NonSchemaModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentDeltaXAPI.UtilityMethods.GetActorMethods
{
    public class GetActors : IGetActors
    {
        public List<ActorModel> ReturnListOfActors(AssignmentDeltaXContext assignmentDeltaXContext)
        {
            List<ActorModel> actors = new();
            foreach (var item in assignmentDeltaXContext.Actors)
            {
                ActorModel actorModel = new ActorModel();
                actorModel.ActorName = item.ActorName;
                actorModel.Bio = item.Bio;
                actorModel.Dob = item.Dob;
                actors.Add(actorModel);
            }
            return actors;
        }
    }
}
