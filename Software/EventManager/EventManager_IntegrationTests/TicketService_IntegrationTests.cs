using BuisnessLayer.Services;
using DataAccessLayer;
using DataAccessLayer.Iznimke;
using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace EventManager_IntegrationTests
{
    public class TicketService_IntegrationTests
    {
        [Fact]
        public void GetTickets_GivenTicketsAreInDatabase_ReturnsAllTickets()
        {
            // Arrange
            var ticketRepository = new TicketRepository();
            var ticketService = new TicketService(ticketRepository);

            // Act
            var tickets = ticketService.GetTickets();

            // Assert
            Assert.NotEmpty(tickets);
        }

        [Fact]
        public void GetTickets_GivenTicketsAreInDatabase_ReturnsNotEmptyAndNotNull()
        {
            // Arrange
            var ticketRepository = new TicketRepository();
            var ticketService = new TicketService(ticketRepository);

            // Act
            var tickets = ticketService.GetTickets();

            // Assert
            Assert.NotNull(tickets);
            Assert.NotEmpty(tickets);
        }

        [Fact]
        public void AddTicket_GivenValidTicket_ReturnsTrueWhenTicketAdded()
        {
            // Arrange
            var ticketRepository = new TicketRepository();
            var ticketService = new TicketService(ticketRepository);

            var newTicket = new Ticket
            {
                Event = new Event
                {
                    Id = 147,
                    Name = "Remove Event",
                    Id_Venue = 1,
                    EventDate = new DateTime(2024, 6, 30, 0, 0, 0, DateTimeKind.Utc),
                    StartTime = new TimeSpan(8, 0, 0),
                    Id_Organizer = 7,
                    Id_Category = 4,
                    imgUrl = "fejkUrl",
                },
                TicketCategory = new TicketCategory
                {
                    Id = 1,
                    Name = "VIP"
                },
                Price = 200,
                Amount = 200,
                Id_Users = 3
            };


            // Act
            var result = ticketService.AddTicket(newTicket);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void AddTicket_GivenInvalidEvent_ThrowsExceptionOnInvalidEvent()
        {
            //Arrange
            var ticketRepository = new TicketRepository();
            var ticketService = new TicketService(ticketRepository);
            var newTicket = new Ticket
            {
                Event = new Event(),
                TicketCategory = new TicketCategory(),
                Price = 200,
                Id_Users = 3999,
                Amount = 200,
            };
            // Act and Assert
            Assert.Throws<TicketException>(() => ticketService.AddTicket(newTicket));
        }

        [Fact]
        public void UpdateTicket_GivenValidEvent_ReturnsTrueWhenTicketUpdated()
        {
            // Arrange
            var ticketRepository = new TicketRepository();
            var ticketService = new TicketService(ticketRepository);

            var events = new Event
            {
                Id = 147,
                Name = "Remove Event",
                Id_Venue = 1,
                EventDate = new DateTime(2024, 6, 30, 0, 0, 0, DateTimeKind.Utc),
                StartTime = new TimeSpan(8, 0, 0),
                Id_Organizer = 7,
                Id_Category = 4,
                imgUrl = "fejkUrl",
            };

            var ticket = ticketService.GetTicketsByEvent(events).FirstOrDefault();
            ticket.Price = 300;

            // Act
            var result = ticketService.UpdateTicket(ticket);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void UpdateTicket_GivenInvalidTicket_ThrowsExceptionOnInvalidEvent()
        {
            //Arrange
            var ticketRepository = new TicketRepository();
            var ticketService = new TicketService(ticketRepository);
            var ticket = new Ticket
            {
                Event = new Event(),
                TicketCategory = new TicketCategory(),
                Price = 200,
                Id_Users = 3999,
                Amount = 200,
            };
            // Act and Assert
            Assert.Throws<TicketException>(() => ticketService.UpdateTicket(ticket));
        }

        [Fact]
        public void RemoveTicket_GivenSelectedValidTicket_ReturnsTrueWhenTicketRemoved()
        {
            // Arrange
            var ticketRepository = new TicketRepository();
            var ticketService = new TicketService(ticketRepository);
            var events = new Event
            {
                Id = 147,
                Name = "Remove Event",
                Id_Venue = 1,
                EventDate = new DateTime(2024, 6, 30, 0, 0, 0, DateTimeKind.Utc),
                StartTime = new TimeSpan(8, 0, 0),
                Id_Organizer = 7,
                Id_Category = 4,
                imgUrl = "fejkUrl",
            };

            var ticket = ticketService.GetTicketsByEvent(events)[0];

            // Act
            var result = ticketService.RemoveTicket(ticket);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void RemoveTicket_GivenNoTicketSelected_ReturnsFalseWhenTicketIsNull()
        {
            // Arrange
            var ticketRepository = new TicketRepository();
            var ticketService = new TicketService(ticketRepository);

            Ticket ticket = null;

            // Act
            var result = ticketService.RemoveTicket(ticket);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GetTicketsByEvent_GivenValidEvent_ReturnsTicketsByEvent()
        {
            // Arrange
            var ticketRepository = new TicketRepository();
            var ticketService = new TicketService(ticketRepository);

            var selectedEvent = new Event
            {
                Id = 22,
                Name = "Dinamo-Istra",
                Id_Venue = 3,
                EventDate = new DateTime(2024, 1, 29, 0, 0, 0, DateTimeKind.Utc),
                StartTime = new TimeSpan(12, 0, 0),
                Id_Organizer = 5,
                Id_Category = 3,
                imgUrl = "https://www.zgportal.com/wp-content/uploads/2021/10/dinamo-istra-ht-prva-liga-2021-2022.jpg",
            };

            // Act
            var tickets = ticketService.GetTicketsByEvent(selectedEvent);

            // Assert
            Assert.NotEmpty(tickets);
        }

        [Fact]
        public void GetTicketsByEvent_GivenInvalidEvent_ReturnsEmptyListWhenEventIsNull()
        {
            // Arrange
            var ticketRepository = new TicketRepository();
            var ticketService = new TicketService(ticketRepository);

            Event selectedEvent = new();

            // Act
            var tickets = ticketService.GetTicketsByEvent(selectedEvent);

            // Assert
            Assert.Empty(tickets);
        }

        [Fact]
        public void GetTicketsByUser_GivenValidUser_ReturnsTicketsByUser()
        {
            // Arrange
            var ticketRepository = new TicketRepository();
            var ticketService = new TicketService(ticketRepository);

            var user = new User
            {
                Id = 3,
                Name = "Korisnik",
                Surname = "Korisnik22222",
                Address = "Zinke Kunc 23322",
                Phone = "0955352778",
                Username = "korisnik2",
                Password = "$11$UM5wW8H0U3FlnIjsf1.IqePTO7pLBW7DLWjcrKuz2dg9hyqepCwha.m",
                Id_Roles = 1
            };

            // Act
            var tickets = ticketService.GetTicketsByUser(user);

            // Assert
            Assert.NotEmpty(tickets);
        }

        [Fact]
        public void GetTicketsByUser_GivenInvalidUser_ReturnsEmptyListWhenUserIsNull()
        {
            // Arrange
            var ticketRepository = new TicketRepository();
            var ticketService = new TicketService(ticketRepository);

            User user = new();

            // Act
            var tickets = ticketService.GetTicketsByUser(user);

            // Assert
            Assert.Empty(tickets);
        }

        [Fact]
        public void GetTicketsByUser_GivenUserWithoutTickets_ReturnsEmptyList()
        {
            // Arrange
            var ticketRepository = new TicketRepository();
            var ticketService = new TicketService(ticketRepository);

            var user = new User
            {
                Id = 1,
                Name = "Korisnik",
                Surname = "Korisnik22222",
                Address = "Zinke Kunc 23322",
                Phone = "0955352778",
                Username = "korisnik2",
                Password = "$11$UM5wW8H0U3FlnIjsf1.IqePTO7pLBW7DLWjcrKuz2dg9hyqepCwha.m",
                Id_Roles = 1
            };

            // Act
            var tickets = ticketService.GetTicketsByUser(user);

            // Assert
            Assert.Empty(tickets);
        }

        [Fact]
        public void GetTicketsByUser_GivenInvalidUser_ReturnsEmptyListWhenUserDoesNotExist()
        {
            // Arrange
            var ticketRepository = new TicketRepository();
            var ticketService = new TicketService(ticketRepository);

            var user = new User
            {
                Id = 9999,
                Name = "Korisnik",
                Surname = "Korisnik22222",
                Address = "Zinke Kunc 23322",
                Phone = "0955352778",
                Username = "korisnik2",
                Password = "$11$UM5wW8H0U3FlnIjsf1.IqePTO7pLBW7DLWjcrKuz2dg9hyqepCwha.m",
                Id_Roles = 1
            };

            // Act
            var tickets = ticketService.GetTicketsByUser(user);

            // Assert
            Assert.Empty(tickets);
        }
    }
}
