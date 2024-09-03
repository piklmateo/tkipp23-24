using BuisnessLayer;
using BuisnessLayer.Services;
using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManager_IntegrationTests
{
    public class UserService_IntegrationTests
    {

        /*
        
        [Fact]
        public void RegisterUser_ReturnsTrueOnSuccess()
        {
            var userRepository = new UserRepository();
            var userService = new UserService(userRepository);

            var user = new User
            {
                Id = 31,
                Name = "Korisnik",
                Surname = "Korisnik2222211111",
                Address = "Zinke Kunc 23322",
                Phone = "0955352778",
                Username = "korisnik21211111222222222222222",
                Password = "$11$UM5wW8H0U3FlnIjsf1.IqePTO7pLBW7DLWjcrKuz2dg9hyqepCwha.m",
                Id_Roles = 1
            };

            // Act
            var result = userService.RegisterUser(user);

            // Assert
            Assert.True(result);
        }

        
        [Fact]
        public void RegisterAndRemoveUser_ReturnsTrueOnSuccess()
        {
            var userRepository = new UserRepository();
            var userService = new UserService(userRepository);

            var user = new User
            {
                Id = 3,
                Name = "Korisnik",
                Surname = "Korisnik2222211111",
                Address = "Zinke Kunc 23322",
                Phone = "0955352778",
                Username = "korisnik2121111",
                Password = "$2a$11$9slfEhubmcQ74rZvbJOmIeqkTgk36bLD679AdlVr2TN4DxQuBBE.m",
                Id_Roles = 1
            };

            // Act
            var registerResult = userService.RegisterUser(user);
            // var removeResult = userService.RemoveUser(user);

            // Assert
            Assert.True(registerResult);
            // Assert.True(removeResult > 0);
        }

        */

        [Fact]
        public void GetUserByID_ReturnsResultingUser()
        {
            // Arrange
            var userRepository = new UserRepository();
            var userService = new UserService(userRepository);

            var user = new User
            {
                Id = 3,
                Name = "Korisnik",
                Surname = "Korisnik22222",
                Address = "Zinke Kunc 23322",
                Phone = "0955352778",
                Username = "korisnik2",
                Password = "$11$UM5wW8H0U3FlnIjsf1.IqePTO7pLBW7DLWjcrKuz2dg9hyqepCwha.m",
                Id_Roles = 1
            };

            // Act
            var resultingUser = userService.GetUserById(user);

            // Assert
            Assert.NotNull(resultingUser);
        }

        [Fact]
        public void UpdateUser_ReturnsTrueOnSuccess()
        {
            // Arrange
            var userRepository = new UserRepository();
            var userService = new UserService(userRepository);

            var user = new User
            {
                Id = 3,
                Name = "Korisnik",
                Surname = "Korisnik22222",
                Address = "Zinke Kunc 233221",
                Phone = "0955352778",
                Username = "korisnik2",
                Password = "$2a$11$9slfEhubmcQ74rZvbJOmIeqkTgk36bLD679AdlVr2TN4DxQuBBE.m",
                Id_Roles = 1
            };

            var user_fallback = new User
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
            var result = userService.UpdateUser(user);

            // Assert
            Assert.True(result);

            userService.UpdateUser(user_fallback);
        }

        [Fact]
        public void RegisterUser_ReturnsTrueOnSuccess()
        {
            // Arrange
            var userRepository = new UserRepository();
            var userService = new UserService(userRepository);
            var currentDate = DateTime.Now.ToString("yymmddHHss");

            var user = new User
            {
                Name = "TestUser",
                Surname = "TestSurname",
                Address = "123 Test Ulica",
                Phone = "1234567890",
                Username = $"usr{currentDate}",
                Password = "$2a$11$9slfEhubmcQ74rZvbJOmIeqkTgk36bLD679AdlVr2TN4DxQuBBE.m",
                Id_Roles = 2
            };

            // Act
            var result_create = userService.RegisterUser(user);

            // Assert
            Assert.True(result_create);
        }
    }
}
