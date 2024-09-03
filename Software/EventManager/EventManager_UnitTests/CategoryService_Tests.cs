using BuisnessLayer;
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
    public class CategoryService_Tests
    {

        [Fact]
        public void GetEventCategories_GivenValidCategories_ReturnsListOfEventCategories()
        {
            // Arrange
            var fakeRepository = A.Fake<ICategoryRepository>();
            var categoryService = new CategoryService(fakeRepository);
            var expectedCategories = new List<EventCategory>
            {
                new EventCategory { Id = 1, Name = "Music" },
                new EventCategory { Id = 2, Name = "Art" }
            };
            A.CallTo(() => fakeRepository.GetAllCategories()).Returns(expectedCategories.AsQueryable());

            // Act
            var result = categoryService.GetEventCategories();

            // Assert
            Assert.Equal(expectedCategories.Count, result.Count);
            Assert.Equal(expectedCategories, result);
        }

        [Fact]
        public void AddCategory_GivenValidCategory_ReturnsTrueWhenCategoryIsAddedSuccessfully()
        {
            // Arrange
            var fakeRepository = A.Fake<ICategoryRepository>();
            var categoryService = new CategoryService(fakeRepository);
            var newCategory = new EventCategory { Id = 3, Name = "Sports" };
            A.CallTo(() => fakeRepository.Add(newCategory, true)).Returns(1);

            // Act
            var result = categoryService.AddCategory(newCategory);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void AddCategory_GivenInvalidCategory_ReturnsFalseWhenCategoryIsNotAdded()
        {
            // Arrange
            var fakeRepository = A.Fake<ICategoryRepository>();
            var categoryService = new CategoryService(fakeRepository);
            var newCategory = new EventCategory { Id = 3, Name = "Sports" };
            A.CallTo(() => fakeRepository.Add(newCategory, true)).Returns(0);

            // Act
            var result = categoryService.AddCategory(newCategory);

            // Assert
            Assert.False(result);
        }
    }
}
