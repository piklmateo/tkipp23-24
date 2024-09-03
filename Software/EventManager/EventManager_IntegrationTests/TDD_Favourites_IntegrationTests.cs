using BuisnessLayer;
using BuisnessLayer.Services;
using DataAccessLayer.Exceptions;
using DataAccessLayer.Iznimke;
using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManager_IntegrationTests
{
    public class TDD_Favourites_IntegrationTests
    {
        [Fact]
        public void GetAll_GivenValidUser_ReturnsNonEmptyList()
        {
            // Arrange
            var favouritesRepository = new FavouritesRepository();
            var favouritesService = new FavouritesService(favouritesRepository);
            var user = new User
            {
                Id = 3,
                Name = "Korisnik",
                Surname = "Korisnik22222",
                Address = "Zinke Kunc 23322",
                Phone = "0955352778",
                Username = "korisnik2",
                Password = "$2a$11$9slfEhubmcQ74rZvbJOmIeqkTgk36bLD679AdlVr2TN4DxQuBBE.m",
                Id_Roles = 1
            };

            // Act
            var result = favouritesService.GetAll(user);

            // Assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GetAll_GivenInvalidUser_ReturnsEmptyList()
        {
            // Arrange
            var favouritesRepository = new FavouritesRepository();
            var favouritesService = new FavouritesService(favouritesRepository);
            var user = new User
            {
                Name = "Korisnik",
                Surname = "Korisnik22222",
                Address = "Zinke Kunc 23322",
                Phone = "0955352778",
                Username = "korisnik2",
                Password = "$2a$11$9slfEhubmcQ74rZvbJOmIeqkTgk36bLD679AdlVr2TN4DxQuBBE.m",
                Id_Roles = 1
            };

            // Act
            var result = favouritesService.GetAll(user);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void AddFavourite_GivenValidFavourite_ReturnsTrue()
        {
            // Arrange

            var favouritesRepository = new FavouritesRepository();
            var favouritesService = new FavouritesService(favouritesRepository);
            var newFavourite = new Favourites
            {
                Id_Events = 22,
                Id_Users = 3
            };

            // Act
            var result = favouritesService.Add(newFavourite);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void AddFavourite_GivenInvalidFavourite_ThrowsFavouritesException()
        {
            // Arrange
            var favouritesRepository = new FavouritesRepository();
            var favouritesService = new FavouritesService(favouritesRepository);
            var newFavourite = new Favourites
            {
                Id_Events = 999,
                Id_Users = 999
            };

            // Assert
            Assert.Throws<FavouritesException>(() => favouritesService.Add(newFavourite));
        }

        [Fact]
        public void RemoveFavourite_GivenValidFavourite_ReturnsTrue()
        {
            // Arrange
            var favouritesRepository = new FavouritesRepository();
            var favouritesService = new FavouritesService(favouritesRepository);
            var user = new User
            {
                Id = 3,
                Name = "Korisnik",
                Surname = "Korisnik22222",
                Address = "Zinke Kunc 23322",
                Phone = "0955352778",
                Username = "korisnik2",
                Password = "$2a$11$9slfEhubmcQ74rZvbJOmIeqkTgk36bLD679AdlVr2TN4DxQuBBE.m",
                Id_Roles = 1
            };

            var newFavourite = favouritesService.GetFavouriteByEventId(user, 22).FirstOrDefault();

            // Act
            var result = favouritesService.Remove(newFavourite);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void RemoveFavourite_GivenInvalidFavourite_ThrowsFavouritesException()
        {
            // Arrange
            var favouritesRepository = new FavouritesRepository();
            var favouritesService = new FavouritesService(favouritesRepository);
            var newFavourite = new Favourites
            {
                Id_Events = -1,
                Id_Users = -1
            };

            // Assert
            Assert.Throws<FavouritesException>(() => favouritesService.Remove(newFavourite));
        }
    }
}