using BuisnessLayer;
using BuisnessLayer.Services;
using DataAccessLayer.Exceptions;
using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManager_IntegrationTests
{
    public class EventService_IntegrationTests
    {
        [Fact]
        public void GetEvents_GivenEventsExist_ReturnsEvents()
        {
            // Arrange
            var eventRepository = new EventRepository();
            var eventService = new EventServices(eventRepository);

            // Act
            var result = eventService.GetEvents();

            // Assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GetEventByName_GivenExistingEventName_ReturnsEvent()
        {
            // Arrange
            var eventRepository = new EventRepository();
            var eventService = new EventServices(eventRepository);
            var eventName = "Ferragosto JAM";

            // Act
            var result = eventService.GetEventByName(eventName);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Ferragosto JAM", result.Name);
        }

        [Fact]
        public void AddEvent_GivenValidEventData_ReturnsTrueOnSuccess()
        {
            // Arrange
            var eventRepository = new EventRepository();
            var eventService = new EventServices(eventRepository);

            var newEvent = new Event
            {
                Name = "Remove Event Test",
                Id_Venue = 1,
                EventDate = new DateTime(2024, 6, 30, 0, 0, 0, DateTimeKind.Utc),
                StartTime = new TimeSpan(8, 0, 0),
                Id_Organizer = 7,
                Id_Category = 4,
                imgUrl = "fejkUrl"
            };

            // Act
            var result = eventService.AddEvent(newEvent);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void AddEvent_GivenInvalidEventData_ThrowsException()
        {
            // Arrange
            var eventRepository = new EventRepository();
            var eventService = new EventServices(eventRepository);
            var newEvent = new Event();

            // Assert
            Assert.Throws<EventException>(() => eventService.AddEvent(newEvent));
        }

        [Fact]
        public void UpdateEvent_GivenValidEventData_ReturnsTrueOnSuccess()
        {
            // Arrange
            var eventRepository = new EventRepository();
            var eventService = new EventServices(eventRepository);
            var eventName = "Dummy Event";
            var uniqueId = Guid.NewGuid().ToString();

            var events = eventService.GetEventByName(eventName);
            events.Name = "Dummy Event" + uniqueId;

            // Act
            var result = eventService.UpdateEvent(events);

            // Assert
            Assert.True(result);
        }


        [Fact]
        public void UpdateEvent_GivenInvalidEventData_ThrowsException()
        {
            // Arrange
            var eventRepository = new EventRepository();
            var eventService = new EventServices(eventRepository);
            var newEvent = new Event();

            // Assert
            Assert.Throws<EventException>(() => eventService.UpdateEvent(newEvent));
        }

        [Fact]
        public void RemoveEvent_GivenExistingEvent_ReturnsTrueWhenEventRemoved()
        {
            // Arrange
            var eventRepository = new EventRepository();
            var eventService = new EventServices(eventRepository);
            var eventName = "Remove Event Test";

            var events = eventService.GetEventByName(eventName);

            // Act
            var result = eventService.RemoveEvent(events);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void RemoveEvent_GivenNullEvent_ReturnsFalse()
        {
            // Arrange
            var eventRepository = new EventRepository();
            var eventService = new EventServices(eventRepository);
            Event newEvent = null;

            // Act
            var result = eventService.RemoveEvent(newEvent);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GetEventsByCategory_GivenValidCategory_ReturnsEventsByCategory()
        {
            // Arrange
            var eventRepository = new EventRepository();
            var eventService = new EventServices(eventRepository);
            var eventCategory = new EventCategory { Id = 4, Name = "Festival" };

            // Act
            var result = eventService.GetEventsByCategory(eventCategory);

            // Assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GetEventsByCategory_GivenInvalidCategory_ReturnsEmptyList()
        {
            // Arrange
            var eventRepository = new EventRepository();
            var eventService = new EventServices(eventRepository);
            var eventCategory = new EventCategory { Id = 0, Name = "Invalid" };

            // Act
            var result = eventService.GetEventsByCategory(eventCategory);

            // Assert
            Assert.Empty(result);
        }

        // write tests for GetEventsByNameAllIncluded
        [Fact]
        public void GetEventsByNameAllIncluded_GivenExistingEventName_ReturnsEvents()
        {
            // Arrange
            var eventRepository = new EventRepository();
            var eventService = new EventServices(eventRepository);
            var eventName = "Ferragosto JAM";

            // Act
            var result = eventService.GetEventsByNameAllIncluded(eventName);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GetEventsByNameAllIncluded_GivenNonExistingEventName_ReturnsEmptyList()
        {
            // Arrange
            var eventRepository = new EventRepository();
            var eventService = new EventServices(eventRepository);
            var eventName = "FejkEvent";

            // Act
            var result = eventService.GetEventsByNameAllIncluded(eventName);

            // Assert
            Assert.Empty(result); 
        }

        // write tests for GetEventsByVenue
        [Fact]
        public void GetEventsByVenue_GivenValidVenue_ReturnsEventsByVenue()
        {
            // Arrange
            var eventRepository = new EventRepository();
            var eventService = new EventServices(eventRepository);
            var venue = new Venue { Id = 1, Name = "CZK" };
            var closeVenues = new List<Venue> { venue };

            // Act
            var result = eventService.GetEventsByVenue(closeVenues);

            // Assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GetEventsByVenue_GivenInvalidVenue_ReturnsEmptyList()
        {
            // Arrange
            var eventRepository = new EventRepository();
            var eventService = new EventServices(eventRepository);
            var venue = new Venue { Id = 999, Name = "FejkEvent" };
            var closeVenues = new List<Venue> { venue };

            // Act
            var result = eventService.GetEventsByVenue(closeVenues);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void GetEventsByTicketsAndCurrentDate_GivenValidTicketsAndCurrentDate_ReturnsEvents()
        {
            // Arrange
            var eventRepository = new EventRepository();
            var eventService = new EventServices(eventRepository);
            var tickets = new List<Ticket> { new Ticket { Id_Events = 147 } };
            var currentDate = new DateTime(2024, 6, 30, 0, 0, 0, DateTimeKind.Utc);

            // Act
            var result = eventService.GetEventsByTicketsAndCurrentDate(tickets, currentDate);

            // Assert
            Assert.NotEmpty(result);
            Assert.NotNull(result);
        }

        [Fact]
        public void GetEventsByTicketsAndCurrentDate_GivenInvalidTicketsOrCurrentDate_ReturnsEmptyList()
        {
            // Arrange
            var eventRepository = new EventRepository();
            var eventService = new EventServices(eventRepository);
            var tickets = new List<Ticket> { new Ticket { Id_Events = 999 } };
            var currentDate = new DateTime(2024, 6, 8, 0, 0, 0, DateTimeKind.Utc);

            // Act
            var result = eventService.GetEventsByTicketsAndCurrentDate(tickets, currentDate);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void GetEventsByTransactionAndCurrentDate_GivenValidTransactionsAndCurrentDate_ReturnsEvents()
        {
            // Arrange
            var eventRepository = new EventRepository();
            var eventService = new EventServices(eventRepository);
            var transactions = new List<Transaction> { new Transaction { Id_Events = 147 } };
            var currentDate = new DateTime(2024, 6, 30, 0, 0, 0, DateTimeKind.Utc);

            // Act
            var result = eventService.GetEventsByTransactionAndCurrentDate(transactions, currentDate);

            // Assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GetEventsByTransactionAndCurrentDate_GivenInvalidTransactionsOrCurrentDate_ReturnsEmptyList()
        {
            // Arrange
            var eventRepository = new EventRepository();
            var eventService = new EventServices(eventRepository);
            var transactions = new List<Transaction> { new Transaction { Id_Events = 999 } };
            var currentDate = new DateTime(2024, 6, 8, 0, 0, 0, DateTimeKind.Utc);

            // Act
            var result = eventService.GetEventsByTransactionAndCurrentDate(transactions, currentDate);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void GetEventsByUser_GivenValidUserTickets_ReturnsEventsByUser()
        {
            // Arrange
            var eventRepository = new EventRepository();
            var eventService = new EventServices(eventRepository);
            var user = new User { Id = 1 };
            var tickets = new List<Ticket> { new Ticket { Id_Events = 147, Id_Users = user.Id } };

            // Act
            var result = eventService.GetEventsByUser(tickets);

            // Assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GetEventsByUser_GivenInvalidUserAndTickets_ReturnsEmptyList()
        {
            // Arrange
            var eventRepository = new EventRepository();
            var eventService = new EventServices(eventRepository);
            var user = new User { Id = 999 };
            var tickets = new List<Ticket> { new Ticket { Id_Events = 999, Id_Users = user.Id } };

            // Act
            var result = eventService.GetEventsByUser(tickets);

            // Assert
            Assert.Empty(result);
        }
    }
}
