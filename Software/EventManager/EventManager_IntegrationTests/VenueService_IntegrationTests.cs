using BuisnessLayer;
using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManager_IntegrationTests
{
    public class VenueService_IntegrationTests
    {
        [Fact]
        public void GetVenues_GivenDatabaseVenuesTableIsNotEmpty_ReturnsListOfVenues()
        {
            // Arrange
            var repo = new VenueRepository();
            var service = new VenueService(repo);

            // Act
            var result = service.GetVenues();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<Venue>>(result);
        }

        [Fact]
        public void GetVenues_GivenDatabaseVenuesTableIsNotEmpty_ReturnsListOfVenuesNotEmpty()
        {
            // Arrange
            var repo = new VenueRepository();
            var service = new VenueService(repo);

            // Act
            var result = service.GetVenues();

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void AddVenue_GivenValidVenue_ReturnsTrue()
        {
            // Arrange
            var repo = new VenueRepository();
            var service = new VenueService(repo);
            var uniqueId = Guid.NewGuid().ToString();
            var venue = new Venue
            {
                Name = "Test Venue" + uniqueId,
                Description = "Test Description",
                Latitude = 1,
                Longitude = 2
            };

            // Act
            var result = service.AddVenue(venue);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void AddVenue_GivenExistingVenue_ReturnsFalse()
        {
            // Arrange
            var repo = new VenueRepository();
            var service = new VenueService(repo);
            var venue = new Venue
            {
                Name = "CZK",
                Description = "Test Description",
                Latitude = 1,
                Longitude = 2
            };

            // Act
            var result = service.AddVenue(venue);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GetCloseVenues_GivenValidLatitudeAndLongitude_ReturnsListOfVenues()
        {
            // Arrange
            var repo = new VenueRepository();
            var service = new VenueService(repo);

            // Act
            var result = service.GetCloseVenues(1, 1);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<Venue>>(result);
        }

        
        [Fact]
        public void GetCloseVenues_GivenValidLatitudeAndLongitude_ReturnsListOfVenuesNotEmpty()
        {
            // Arrange
            var repo = new VenueRepository();
            var service = new VenueService(repo);

            // Act
            var result = service.GetCloseVenues(100, 100);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GetCloseVenues_GivenInvalidLongitudeAndLatitude_ReturnsEmptyList()
        {
            // Arrange
            var repo = new VenueRepository();
            var service = new VenueService(repo);

            // Act
            var result = service.GetCloseVenues(1000, 1000);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }
    }
}
