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
    public class OrganizerService_Tests
    {
        [Fact]
        public void GetOrganizers_GivenExistingOrganizers_ReturnsListOfOrganizers()
        {
            // Arrange
            var fakeUserRepository = A.Fake<IOrganizerRepository>();
            var organizers = new List<Organizer>
            {
                new Organizer { Id = 1, Name = "Organizer 1" },
                new Organizer { Id = 2, Name = "Organizer 2" }
            };

            A.CallTo(() => fakeUserRepository.GetAll()).Returns(organizers.AsQueryable());

            var service = new OrganizerService(fakeUserRepository);

            // Act
            var result = service.GetOrganizers();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void GetOrganizers_GivenNoOrganizers_ReturnsEmptyList()
        {
            // Arrange
            var fakeUserRepository = A.Fake<IOrganizerRepository>();
            var organizers = new List<Organizer>();

            A.CallTo(() => fakeUserRepository.GetAll()).Returns(organizers.AsQueryable());

            var service = new OrganizerService(fakeUserRepository);

            // Act
            var result = service.GetOrganizers();

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void AddOrganizer_GivenValidOrganizer_ReturnsTrueOnSuccess()
        {
            // Arrange
            var fakeUserRepository = A.Fake<IOrganizerRepository>();
            var organizer = new Organizer { Name = "New Organizer" };

            A.CallTo(() => fakeUserRepository.Add(organizer, true)).Returns(1);

            var service = new OrganizerService(fakeUserRepository);

            // Act
            var result = service.AddOrganizer(organizer);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void AddOrganizer_GivenInvalidOrganizer_ReturnsFalseOnFail()
        {
            // Arrange
            var fakeUserRepository = A.Fake<IOrganizerRepository>();
            var organizer = new Organizer { Name = "New Organizer" };

            A.CallTo(() => fakeUserRepository.Add(organizer, true)).Returns(0);

            var service = new OrganizerService(fakeUserRepository);

            // Act
            var result = service.AddOrganizer(organizer);

            // Assert
            Assert.False(result);
        }
    }
}
