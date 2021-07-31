using EmailSender.Interface;
using EmailSender.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailSender.Controllers
{
    public class EmailSenderController : Controller
    {
        IEmailSender _emailSender;
        public EmailSenderController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }
        [HttpPost, Route("SendEmail")]
        public void SendEmailAsync(string recipientEmail, string recipientFirstName, string Link)
        {
            try
            {
                _emailSender.SendEmailAsync(recipientEmail, recipientFirstName, Link);
            }

            catch (Exception ex)
            {
                BadRequest(ex?.InnerException?.InnerException?.Message ?? ex?.InnerException?.Message ?? ex?.Message);

            }
        }
    }
}
