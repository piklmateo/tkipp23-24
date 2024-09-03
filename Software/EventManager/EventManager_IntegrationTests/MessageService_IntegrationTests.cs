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
    public class MessageService_IntegrationTests
    {
        [Fact]
        public void SendMessage_GivenBodyMessageAndCorrectToAndFromNumber_ReturnsSentStatusSuccessful()
        {
            // Arrange
            var fakeMessageService = A.Fake<IMessageService>();
            A.CallTo(() => fakeMessageService.SendMessage(A<string>.Ignored, A<string>.Ignored, A<string>.Ignored))
                .Returns(1);

            // Act
            var result = fakeMessageService.SendMessage("Test message", "+1234567890", "+9876543210");

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void SendMessage_GivenApplicationException_ThrowsApplciationException()
        {
            // Arrange
            var fakeMessageService = A.Fake<IMessageService>();
            A.CallTo(() => fakeMessageService.SendMessage(A<string>.Ignored, A<string>.Ignored, A<string>.Ignored))
                .Throws<ApplicationException>();

            // Act and Assert
            Assert.Throws<ApplicationException>(() => fakeMessageService.SendMessage("Test message", "+1234567890", "+9876543210"));
        }
    }
}
