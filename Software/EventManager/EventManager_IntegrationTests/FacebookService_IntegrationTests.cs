using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuisnessLayer.Interfaces;
using BuisnessLayer.Services;
using DataAccessLayer.Iznimke;
using FakeItEasy;

namespace EventManager_IntegrationTests
{
    public class FacebookService_IntegrationTests
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
    }
}
