﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.Interfaces
{
    public interface IMessageService
    {
        int SendMessage(string bodyMessage, string toNumber, string fromNumber);
    }
}
