using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataAccessLayer.Repositories;
using Vonage.Messaging;
using Vonage.Request;
using Vonage;
using DataAccessLayer.Iznimke;
using Vonage.Common;
using System.Text.RegularExpressions;

namespace BuisnessLayer.Services
{
    ///<author>Toni Leo Modrić Dragičević</author>
    public class MessageService
    {
        public int SendMessage(string bodyMessage, string toNumber, string fromNumber)
        {
            ValidateInputs(bodyMessage, toNumber, fromNumber);

            try
            {
                var credentials = Credentials.FromApiKeyAndSecret("0e805da4", "uHaFdo0pX1MXZuoi");
                var vonageClient = new VonageClient(credentials);

                var smsRequest = new SendSmsRequest
                {
                    To = toNumber,
                    From = fromNumber,
                    Text = bodyMessage,
                };

                var response = vonageClient.SmsClient.SendAnSms(smsRequest);

                return int.Parse(response.Messages[0].Status);
            }
            catch (MessageException ex)
            {
                throw new MessageException("An error occurred while sending a message." + ex);
            }
        }
        private static void ValidateInputs(string bodyMessage, string toNumber, string fromNumber)
        {
            if (string.IsNullOrEmpty(bodyMessage))
            {
                throw new MessageException("Message body can't be null or empty");
            }

            if (string.IsNullOrEmpty(toNumber))
            {
                throw new MessageException("Number that this message is sent to can't be null or empty");
            }

            if (string.IsNullOrEmpty(fromNumber))
            {
                throw new MessageException("Number that this message is sent from can't be null or empty");
            }

            if (!IsValidPhoneNumber(toNumber))
            {
                throw new MessageException("Number that this message is sent to is invalid");
            }

            if (!IsValidPhoneNumber(fromNumber))
            {
                throw new MessageException("Number that this message is sent from is invalid");
            }
        }

        private static bool IsValidPhoneNumber(string phoneNumber)
        {
            phoneNumber = Regex.Replace(phoneNumber, "[^0-9+]", "");

            return Regex.IsMatch(phoneNumber, @"^(?:\+385)?\d{8}$");
        }
    }
}
