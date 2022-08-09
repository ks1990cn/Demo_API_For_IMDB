using AssignmentDeltaXAPI.Filters;
using AssignmentDeltaXAPI.Models;
using AssignmentDeltaXAPI.UtilityMethods.GetActorMethods;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NonSchemaModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentDeltaXAPI.Controllers
{
    [ApiController]
    public class AddActorController : ControllerBase
    {
        private AssignmentDeltaXContext AssignmentDeltaXContext;
        private IGetActors _actors;
        public AddActorController(AssignmentDeltaXContext AssignmentDeltaXContext, IGetActors actors)
        {
            this._actors = actors;
            this.AssignmentDeltaXContext = AssignmentDeltaXContext;
        }
        [HttpPost]
        [Route("/PostActor")]
        public async Task<ActionResult<Actor>> PostActor([FromBody] ActorModel actor)
        {
            var newActor = new Actor() { ActorName = actor.ActorName, Bio = actor.Bio, Company = actor.Company, Dob = actor.Dob, Gender = actor.Gender };
            await this.AssignmentDeltaXContext.Actors.AddAsync(newActor);
            var result = await this.AssignmentDeltaXContext.SaveChangesAsync();
            if (result == 1) return Ok(actor);
            return BadRequest();
        }

        [HttpGet]
        [Route("/GetActor")]
        [AuthorizationFilter]
        public ActionResult<List<ActorModel>> GetActors()
        {
            return Ok(this._actors.ReturnListOfActors(AssignmentDeltaXContext));
        }
}
}
