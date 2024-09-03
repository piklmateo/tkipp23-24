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
    public class OrganizerService_IntegrationTests
    {
        [Fact]
        public void GetOrganizers_GivenExistingOrganizers_ReturnsListOfOrganizers()
        {
            // Arrange
            var repo = new OrganizerRepository();
            var service = new OrganizerService(repo);

            // Act
            var result = service.GetOrganizers();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<Organizer>>(result);
        }

        [Fact]
        public void GetOrganizers_GivenExistingOrganizers_ReturnsListOfOrganizersNotEmpty()
        {
            // Arrange
            var repo = new OrganizerRepository();
            var service = new OrganizerService(repo);

            // Act
            var result = service.GetOrganizers();

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void AddOrganizer_GivenValidOrganizer_ReturnsTrue()
        {
            // Arrange
            var repo = new OrganizerRepository();
            var service = new OrganizerService(repo);
            var uniqueId = Guid.NewGuid().ToString();
            var organizer = new Organizer
            {
                Name = "Test Organizer" + uniqueId,
            };

            // Act
            var result = service.AddOrganizer(organizer);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void AddOrganizer_GivenExistingOrganizer_ReturnsFalse()
        {
            // Arrange
            var repo = new OrganizerRepository();
            var service = new OrganizerService(repo);
            var organizer = new Organizer
            {
                Name = "FIFA",
            };

            // Act
            var result = service.AddOrganizer(organizer);

            // Assert
            Assert.False(result);
        }  
    }
}
