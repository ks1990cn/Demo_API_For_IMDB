using AssignmentDeltaXAPI.Models;
using AssignmentDeltaXAPI.UtilityMethods.AddMovieControllerMethods;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NonSchemaModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentDeltaXAPI.Controllers
{
    [ApiController]
    public class AddMovieController : ControllerBase
    {
        private AssignmentDeltaXContext AssignmentDeltaXContext;
        private IAddMovieControllerUtilsMethod addMovieControllerUtilsMethod;
        public AddMovieController(AssignmentDeltaXContext AssignmentDeltaXContext, IAddMovieControllerUtilsMethod addMovieControllerUtilsMethod)
        {
            this.AssignmentDeltaXContext = AssignmentDeltaXContext;
            this.addMovieControllerUtilsMethod = addMovieControllerUtilsMethod;
        }
        [HttpPost]
        [Route("/PostMovie")]
        public async Task<ActionResult<Movie>> PostMovie([FromBody] AddMovieModel movie)
        {

            Movie newMovie = new() { MovieName = movie.MovieName, Poster = movie.Poster, Plot = movie.Plot, Dor = movie.Dor, Producerid = movie.ProducerID };
            var producers = AssignmentDeltaXContext.Producers.ToDictionary(a => a.ProducerId, b => b);
            if (producers.ContainsKey(newMovie.Producerid))
            {
                newMovie.Producer = producers[newMovie.Producerid];
            }
            using (var transaction = AssignmentDeltaXContext.Database.BeginTransaction())
            {
                try
                {
                    addMovieControllerUtilsMethod.AddInMovieTable(AssignmentDeltaXContext, newMovie);

                    addMovieControllerUtilsMethod.AddMovieActorTableData(AssignmentDeltaXContext, movie);

                    await this.AssignmentDeltaXContext.SaveChangesAsync();

                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                }

                return Ok(newMovie);
            }
        }


    }
}
