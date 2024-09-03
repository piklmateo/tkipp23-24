using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuisnessLayer.Services;

namespace BuisnessLayer.Interfaces
{
    public class VonageMessageService : IMessageService
    {
        readonly MessageService messageService = new MessageService();
        public int SendMessage(string bodyMessage, string toNumber, string fromNumber)
        {
            return messageService.SendMessage(bodyMessage, toNumber, fromNumber);
        }
    }
}
