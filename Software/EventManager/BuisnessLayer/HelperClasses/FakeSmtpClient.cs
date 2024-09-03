using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace BuisnessLayer.Services
{
    public class FakeSmtpClient : ISmtpClient
    {
        private readonly SmtpClient _smtpClient;

        public FakeSmtpClient(string host)
        {
            _smtpClient = new SmtpClient(host);
        }

        public ICredentialsByHost Credentials
        {
            get => _smtpClient.Credentials;
            set => _smtpClient.Credentials = value;
        }

        public bool EnableSsl
        {
            get => _smtpClient.EnableSsl;
            set => _smtpClient.EnableSsl = value;
        }

        public int Port
        {
            get => _smtpClient.Port;
            set => _smtpClient.Port = value;
        }

        public void Send(MailMessage message)
        {
            _smtpClient.Send(message);
        }

        public void Dispose() => _smtpClient.Dispose();
    }
}