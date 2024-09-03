using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuisnessLayer.Interfaces;
using BuisnessLayer.Services;
using DataAccessLayer.Iznimke;
using FakeItEasy;

namespace EventManager_UnitTests
{
    public class FacebookService_Tests
    {
        [Fact]
        public void ShareFacebook_GivenBothMessageAndImage_SharesFacebookPostSuccessfully()
        {
            // Arrange
            var fakeFacebookClient = A.Fake<IFacebookClient>();
            var facebookService = new FacebookService(fakeFacebookClient);
            string message = "Test message";
            string image = "http://testimage.com/image.jpg";

            // Act
            facebookService.ShareFacebook(message, image);

            // Assert
            A.CallTo(() => fakeFacebookClient.Post("/me/photos", A<Dictionary<string, object>>.That.Matches(p =>
                (string)p["message"] == message && (string)p["url"] == image)))
                .MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void ShareFacebook_GivenFacebookException_ThrowsFacebookException()
        {
            // Arrange
            var fakeFacebookClient = A.Fake<IFacebookClient>();
            var facebookService = new FacebookService(fakeFacebookClient);
            string message = "Test message";
            string image = "http://testimage.com/image.jpg";

            var testExceptionMessage = "Test exception";
            A.CallTo(() => fakeFacebookClient.Post(A<string>.Ignored, A<IDictionary<string, object>>.Ignored))
                .Throws(new FacebookException(testExceptionMessage));

            // Act and Assert
            var exception = Assert.Throws<FacebookException>(() => facebookService.ShareFacebook(message, image));
            Assert.Contains("Error sending Facebook post: ", exception.Poruka);
        }

        [Theory]
        [InlineData("", "/me/feed")]
        [InlineData(null, "/me/feed")]
        public void ShareFacebook_GivenImageEmptyOrNull_ShareFacebookOnFeed(string image, string expectedEndpoint)
        {
            // Arrange
            var fakeFacebookClient = A.Fake<IFacebookClient>();
            var facebookService = new FacebookService(fakeFacebookClient);

            string message = "Test message";

            // Act
            facebookService.ShareFacebook(message, image);

            // Assert
            A.CallTo(() => fakeFacebookClient.Post(expectedEndpoint, A<Dictionary<string, object>>.Ignored))
                .MustHaveHappenedOnceExactly();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ShareFacebook_GivenMessageIsNullOrEmpty_ThrowsFacebookException(string message)
        {
            // Arrange
            var fakeFacebookClient = A.Fake<IFacebookClient>();
            var facebookService = new FacebookService(fakeFacebookClient);
            string image = "http://testimage.com/image.jpg";

            // Act and Assert
            var exception = Assert.Throws<FacebookException>(() => facebookService.ShareFacebook(message, image));
            Assert.Contains("Message can't be null or empty", exception.Poruka);
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("", "")]
        [InlineData(null, "")]
        [InlineData("", null)]
        public void ShareFacebook_GivenNullOrEmptyMessageAndImageCombination_ThrowsFacebookException(string message, string image)
        {
            // Arrange
            var fakeFacebookClient = A.Fake<IFacebookClient>();
            var facebookService = new FacebookService(fakeFacebookClient);

            // Act and Assert
            var exception = Assert.Throws<FacebookException>(() => facebookService.ShareFacebook(message, image));
            Assert.Equal("Message can't be null or empty", exception.Poruka);
        }

        [Fact]
        public void Constructor_GivenFacebookService_ValidFacebookClientProperties()
        {
            // Arrange
            var fakeFacebookClient = A.Fake<IFacebookClient>();

            // Act
            var facebookService = new FacebookService(fakeFacebookClient);

            // Assert
            Assert.Equal("596681999284443", fakeFacebookClient.AppId);
            Assert.Equal("812d3af8350a55ed52608e2427103ff7", fakeFacebookClient.AppSecret);
            Assert.Equal("EAAIerdqceNsBOymZCwpz2sN5gO5dkdSBrUkHTrgfD4T66iZCs4Pyv0ZAKVpU8bE9TZBf7gK01DKuVv2htZCmzSG2Ex7s6UYujGpO7ubhVtwvKirY7SA22sTmnOM2P9AlslgCDfhowzXu99AT3FlK0U2R7F5XG1eHFtpfOLzBR0At8kY88E6Vky56M4ZBhe5tgmOSYblZAsZD", fakeFacebookClient.AccessToken);
        }
    }
}
