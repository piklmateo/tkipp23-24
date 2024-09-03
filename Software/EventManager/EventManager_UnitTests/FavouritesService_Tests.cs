using BuisnessLayer.Services;
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
    public class FavouritesService_Tests
    {
        [Fact]
        public void GetAll_GivenValidUser_ReturnsFavouritesForUser()
        {
            // Arrange
            var fakeRepo = A.Fake<IFavouritesRepository>();
            var user = new User { Id = 1, Name = "Test User" };
            var favouritesList = new List<Favourites>
            {
                new Favourites { Id = 1, Id_Users = user.Id, Id_Events = 1 },
                new Favourites { Id = 2, Id_Users = user.Id, Id_Events = 2 }
            }.AsQueryable();

            A.CallTo(() => fakeRepo.GetAll(user)).Returns(favouritesList);
            var service = new FavouritesService(fakeRepo);

            // Act
            var result = service.GetAll(user);

            // Assert
            Assert.Equal(favouritesList.Count(), result.Count());
        }

        [Fact]
        public void GetFavouriteByEventId_GivenValidEventId_ReturnsSpecificFavourite()
        {
            // Arrange
            var fakeRepo = A.Fake<IFavouritesRepository>();
            var user = new User { Id = 1, Name = "Test User" };
            var favourites = new Favourites { Id = 1, Id_Users = user.Id, Id_Events = 1 };

            A.CallTo(() => fakeRepo.GetFavouriteByEventId(user, 1)).Returns(new List<Favourites> { favourites }.AsQueryable());
            var service = new FavouritesService(fakeRepo);

            // Act
            var result = service.GetFavouriteByEventId(user, 1);

            // Assert
            Assert.Single(result);
            Assert.Equal(favourites.Id, result.First().Id);
        }

        [Fact]
        public void Add_GivenValidFavourite_ReturnsTrueOnSuccess()
        {
            // Arrange
            var fakeRepo = A.Fake<IFavouritesRepository>();
            var favourite = new Favourites { Id = 1, Id_Users = 1, Id_Events = 1 };

            A.CallTo(() => fakeRepo.Add(favourite, true)).Returns(1);
            var service = new FavouritesService(fakeRepo);

            // Act
            var result = service.Add(favourite);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Add_GivenInvalidFavourite_ReturnsFalseOnFailure()
        {
            // Arrange
            var fakeRepo = A.Fake<IFavouritesRepository>();
            var favourite = new Favourites { Id = 1, Id_Users = 1, Id_Events = 1 };

            A.CallTo(() => fakeRepo.Add(favourite, true)).Returns(0);
            var service = new FavouritesService(fakeRepo);

            // Act
            var result = service.Add(favourite);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Remove_GivenValidFavourite_ReturnsTrueOnSuccess()
        {
            // Arrange
            var fakeRepo = A.Fake<IFavouritesRepository>();
            var favourite = new Favourites { Id = 1, Id_Users = 1, Id_Events = 1 };

            A.CallTo(() => fakeRepo.Remove(favourite, true)).Returns(1);
            var service = new FavouritesService(fakeRepo);

            // Act
            var result = service.Remove(favourite);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Remove_GivenInvalidFavourite_ReturnsFalseOnFailure()
        {
            // Arrange
            var fakeRepo = A.Fake<IFavouritesRepository>();
            var favourite = new Favourites { Id = 1, Id_Users = 1, Id_Events = 1 };

            A.CallTo(() => fakeRepo.Remove(favourite, true)).Returns(0);
            var service = new FavouritesService(fakeRepo);

            // Act
            var result = service.Remove(favourite);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Remove_GivenNullFavourite_ReturnsFalseIfFavouriteIsNull()
        {
            // Arrange
            var fakeRepo = A.Fake<IFavouritesRepository>();
            var service = new FavouritesService(fakeRepo);

            // Act
            var result = service.Remove(null);

            // Assert
            Assert.False(result);
        }
    }
}
