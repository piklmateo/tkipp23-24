using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BuisnessLayer.Services;
using System.Xml.Linq;
using DataAccessLayer.Iznimke;
using FakeItEasy;

namespace EventManager_IntegrationTests
{
    public class EmailServiceIntegrationTests
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
    }
}
