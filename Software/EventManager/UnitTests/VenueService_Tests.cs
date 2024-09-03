using BuisnessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EventManager_UnitTests
{
    public class VenueService_Tests
    {
        // write a unit test for the GetVenues method
        [Fact]
        public void GetVenues_ReturnsVenues()
        {
            // Arrange
            var venueService = new VenueService();

            // Act
            var venues = venueService.GetVenues();

            // Assert
            Assert.NotNull(venues);
            Assert.NotEmpty(venues);
        }

    }
}
