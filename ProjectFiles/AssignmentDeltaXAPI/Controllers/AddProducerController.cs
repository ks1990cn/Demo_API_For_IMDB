using AssignmentDeltaXAPI.Models;
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
    public class AddProducerController : ControllerBase
    {
        private AssignmentDeltaXContext AssignmentDeltaXContext;
        public AddProducerController(AssignmentDeltaXContext AssignmentDeltaXContext)
        {
            this.AssignmentDeltaXContext = AssignmentDeltaXContext;
        }
        [HttpPost]
        [Route("/PostProducer")]
        public async Task<ActionResult<Producer>> PostProducer([FromBody] AddProducer producer)
        {
            Producer newProducer = new Producer() { ProducerName = producer.ProducerName, Bio = producer.Bio, Company = producer.Company, Dob = producer.Dob, Gender = producer.Gender };
            using (var transaction = AssignmentDeltaXContext.Database.BeginTransaction())
            {
                try
                {
                    await this.AssignmentDeltaXContext.Producers.AddAsync(newProducer);
                    var result = await this.AssignmentDeltaXContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();

                }
                return Ok(newProducer);
            }
        }
    }
}
