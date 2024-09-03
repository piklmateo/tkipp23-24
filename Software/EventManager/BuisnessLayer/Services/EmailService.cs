using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Repositories;
using DataAccessLayer.Iznimke;

namespace BuisnessLayer.Services
{
    ///<author>Toni Leo Modrić Dragičević</author>
    public static class EmailService
    {
        public static void SendEmail(string recipientEmail, string body, string subject, ISmtpClient smtpClient)
        {
            if (!IsValidEmail(recipientEmail))
                throw new FormatException("Invalid email address");

            string senderEmail = "tmodricdr20test@gmail.com";
            string password = "djqj tgqc tpqt shfj";

            try
            {
                using (MailMessage mailMessage = new MailMessage(senderEmail, recipientEmail, subject, body))
                {
                    smtpClient.Port = 587;
                    smtpClient.Credentials = new NetworkCredential(senderEmail, password);
                    smtpClient.EnableSsl = true;

                    smtpClient.Send(mailMessage);
                }
            }
            catch (EmailException ex)
            {
                throw new EmailException("Error sending email: " + ex);
            }
        }
        private static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email adress can't be null or empty");
            }

            try
            {
                var mail = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
