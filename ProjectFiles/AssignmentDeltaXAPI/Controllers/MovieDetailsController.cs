using AssignmentDeltaXAPI.Filters;
using AssignmentDeltaXAPI.Models;
using AssignmentDeltaXAPI.UtilityMethods.GetMovieDetails;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NonSchemaModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentDeltaXAPI.Controllers
{
    [ErrorFilter]
    [ApiController]
    public class MovieDetailsController : ControllerBase
    {
        private AssignmentDeltaXContext xContext;
        List<Movie> movies;
        List<GetMovieModel> resultMovies;
        Dictionary<int, Producer> producers;
        Dictionary<int, List<int>> moviesToActors;
        IGetMovies GetMovies;
        public MovieDetailsController(AssignmentDeltaXContext xContext, IGetMovies getMovies)
        {
            this.xContext = xContext;
            this.GetMovies = getMovies;
        }
        [HttpGet]
        [Route("/GetMovie")]
        public  ActionResult<List<GetMovieModel>> GetMovie()
        {
            GetRequiredMappings(out movies, out resultMovies, out producers, out moviesToActors);

            GetMovies.GetMoviesList(movies, resultMovies, producers, moviesToActors);

            Debug.WriteLine("returned from get result");

            return Ok(resultMovies);

        }
        private void GetRequiredMappings(out List<Movie> movies, out List<GetMovieModel> resultMovies, out Dictionary<int, Producer> producers, out Dictionary<int, List<int>> moviesToActors)
        {
            movies = xContext.Movies.ToList();
            resultMovies = new();
            //var movieToProducer = xContext.Moviesproducers.ToDictionary(a => a.Moviesid, b => b.Producerid);
            producers = xContext.Producers.ToDictionary(a => a.ProducerId, b => b);
            moviesToActors = xContext.Moviesactors.AsEnumerable().GroupBy(a => a.Moviesid).ToDictionary(a => a.Key, b => b.Select(z => z.Actorsid).ToList());
            var actors = xContext.Actors.ToDictionary(a => a.ActorId, b => b);
        }
    }

}
