using AssignmentDeltaXAPI.Models;
using NonSchemaModels;

namespace AssignmentDeltaXAPI.UtilityMethods.AddMovieControllerMethods
{
    public interface IAddMovieControllerUtilsMethod
    {
        void AddMovieActorTableData(AssignmentDeltaXContext assignmentDeltaXContext, AddMovieModel addMovieModel);

        void AddInMovieTable(AssignmentDeltaXContext assignmentDeltaXContext, Movie newMovie);

        void AddMovieProducerTableData(AssignmentDeltaXContext assignmentDeltaXContext, AddMovieModel addMovieModel);
    }
}