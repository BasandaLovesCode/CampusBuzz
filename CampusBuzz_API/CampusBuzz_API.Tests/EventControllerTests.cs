using Xunit;
using CampusBuzz_API.Controllers;
using CampusBuzz_API.Models;
using CampusBuzz_API.Repositories;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CampusBuzz_API.Tests
{
    public class EventControllerTests
    {
        // Test 1: Retrieve all Events
        [Fact]
        public async Task GetAllEvents_ReturnsOk_WithListOfEvents()
        {
            // Arrange - set up fake data
            var mockRepo = new Mock<IEventRepository>();
            mockRepo.Setup(repo => repo.GetAllEvents())
                .ReturnsAsync(new List<Event>
                {
                    new Event { EventId = 1, EventTitle = "Tech Workshop", Location = "Lab A", TicketPrice = "$50" },
                    new Event { EventId = 2, EventTitle = "Music Festival", Location = "Main Hall", TicketPrice = "$120" }
                });

            var controller = new EventController(mockRepo.Object);

            // Act - call the method
            var result = await controller.GetAllEvents();

            // Assert - check the response
            var okResult = result.Result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult!.StatusCode.Should().Be(200);
            okResult.Value.Should().NotBeNull();
        }

        // Test 2: Retrieve an Event by ID
        [Fact]
        public async Task GetEventById_ReturnsOk_WithEvent()
        {
            // Arrange - set up fake data
            var mockRepo = new Mock<IEventRepository>();
            mockRepo.Setup(repo => repo.GetEventById(1))
                .ReturnsAsync(new Event
                {
                    EventId = 1,
                    EventTitle = "Tech Workshop",
                    Location = "Lab A",
                    TicketPrice = "$50"
                });

            var controller = new EventController(mockRepo.Object);

            // Act - call the method
            var result = await controller.GetEvent(1);

            // Assert - check the response
            var okResult = result.Result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult!.StatusCode.Should().Be(200);
            okResult.Value.Should().NotBeNull();
        }
    }
}
