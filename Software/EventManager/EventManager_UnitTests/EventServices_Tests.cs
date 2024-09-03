using BuisnessLayer;
using DataAccessLayer.Interfaces;
using EntitiesLayer.Entities;
using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManager_UnitTests
{
    public class EventServices_Tests
    {
        [Fact]
        public void GetEvents_GivenValidEvents_ReturnsListOfEvents()
        {
            // Arrange
            var fakeRepository = A.Fake<IEventRepository>();
            var fakeEvents = new List<Event> { new Event { Name = "Event1" }, new Event { Name = "Event2" } };
            A.CallTo(() => fakeRepository.GetAll()).Returns(fakeEvents.AsQueryable());

            var service = new EventServices(fakeRepository);

            // Act
            var result = service.GetEvents();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal("Event1", result[0].Name);
            Assert.Equal("Event2", result[1].Name);
        }

        [Fact]
        public void GetEventsByNameAllIncluded_GivenValidEventName_ReturnsMatchingEvents()
        {
            // Arrange
            var fakeRepository = A.Fake<IEventRepository>();
            var fakeEvents = new List<Event> { new Event { Name = "Event1" }, new Event { Name = "Event2" } };
            A.CallTo(() => fakeRepository.GetEventsByNameAllIncluded("Event")).Returns(fakeEvents.AsQueryable());

            var service = new EventServices(fakeRepository);

            // Act
            var result = service.GetEventsByNameAllIncluded("Event");

            // Assert
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void GetEventByName_GivenValidEventName_ReturnsSingleEvent()
        {
            // Arrange
            var fakeRepository = A.Fake<IEventRepository>();
            var fakeEvent = new Event { Name = "Event1" };
            A.CallTo(() => fakeRepository.GetEventByName("Event1")).Returns(fakeEvent);

            var service = new EventServices(fakeRepository);

            // Act
            var result = service.GetEventByName("Event1");

            // Assert
            Assert.Equal("Event1", result.Name);
        }

        [Fact]
        public void GetEventsByCategory_GivenValidCategory_ReturnsMatchingEvents()
        {
            // Arrange
            var fakeRepository = A.Fake<IEventRepository>();
            var fakeEventCategory = new EventCategory { Id = 1, Name = "Category1" };
            var fakeEvents = new List<Event> { new Event { Name = "Event1", Id_Category = 1 } };
            A.CallTo(() => fakeRepository.GetEventsByCategory(fakeEventCategory)).Returns(fakeEvents.AsQueryable());

            var service = new EventServices(fakeRepository);

            // Act
            var result = service.GetEventsByCategory(fakeEventCategory);

            // Assert
            Assert.Single(result);
            Assert.Equal("Event1", result[0].Name);
        }

        [Fact]
        public void AddEvent_GivenValidEvent_ReturnsTrueOnSuccess()
        {
            // Arrange
            var fakeRepository = A.Fake<IEventRepository>();
            var newEvent = new Event { Name = "New Event" };

            A.CallTo(() => fakeRepository.Add(newEvent, true)).Returns(1);

            var service = new EventServices(fakeRepository);

            // Act
            var result = service.AddEvent(newEvent);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void AddEvent_GivenInvalidEvent_ReturnsFalseOnFailure()
        {
            // Arrange
            var fakeRepository = A.Fake<IEventRepository>();
            var newEvent = new Event { Name = "New Event" };

            A.CallTo(() => fakeRepository.Add(newEvent, true)).Returns(0);

            var service = new EventServices(fakeRepository);

            // Act
            var result = service.AddEvent(newEvent);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void UpdateEvent_GivenValidEvent_ReturnsTrueOnSuccess()
        {
            // Arrange
            var fakeRepository = A.Fake<IEventRepository>();
            var eventToUpdate = new Event { Name = "Event to Update" };

            A.CallTo(() => fakeRepository.Update(eventToUpdate, true)).Returns(1);

            var service = new EventServices(fakeRepository);

            // Act
            var result = service.UpdateEvent(eventToUpdate);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void UpdateEvent_GivenInvalidEvent_ReturnsFalseOnFailure()
        {
            // Arrange
            var fakeRepository = A.Fake<IEventRepository>();
            var eventToUpdate = new Event { Name = "Event to Update" };

            A.CallTo(() => fakeRepository.Update(eventToUpdate, true)).Returns(0);

            var service = new EventServices(fakeRepository);

            // Act
            var result = service.UpdateEvent(eventToUpdate);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void RemoveEvent_GivenValidEvent_ReturnsTrueOnSuccess()
        {
            // Arrange
            var fakeRepository = A.Fake<IEventRepository>();
            var eventToRemove = new Event { Name = "Event to Remove" };

            A.CallTo(() => fakeRepository.Remove(eventToRemove, true)).Returns(1);

            var service = new EventServices(fakeRepository);

            // Act
            var result = service.RemoveEvent(eventToRemove);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void RemoveEvent_GivenInvalidEvent_ReturnsFalseOnFailure()
        {
            // Arrange
            var fakeRepository = A.Fake<IEventRepository>();
            var eventToRemove = new Event { Name = "Event to Remove" };

            A.CallTo(() => fakeRepository.Remove(eventToRemove, true)).Returns(0);

            var service = new EventServices(fakeRepository);

            // Act
            var result = service.RemoveEvent(eventToRemove);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void RemoveEvent_GivenNullEvent_ReturnsFalseIfEventIsNull()
        {
            // Arrange
            var fakeRepository = A.Fake<IEventRepository>();
            var service = new EventServices(fakeRepository);

            // Act
            var result = service.RemoveEvent(null);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GetEventsByVenue_GivenSpecificVenue_ReturnsEventsAtSpecificVenue()
        {
            // Arrange
            var fakeRepo = A.Fake<IEventRepository>();
            var eventsList = new List<Event>
            {
                new Event { Id = 1, Id_Venue = 1 },
                new Event { Id = 2, Id_Venue = 2 }
            }.AsQueryable();
            var closeVenues = new List<Venue>
            {
                new Venue { Id = 1 }
            };
            A.CallTo(() => fakeRepo.GetAll()).Returns(eventsList);
            var service = new EventServices(fakeRepo);

            // Act
            var result = service.GetEventsByVenue(closeVenues);

            // Assert
            Assert.Single(result);
            Assert.Equal(1, result[0].Id_Venue);
        }

        [Fact]
        public void GetEventsByTicketsAndCurrentDate_GivenTicketsAndCurrentDate_ReturnsEventsForCurrentDate()
        {
            // Arrange
            var fakeRepo = A.Fake<IEventRepository>();
            var currentDate = DateTime.Today;
            var eventsList = new List<Event>
            {
                new Event { Id = 1, EventDate = currentDate, Id_Venue = 1 },
                new Event { Id = 2, EventDate = currentDate.AddDays(-1), Id_Venue = 2 }
            }.AsQueryable();
            var tickets = new List<Ticket>
            {
                new Ticket { Id_Events = 1 }
            };

            A.CallTo(() => fakeRepo.GetAll()).Returns(eventsList);
            var service = new EventServices(fakeRepo);

            // Act
            var result = service.GetEventsByTicketsAndCurrentDate(tickets, currentDate);

            // Assert
            Assert.Single(result);
            Assert.Equal(1, result[0].Id);
        }

        [Fact]
        public void GetEventsByTransactionAndCurrentDate_GivenTransactionsAndCurrentDate_ReturnsEventsForCurrentDate()
        {
            // Arrange
            var fakeRepo = A.Fake<IEventRepository>();
            var currentDate = DateTime.Today;
            var eventsList = new List<Event>
            {
                new Event { Id = 1, EventDate = currentDate, Id_Venue = 1 },
                new Event { Id = 2, EventDate = currentDate.AddDays(-1), Id_Venue = 2 }
            }.AsQueryable();
            var transactions = new List<Transaction>
            {
                new Transaction { Id_Events = 1 }
            };

            A.CallTo(() => fakeRepo.GetAll()).Returns(eventsList);
            var service = new EventServices(fakeRepo);

            // Act
            var result = service.GetEventsByTransactionAndCurrentDate(transactions, currentDate);

            // Assert
            Assert.Single(result);
            Assert.Equal(1, result[0].Id);
        }

        [Fact]
        public void RemoveEvent_GivenNullEvent_ShouldReturnFalseIfEventIsNull()
        {
            // Arrange
            var fakeRepo = A.Fake<IEventRepository>();
            var service = new EventServices(fakeRepo);
            Event nullEvent = null;

            // Act
            var result = service.RemoveEvent(nullEvent);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void RemoveEvent_GivenRemovableEvent_ShouldReturnTrueIfEventCanBeRemoved()
        {
            // Arrange
            var fakeRepo = A.Fake<IEventRepository>();
            var existingEvent = new Event { Id = 1 };
            A.CallTo(() => fakeRepo.Remove(existingEvent, true)).Returns(1);
            var service = new EventServices(fakeRepo);

            // Act
            var result = service.RemoveEvent(existingEvent);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void GetEventsByUser_GivenUserTickets_ShouldReturnUserEvents()
        {
            // Arrange
            var fakeRepo = A.Fake<IEventRepository>();
            var eventsList = new List<Event>
            {
                new Event { Id = 1 },
                new Event { Id = 2 }
            }.AsQueryable();
            var userTickets = new List<Ticket>
            {
                new Ticket { Id_Events = 1 }
            };

            A.CallTo(() => fakeRepo.GetAll()).Returns(eventsList);
            var service = new EventServices(fakeRepo);

            // Act
            var result = service.GetEventsByUser(userTickets);

            // Assert
            Assert.Single(result);
            Assert.Equal(1, result[0].Id);
        }

    }
}
