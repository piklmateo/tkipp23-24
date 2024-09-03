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
    public class CategoryService_IntegrationTests
    {
        [Fact]
        public void GetEventCategories_GivenCategoriesInRepository_ReturnsAllCategories()
        {
            // Arrange
            var categoryRepository = new CategoryRepository();
            var categoryService = new CategoryService(categoryRepository);

            // Act
            var categories = categoryService.GetEventCategories();

            // Assert
            Assert.NotEmpty(categories);
        }

        [Fact]
        public void GetEventCategories_GivenCategoriesInRepository_ReturnsNotEmptyAndNotNull()
        {
            // Arrange
            var categoryRepository = new CategoryRepository();
            var categoryService = new CategoryService(categoryRepository);

            // Act
            var categories = categoryService.GetEventCategories();

            // Assert
            Assert.NotNull(categories);
            Assert.NotEmpty(categories);
        }

        [Fact]
        public void AddCategory_GivenUniqueCategoryName_ReturnsTrueWhenCategoryAdded()
        {
            //Arrange
            var categoryRepository = new CategoryRepository();
            var categoryService = new CategoryService(categoryRepository);
            var uniqueId = Guid.NewGuid().ToString();
            var newCategory = new EventCategory
            {
                Name = "TestCategory" + uniqueId,
            };

            // Act
            var result = categoryService.AddCategory(newCategory);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void AddCategory_GivenExistingCategoryName_ReturnsFalseWhenAddingExistingCategory()
        {
            //Arrange
            var categoryRepository = new CategoryRepository();
            var categoryService = new CategoryService(categoryRepository);
            var newCategory = new EventCategory
            {
                Name = "Festival",
            };

            // Act
            var result = categoryService.AddCategory(newCategory);

            // Assert
            Assert.False(result);
        }

    }
}
