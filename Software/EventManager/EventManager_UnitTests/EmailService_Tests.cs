using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using BuisnessLayer.Services;
using DataAccessLayer.Iznimke;
using FakeItEasy;

namespace EventManager_UnitTests
{
    public class EmailService_Tests
    {
        [Fact]
        public void SendEmail_GivenValidData_SendsEmailSuccessfully()
        {
            // Arrange
            var smtpClient = A.Fake<ISmtpClient>();
            string recipientEmail = "tmodricdr20@gmail.com";
            string body = "This is test";
            string subject = "Test Email";

            // Act
            EmailService.SendEmail(recipientEmail, body, subject, smtpClient);

            // Assert
            A.CallTo(() => smtpClient.Send(A<MailMessage>.That.Matches(m =>
                m.To[0].Address == recipientEmail &&
                m.Body == body &&
                m.Subject == subject
            ))).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void SendEmail_GivenSmtpException_ThrowsEmailException()
        {
            // Arrange
            var smtpClient = A.Fake<ISmtpClient>();
            A.CallTo(() => smtpClient.Send(A<MailMessage>._)).Throws(new EmailException("Error sending email: "));

            string recipientEmail = "tmodricdr20@gmail.com";
            string body = "This is test";
            string subject = "Test Email";

            // Act and Assert
            var ex = Assert.Throws<EmailException>(() => EmailService.SendEmail(recipientEmail, body, subject, smtpClient));
            Assert.Contains("Error sending email: ", ex.Poruka);
        }

        [Fact]
        public void SendEmail_GivenInvalidEmailAddress_ThrowsFormatException()
        {
            //Arrange
            var smtpClient = A.Fake<ISmtpClient>();
            string recipientEmail = "invalid.email";
            string body = "This is test";
            string subject = "Test Email";

            //Act and Assert
            var ex = Assert.Throws<FormatException>(() => EmailService.SendEmail(recipientEmail, body, subject, smtpClient));
            Assert.Equal("Invalid email address", ex.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void SendEmail_GivenNullOrEmptyEmailAddress_ThrowsArgumentException(string recipientEmail)
        {
            //Arrange
            var smtpClient = A.Fake<ISmtpClient>();
            string body = "This is test";
            string subject = "Test Email";

            //Act and Assert
            var ex = Assert.Throws<ArgumentException>(() => EmailService.SendEmail(recipientEmail, body, subject, smtpClient));
            Assert.Equal("Email adress can't be null or empty", ex.Message);
        }
    }
}
