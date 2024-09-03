using BuisnessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.HelperClasses
{
    public class PingService : IPing
    {
        public PingReply Send(string host, int timeout)
        {
            Ping p = new Ping();
            return p.Send(host, timeout);
        }
    }
}
