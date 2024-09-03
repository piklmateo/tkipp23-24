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
    public class RoleService_IntegrationTests
    {
        [Fact]
        public void GetRoles_GivenExistingRoles_ReturnsAllRoles()
        {
            // Arrange
            var roleRepository = new RolesRepository();
            var roleService = new RoleService(roleRepository);

            // Act
            var roles = roleService.GetRoles();

            // Assert
            Assert.Equal(2, roles.Count);
        }

        [Fact]
        public void GetRoles_GivenExistingRoles_ReturnsNotEmptyAndNotNull()
        {
            // Arrange
            var roleRepository = new RolesRepository();
            var roleService = new RoleService(roleRepository);

            // Act
            var roles = roleService.GetRoles();

            // Assert
            Assert.NotNull(roles);
            Assert.NotEmpty(roles);
        }

        [Fact]
        public void UpdateRole_GivenValidRole_ReturnsTrue()
        {
            // Arrange
            var roleRepository = new RolesRepository();
            var roleService = new RoleService(roleRepository);
            var uniqueId = Guid.NewGuid().ToString();
            var role = new Role
            {
                Id = 1,
                Name = "Admin" + uniqueId,
            };

            // Act
            var result = roleService.Update(role);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void UpdateRole_GivenNonExistingRole_ReturnsFalse()
        {
            // Arrange
            var roleRepository = new RolesRepository();
            var roleService = new RoleService(roleRepository);
            var role = new Role
            {
                Id = 109,
                Name = "Admin"
            };

            // Act
            var result = roleService.Update(role);

            // Assert
            Assert.False(result);
        }
    }
}
