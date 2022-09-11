using AssignmentDeltaXAPI.Models;
using NonSchemaModels;
using System.Collections.Generic;

namespace AssignmentDeltaXAPI.UtilityMethods.GetMovieDetails
{
    public interface IGetMovies
    {
        void GetMoviesList(List<Movie> movies, List<GetMovieModel> resultMovies, Dictionary<int, Producer> producers, Dictionary<int, List<int>> moviesToActors);
    }
}