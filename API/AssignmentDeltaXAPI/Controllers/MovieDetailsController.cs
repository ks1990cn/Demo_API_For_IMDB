using AssignmentDeltaXAPI.Models;
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
    [ApiController]
    public class MovieDetailsController : ControllerBase
    {
        private AssignmentDeltaXContext xContext;
        public MovieDetailsController(AssignmentDeltaXContext xContext)
        {
            this.xContext = xContext;
        }
        [HttpPost]
        [Route("/GetMovie")]
        public  ActionResult<List<GetMovieModel>> GetMovie()
        {
            var movies = xContext.Movies.ToList();
            List<GetMovieModel> resultMovies = new();
            //var movieToProducer = xContext.Moviesproducers.ToDictionary(a => a.Moviesid, b => b.Producerid);
            var producers = xContext.Producers.ToDictionary(a => a.ProducerId, b => b);
            var moviesToActors = xContext.Moviesactors.AsEnumerable().GroupBy(a => a.Moviesid).ToDictionary(a => a.Key, b => b.Select(z => z.Actorsid).ToList());
            var actors = xContext.Actors.ToDictionary(a => a.ActorId, b => b);
            foreach (var movie in movies)
            {
                GetMovieModel getMovieModel = new();
                getMovieModel.Dor = movie.Dor;
                getMovieModel.MovieName = movie.MovieName;
                getMovieModel.Plot = movie.Plot;
                getMovieModel.Poster = movie.Poster;
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
                if (moviesToActors.ContainsKey(movie.MovieId))
                {
                    foreach (var actorId in moviesToActors[movie.MovieId])
                    {
                        ActorModel actorModel = new();

                    }
                }
                resultMovies.Add(getMovieModel);
            }
            Debug.WriteLine("returned from get result");
            return Ok(resultMovies);
            
        }

    }
}
