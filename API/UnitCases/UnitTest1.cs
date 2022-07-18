using AssignmentDeltaXAPI.Controllers;
using AssignmentDeltaXAPI.Models;
using AssignmentDeltaXAPI.UtilityMethods.GetActorMethods;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xunit;
using System.Configuration;

namespace UnitCases
{
    public class UnitTest1
    {
        private readonly GetActors getActors;
        private Mock<AssignmentDeltaXContext> _context;
        public UnitTest1()
        {
            getActors = new GetActors();
            _context = new Mock<AssignmentDeltaXContext>();
            
        }
        [Fact]
        public void actor_Details()
        {
            var mockActor = new Mock<DbSet<Actor>>();
            mockActor.As<IQueryable<Actor>>().Setup(a => a.GetEnumerator()).Returns(GetActors().GetEnumerator());
            _context.Setup(a => a.Actors).Returns(mockActor.Object);
            getActors.ReturnListOfActors(_context.Object);
        }

        IQueryable<Actor> GetActors()
        {
            return new List<Actor>()
            {
                new Actor()
                {
                    ActorName ="Hey"
                }
            }.AsQueryable();
        }

    }

}
