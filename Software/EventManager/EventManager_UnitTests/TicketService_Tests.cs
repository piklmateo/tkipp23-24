using BuisnessLayer.Services;
using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManager_UnitTests
{
    public class TicketService_Tests
    {
        [Fact]
        public void GetTickets_GivenNoTickets_ReturnsEmptyList()
        {
            // Arrange
            var ticketRepository = A.Fake<ITicketRepository>();
            var ticketService = new TicketService(ticketRepository);
            var tickets = new List<Ticket>();
            A.CallTo(() => ticketRepository.GetAll()).Returns(tickets.AsQueryable());

            // Act
            var result = ticketService.GetTickets();

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void GetTickets_GivenTickets_ReturnsTickets()
        {
            // Arrange
            var ticketRepository = A.Fake<ITicketRepository>();
            var ticketService = new TicketService(ticketRepository);
            var tickets = new List<Ticket> { new Ticket { Id = 1 }, new Ticket { Id = 2 } };
            A.CallTo(() => ticketRepository.GetAll()).Returns(tickets.AsQueryable());

            // Act
            var result = ticketService.GetTickets();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal(1, result[0].Id);
            Assert.Equal(2, result[1].Id);
        }

        [Fact]
        public void AddTicket_GivenValidTicket_ReturnsTrueOnSuccess()
        {
            // Arrange
            var ticketRepository = A.Fake<ITicketRepository>();
            var ticketService = new TicketService(ticketRepository);
            var ticket = new Ticket();
            A.CallTo(() => ticketRepository.Add(ticket, true)).Returns(1);

            // Act
            var result = ticketService.AddTicket(ticket);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void AddTicket_GivenInvalidTicket_ReturnsFalseOnFail()
        {
            // Arrange
            var ticketRepository = A.Fake<ITicketRepository>();
            var ticketService = new TicketService(ticketRepository);
            var ticket = new Ticket();
            A.CallTo(() => ticketRepository.Add(ticket, true)).Returns(0);

            // Act
            var result = ticketService.AddTicket(ticket);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void UpdateTicket_GivenValidTicket_ReturnsTrueOnSuccess()
        {
            // Arrange
            var ticketRepository = A.Fake<ITicketRepository>();
            var ticketService = new TicketService(ticketRepository);
            var ticket = new Ticket();
            A.CallTo(() => ticketRepository.Update(ticket, true)).Returns(1);

            // Act
            var result = ticketService.UpdateTicket(ticket);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void RemoveTicket_GivenValidTicket_ReturnsTrueWhenTicketCanBeRemoved()
        {
            // Arrange
            var ticketRepository = A.Fake<ITicketRepository>();
            var ticketService = new TicketService(ticketRepository);
            var ticket = new Ticket();
            A.CallTo(() => ticketRepository.Remove(ticket, true)).Returns(1);
            A.CallTo(() => ticketRepository.GetAllUserTickets(A<User>._)).Returns(new List<Ticket> { ticket }.AsQueryable());

            // Act
            var result = ticketService.RemoveTicket(ticket);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void RemoveTicket_GivenNullTicket_ReturnsFalseWhenTicketCannotBeRemoved()
        {
            // Arrange
            var ticketRepository = A.Fake<ITicketRepository>();
            var ticketService = new TicketService(ticketRepository);
            Ticket ticket = null;
            A.CallTo(() => ticketRepository.Remove(ticket, true)).Returns(0);

            // Act
            var result = ticketService.RemoveTicket(ticket);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GetTicketsByUser_GivenUser_ReturnsTicketsForUser()
        {
            // Arrange
            var ticketRepository = A.Fake<ITicketRepository>();
            var ticketService = new TicketService(ticketRepository);
            var user = new User { Id = 1 };
            var tickets = new List<Ticket> { new Ticket { Id = 1, User = user }, new Ticket { Id = 2, User = user } };
            A.CallTo(() => ticketRepository.GetAllUserTickets(user)).Returns(tickets.AsQueryable());

            // Act
            var result = ticketService.GetTicketsByUser(user);

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal(1, result[0].Id);
            Assert.Equal(2, result[1].Id);
        }

        [Fact]
        public void GetTicketsByEvent_GivenEvent_ReturnsTicketsForEvent()
        {
            // Arrange
            var ticketRepository = A.Fake<ITicketRepository>();
            var ticketService = new TicketService(ticketRepository);
            var selectedEvent = new Event { Id = 1 };
            var tickets = new List<Ticket> { new Ticket { Id = 1, Event = selectedEvent }, new Ticket { Id = 2, Event = selectedEvent } };
            A.CallTo(() => ticketRepository.GetAllEventTickets(selectedEvent)).Returns(tickets.AsQueryable());

            // Act
            var result = ticketService.GetTicketsByEvent(selectedEvent);

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal(1, result[0].Id);
            Assert.Equal(2, result[1].Id);
        }


    }
}
