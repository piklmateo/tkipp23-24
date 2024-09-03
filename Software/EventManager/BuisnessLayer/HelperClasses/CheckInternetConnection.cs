using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using DataAccessLayer.Iznimke;
using BuisnessLayer.Interfaces;

namespace BuisnessLayer.HelperClasses
{
    public class CheckInternetConnection
    {

        private readonly string _host;
        private readonly int _timeout;
        private readonly IPing _pingService;
        public CheckInternetConnection(IPing pingService, string host = "www.google.com", int timeout = 3000)
        {
            _pingService = pingService ?? throw new ArgumentNullException(nameof(pingService));
            _host = host;
            _timeout = timeout;
        }
        public CheckInternetConnection()
        {
        }
        public bool ConnectionIsAvailable()
        {
            string host = "www.google.com";

            Ping p = new Ping();

            PingReply reply = p.Send(host, 3000);
            if (reply.Status == IPStatus.Success)
            {
                Console.WriteLine("No internet connection");
                return true;
            }

            return false;
        }
        public bool CheckIfConnectionIsAvailable()
        {
            Ping p = new Ping();

            try
            {
                PingReply reply = p.Send(_host, _timeout);
                if (reply.Status == IPStatus.Success)
                {
                    return true;
                }
                else
                {
                    throw new NoInternetConnectionException("No internet connection");
                }
            }
            catch (PingException ex)
            {
                throw new NoInternetConnectionException("No internet connection", ex);
            }
        }
    }
}

