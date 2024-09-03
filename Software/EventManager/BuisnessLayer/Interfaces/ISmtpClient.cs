using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.Services
{
    public interface ISmtpClient : IDisposable
    {
        void Send(MailMessage message);
        ICredentialsByHost Credentials { get; set; }
        bool EnableSsl { get; set; }
        int Port { get; set; }
    }
}
