using EmailSender.Interface;
using EmailSender.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using MailKit.Net.Smtp;

namespace EmailSender.Service
{

    public class EmailSenderService : IEmailSender
    {
        private readonly SmtpSettings _smtpSettings;
        public EmailSenderService(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }



        public async void SendEmailAsync(string recipientEmail, string recipientFirstName, string Link)
        {
            Link = @"https://github.com/jibogithub";


            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_smtpSettings.SenderEmail));
            message.To.Add(new MailboxAddress(recipientEmail));
            message.Subject = "How to send email in .Net Core";

            message.Body = new TextPart("html")
            {
                Text = "This is just a walkthrough in sending messages in .net core"
            };



            var client = new SmtpClient();

            await client.ConnectAsync(_smtpSettings.Server, _smtpSettings.Port, true);
            await client.AuthenticateAsync(new NetworkCredential(_smtpSettings.SenderEmail, _smtpSettings.Password));
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
    }
}