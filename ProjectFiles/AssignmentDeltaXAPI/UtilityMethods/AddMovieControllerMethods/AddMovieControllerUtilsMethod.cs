using AssignmentDeltaXAPI.Models;
using Microsoft.EntityFrameworkCore;
using NonSchemaModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentDeltaXAPI.UtilityMethods.AddMovieControllerMethods
{
    public class AddMovieControllerUtilsMethod : IAddMovieControllerUtilsMethod
    {
        public void AddMovieActorTableData(AssignmentDeltaXContext assignmentDeltaXContext, AddMovieModel addMovieModel)
        {
            var GetMovieId = assignmentDeltaXContext.Movies.Count() > 0 ? assignmentDeltaXContext.Movies.OrderBy(a => a.MovieId).LastOrDefault().MovieId : 1;
            foreach (var item in addMovieModel.actorID)
            {
                string query = String.Format("insert into MOVIESACTORS(MOVIESID,ACTORSID) values({0},{1})", GetMovieId, item);
                //assignmentDeltaXContext.Moviesactors.FromSqlRaw(query);
                assignmentDeltaXContext.Moviesactors.Add(new() { Moviesid = GetMovieId, Actorsid = item });
            }
        }
        public void AddInMovieTable(AssignmentDeltaXContext assignmentDeltaXContext, Movie newMovie)
        {
            assignmentDeltaXContext.Movies.Add(newMovie);

            assignmentDeltaXContext.SaveChanges();
        }
        public void AddMovieProducerTableData(AssignmentDeltaXContext assignmentDeltaXContext, AddMovieModel addMovieModel)
        {
            //var GetMovieId = assignmentDeltaXContext.Movies.Count() > 0 ? assignmentDeltaXContext.Movies.OrderBy(a => a.MovieId).LastOrDefault().MovieId : 1;

            //assignmentDeltaXContext.Moviesproducers.Add(new Moviesproducer() { Producerid = addMovieModel.ProducerID, Moviesid = GetMovieId });

            //assignmentDeltaXContext.SaveChanges();
        }
    }
}
