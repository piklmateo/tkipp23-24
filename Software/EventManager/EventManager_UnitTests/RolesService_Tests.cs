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
    public class RolesService_Tests
    {
        [Fact]
        public void GetRoles_GivenNoRoles_ReturnsEmptyList()
        {
            // Arrange
            var roleRepository = A.Fake<IRoleRepository>();
            var roleService = new RoleService(roleRepository);
            var roles = new List<Role>();
            A.CallTo(() => roleRepository.GetAll()).Returns(roles.AsQueryable());

            // Act
            var result = roleService.GetRoles();

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void GetRoles_GivenExistingRoles_ReturnsRoles()
        {
            // Arrange
            var roleRepository = A.Fake<IRoleRepository>();
            var roleService = new RoleService(roleRepository);
            var roles = new List<Role> { new Role { Id = 1 }, new Role { Id = 2 } };
            A.CallTo(() => roleRepository.GetAll()).Returns(roles.AsQueryable());

            // Act
            var result = roleService.GetRoles();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal(1, result[0].Id);
            Assert.Equal(2, result[1].Id);
        }

        [Fact]
        public void UpdateRole_GivenValidRole_ReturnsTrueOnSuccess()
        {
            // Arrange
            var roleRepository = A.Fake<IRoleRepository>();
            var roleService = new RoleService(roleRepository);
            var role = new Role();
            A.CallTo(() => roleRepository.Update(role, true)).Returns(1);

            // Act
            var result = roleService.Update(role);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void UpdateRole_GivenInvalidRole_ReturnsFalseOnFail()
        {
            // Arrange
            var roleRepository = A.Fake<IRoleRepository>();
            var roleService = new RoleService(roleRepository);
            var role = new Role();
            A.CallTo(() => roleRepository.Update(role, true)).Returns(0);

            // Act
            var result = roleService.Update(role);

            // Assert
            Assert.False(result);
        }
    }
}
