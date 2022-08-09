using AssignmentDeltaXAPI.Models;
using NonSchemaModels;
using System.Collections.Generic;

namespace AssignmentDeltaXAPI.UtilityMethods.GetActorMethods
{
    public interface IGetActors
    {
        List<ActorModel> ReturnListOfActors(AssignmentDeltaXContext assignmentDeltaXContext);
    }
}