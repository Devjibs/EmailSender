using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailSender.Interface
{
    public interface IEmailSender
    {
        void SendEmailAsync(string recipientEmail, string recipientFirstName, string Link);
    }
}
