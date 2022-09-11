using AssignmentDeltaXAPI.Models;
using NonSchemaModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentDeltaXAPI.UtilityMethods.GetMovieDetails
{
    public class GetMovies : IGetMovies
    {
        public virtual void GetMoviesList(List<Movie> movies, List<GetMovieModel> resultMovies, Dictionary<int, Producer> producers, Dictionary<int, List<int>> moviesToActors)
        {
            foreach (var movie in movies)
            {
                GetMovieModel getMovieModel = new();
                getMovieModel.Dor = movie.Dor;
                getMovieModel.MovieName = movie.MovieName;
                getMovieModel.Plot = movie.Plot;
                getMovieModel.Poster = movie.Poster;

                GetMovieProducer(producers, movie, getMovieModel);

                if (moviesToActors.ContainsKey(movie.MovieId))
                {
                    foreach (var actorId in moviesToActors[movie.MovieId])
                    {
                        ActorModel actorModel = new();

                    }
                }
                resultMovies.Add(getMovieModel);
            }
        }

        private static void GetMovieProducer(Dictionary<int, Producer> producers, Movie movie, GetMovieModel getMovieModel)
        {
            if (producers.ContainsKey(movie.Producerid))
            {
                var producer = producers[movie.Producerid];
                getMovieModel.Producer = new();
                getMovieModel.Producer.Bio = producer.Bio;
                getMovieModel.Producer.Company = producer.Company;
                getMovieModel.Producer.Dob = producer.Dob;
                getMovieModel.Producer.Gender = producer.Gender;
                getMovieModel.Producer.ProducerName = producer.ProducerName;
            }
        }
    }
    public class NewGetMovies : GetMovies
    {
        public override void GetMoviesList(List<Movie> movies, List<GetMovieModel> resultMovies, Dictionary<int, Producer> producers, Dictionary<int, List<int>> moviesToActors)
        {
            throw new Exception("Nothing is implemented");
        }
    }
}
