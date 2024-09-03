using BuisnessLayer.Services;
using DataAccessLayer.Interfaces;
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
    public class TicketCategoryService_Tests
    {
        [Fact]
        public void GetTicketCategories_GivenExistingCategories_ReturnsCorrectList()
        {
            // Arrange
            var ticketCategoryRepository = A.Fake<ITicketCategoryRepository>();
            var service = new TicketCategoryService(ticketCategoryRepository);

            var expectedCategories = new List<TicketCategory>
            {
                new TicketCategory { Id = 1, Name = "Category A", Description = "Description A" },
                new TicketCategory { Id = 2, Name = "Category B", Description = "Description B" }
            };

            A.CallTo(() => ticketCategoryRepository.GetTicketCategories()).Returns(expectedCategories.AsQueryable());

            // Act
            var result = service.GetTicketCategories();

            // Assert
            Assert.Equal(expectedCategories.Count, result.Count);
            Assert.True(expectedCategories.SequenceEqual(result));
        }

        [Fact]
        public void AddTicketCategory_GivenValidTicketCategory_ReturnsTrueOnSuccess()
        {
            // Arrange
            var ticketCategoryRepository = A.Fake<ITicketCategoryRepository>();
            var service = new TicketCategoryService(ticketCategoryRepository);

            var ticketCategoryToAdd = new TicketCategory { Name = "New Category", Description = "New Description" };

            A.CallTo(() => ticketCategoryRepository.Add(ticketCategoryToAdd, true)).Returns(1);

            // Act
            var result = service.AddTicketCategory(ticketCategoryToAdd);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void UpdateTicketCategory_GivenValidTicketCategory_ReturnsTrueOnSuccess()
        {
            // Arrange
            var ticketCategoryRepository = A.Fake<ITicketCategoryRepository>();
            var service = new TicketCategoryService(ticketCategoryRepository);

            var ticketCategoryToUpdate = new TicketCategory { Id = 1, Name = "Updated Category", Description = "Updated Description" };

            A.CallTo(() => ticketCategoryRepository.Update(ticketCategoryToUpdate, true)).Returns(1);

            // Act
            var result = service.UpdateTicketCategory(ticketCategoryToUpdate);

            // Assert
            Assert.True(result);
        }
    }
}
