using BuisnessLayer;
using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EventManager_UnitTests
{
    public class VenueService_Tests
    {
        private List<Venue> CreateVenuesList()
        {
            return new List<Venue>
            {
                new Venue { Id = 1, Name = "Venue 1", Description = "Description 1", Latitude = 1, Longitude = 1 },
                new Venue { Id = 2, Name = "Venue 2", Description = "Description 2", Latitude = 2, Longitude = 2 }
            };
        }

        private Venue CreateDefaultVenue()
        {
            return new Venue { Name = "Test Venue", Description = "Test Description", Latitude = 1, Longitude = 1 };
        }

        [Fact]
        public void GetVenues_GivenVenuesInRepository_ReturnsVenues()
        {
            // Arrange
            var venueRepository = A.Fake<IVenueRepository>();
            var venueService = new VenueService(venueRepository);
            var venues = CreateVenuesList();
            A.CallTo(() => venueRepository.GetAllVenues()).Returns(venues.AsQueryable());

            // Act
            var result = venueService.GetVenues();

            // Assert
            Assert.Equal(venues, result);
        }

        [Fact]
        public void GetVenues_GivenVenuesInRepository_IsNotNull()
        {
            // Arrange
            var venueRepository = A.Fake<IVenueRepository>();
            var venueService = new VenueService(venueRepository);
            var venues = CreateVenuesList();
            A.CallTo(() => venueRepository.GetAllVenues()).Returns(venues.AsQueryable());

            // Act
            var result = venueService.GetVenues();

            // Assert
            Assert.NotNull(result);
        }         

        [Fact]
        public void GetCloseVenues_GivenCloseVenuesInRepository_ReturnsCloseVenues()
        {
            // Arrange
            var venueRepository = A.Fake<IVenueRepository>();
            var venueService = new VenueService(venueRepository);
            var venues = CreateVenuesList();
            A.CallTo(() => venueRepository.GetAllVenues()).Returns(venues.AsQueryable());

            // Act
            var result = venueService.GetCloseVenues(1.1, 1.1);

            // Assert
            Assert.Single(result);
            Assert.Equal(1, result[0].Id);
        }

        [Fact]
        public void GetCloseVenues_GivenCloseVenuesInRepository_IsNotNull()
        {
            // Arrange
            var venueRepository = A.Fake<IVenueRepository>();
            var venueService = new VenueService(venueRepository);
            var venues = CreateVenuesList();
            A.CallTo(() => venueRepository.GetAllVenues()).Returns(venues.AsQueryable());

            // Act
            var result = venueService.GetCloseVenues(1.1, 1.1);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void AddVenue_GivenValidVenue_SuccessfullyAdded_ReturnsTrue()
        {
            // Arrange
            var venueRepository = A.Fake<IVenueRepository>();
            var venueService = new VenueService(venueRepository);
            var venue = CreateDefaultVenue();
            A.CallTo(() => venueRepository.Add(venue, true)).Returns(1);

            // Act
            bool result = venueService.AddVenue(venue);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void AddVenue_GivenValidVenue_FailedToAdd_ReturnsFalse()
        {
            // Arrange
            var venueRepository = A.Fake<IVenueRepository>();
            var venueService = new VenueService(venueRepository);
            var venue = CreateDefaultVenue();
            A.CallTo(() => venueRepository.Add(venue, true)).Returns(0);

            // Act
            bool result = venueService.AddVenue(venue);

            // Assert
            Assert.False(result);
        }
    }
}
