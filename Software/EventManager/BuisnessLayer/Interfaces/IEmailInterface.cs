﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.Services
{
    public interface IEmailInterface
    {
        void SendEmail(string recipientEmail, string body, string subject);
    }
}
