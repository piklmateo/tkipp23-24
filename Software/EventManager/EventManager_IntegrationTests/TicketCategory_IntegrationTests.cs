using BuisnessLayer.Services;
using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EventManager_IntegrationTests
{
    public class TicketCategory_IntegrationTests
    {
        [Fact]
        public void GetTicketCategories_GivenValidTicketCategories_ReturnsAllTicketCategories()
        {
            // Arrange
            var ticketCategoryRepository = new TicketCategoryRepository();
            var ticketCategoryService = new TicketCategoryService(ticketCategoryRepository);

            // Act
            var ticketCategories = ticketCategoryService.GetTicketCategories();

            // Assert
            Assert.NotEmpty(ticketCategories);
        }

        [Fact]
        public void GetTicketCategories_GivenValidTicketCategories_ReturnsNotEmptyAndNotNull()
        {
            // Arrange
            var ticketCategoryRepository = new TicketCategoryRepository();
            var ticketCategoryService = new TicketCategoryService(ticketCategoryRepository);

            // Act
            var ticketCategories = ticketCategoryService.GetTicketCategories();

            // Assert
            Assert.NotNull(ticketCategories);
            Assert.NotEmpty(ticketCategories);
        }

        [Fact]
        public void AddTicketCategory_GivenValidTicketCategory_ReturnsTrue()
        {
            // Arrange
            var ticketCategoryRepository = new TicketCategoryRepository();
            var ticketCategoryService = new TicketCategoryService(ticketCategoryRepository);
            var unigueId = Guid.NewGuid().ToString();
            var ticketCategory = new TicketCategory
            {
                Name = "Nova" + unigueId,
                Description = "Nova kategorija"
            };

            // Act
            var result = ticketCategoryService.AddTicketCategory(ticketCategory);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void AddTicketCategory_GivenExistingTicketCategory_ReturnsFalse()
        {
            // Arrange
            var ticketCategoryRepository = new TicketCategoryRepository();
            var ticketCategoryService = new TicketCategoryService(ticketCategoryRepository);
            var ticketCategory = new TicketCategory
            {
                Name = "VIP",
            };

            // Act
            var result = ticketCategoryService.AddTicketCategory(ticketCategory);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void UpdateTicketCategory_GivenValidTicketCategory_ReturnsTrue()
        {
            // Arrange
            var ticketCategoryRepository = new TicketCategoryRepository();
            var ticketCategoryService = new TicketCategoryService(ticketCategoryRepository);
            var uniqueId = Guid.NewGuid().ToString();
            var ticketCategory = new TicketCategory
            {
                Id = 3,
                Name = "VIP" + uniqueId,
            };

            // Act
            var result = ticketCategoryService.UpdateTicketCategory(ticketCategory);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void UpdateTicketCategory_GivenNonExistingTicketCategory_ReturnsFalse()
        {
            // Arrange
            var ticketCategoryRepository = new TicketCategoryRepository();
            var ticketCategoryService = new TicketCategoryService(ticketCategoryRepository);
            var ticketCategory = new TicketCategory
            {
                Id = 100,
                Name = "Best"
            };

            // Act
            var result = ticketCategoryService.UpdateTicketCategory(ticketCategory);

            // Assert
            Assert.False(result);
        }
    }
}
