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
    public class MessageService_Tests
    {
        [Fact]
        public void SendMessage_GivenBodyMessageAndCorrectToAndFromNumber_ReturnsSentStatusSuccessful()
        {
            // Arrange
            var fakeMessageService = A.Fake<IMessageService>();
            A.CallTo(() => fakeMessageService.SendMessage(A<string>.Ignored, A<string>.Ignored, A<string>.Ignored))
                .Returns(1);

            // Act
            var result = fakeMessageService.SendMessage("Test message", "+38545678900", "+38565432100");

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
            Assert.Throws<ApplicationException>(() => fakeMessageService.SendMessage("Test message", "+38545678900", "+38565432100"));
        }

        [Fact]
        public void SendMessage_GivenInvalidToNumber_ThrowsMessageException()
        {
            // Arrange
            var messageService = new MessageService();

            // Act and Assert
            Assert.Throws<MessageException>(() => messageService.SendMessage("Test message", "invalid_number", "+38565432100"));
        }

        [Fact]
        public void SendMessage_GivenInvalidFromNumber_ThrowsMessageException()
        {
            // Arrange
            var messageService = new MessageService();

            // Act and Assert
            Assert.Throws<MessageException>(() => messageService.SendMessage("Test message", "+38545678900", "invalid_number"));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void SendMessage_GivenEmptyOrNullToNumber_ThrowsMessageException(string tonumber)
        {
            // Arrange
            var messageService = new MessageService();

            // Act and Assert
            Assert.Throws<MessageException>(() => messageService.SendMessage("Test message", tonumber, "+38565432100"));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void SendMessage_GivenEmptyOrNullFromNumber_ThrowsMessageException(string fromnumber)
        {
            // Arrange
            var messageService = new MessageService();

            // Act and Assert
            Assert.Throws<MessageException>(() => messageService.SendMessage("Test message", "+38545678900", fromnumber));
        }

        [Fact]
        public void SendMessage_GivenEmptyBody_ThrowsMessageException()
        {
            // Arrange
            var messageService = new MessageService();

            // Act and Assert
            Assert.Throws<MessageException>(() => messageService.SendMessage("", "+38545678900", "+38565432100"));
        }
    }
}
