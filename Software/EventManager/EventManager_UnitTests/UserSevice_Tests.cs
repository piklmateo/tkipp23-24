using BuisnessLayer;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Iznimke;
using EntitiesLayer.Entities;
using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EventManager_UnitTests
{
    public class UserSevice_Tests
    {
        [Fact]
        public void GetUserById_WhenUserExists_ReturnsUser()
        {
            // Arrange
            var fakeUserRepository = A.Fake<IUserRepository>();
            var userService = new UserService(fakeUserRepository);
            var user = new User { Id = 1 };

            A.CallTo(() => fakeUserRepository.GetById(user)).Returns(user);

            // Act
            var result = userService.GetUserById(user);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(user.Id, result.Id);
        }

        [Fact]
        public void UpdateUser_WhenUserIsUpdated_ReturnsTrue()
        {
            // Arrange
            var fakeUserRepository = A.Fake<IUserRepository>();
            var userService = new UserService(fakeUserRepository);
            var user = new User { Id = 1 };

            // saveChanges je ovaj argument value: true
            A.CallTo(() => fakeUserRepository.Update(user, true)).Returns(1);

            // Act
            var result = userService.UpdateUser(user);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void RegisterUser_WhenUserIsAdded_ReturnsTrue()
        {
            // Arrange
            var fakeUserRepository = A.Fake<IUserRepository>();
            var userService = new UserService(fakeUserRepository);
            var user = new User { Id = 1 };

            A.CallTo(() => fakeUserRepository.Add(user, true)).Returns(1);

            // Act
            var result = userService.RegisterUser(user);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task LoginUser_WhenCredentialsAreCorrect_ReturnsUser()
        {
            // Arrange
            var fakeUserRepository = A.Fake<IUserRepository>();
            var userService = new UserService(fakeUserRepository);
            var user = new User { Id = 1, Username = "testuser", Password = "password" };

            A.CallTo(() => fakeUserRepository.Login("testuser", "password")).Returns(Task.FromResult(user));

            // Act
            var result = await userService.LoginUser("testuser", "password");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(user.Id, result.Id);
        }

        [Fact]
        public async Task LoginUser_WhenCredentialsAreInCorrect_ReturnsUser()
        {
            // Arrange
            var fakeUserRepository = A.Fake<IUserRepository>();
            var userService = new UserService(fakeUserRepository);
            var user = new User { Id = 1, Username = "testuser", Password = "password" };

            A.CallTo(() => fakeUserRepository.Login("testuser", "password")).Returns(Task.FromResult(user));

            // Act
            var result = await userService.LoginUser("testuser1", "password1");

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual(user.Id, result.Id);
        }
    }
}
