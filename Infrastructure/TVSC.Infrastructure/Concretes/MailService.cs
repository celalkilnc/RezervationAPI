using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using TVSC.Application.Service;

namespace TVSC.Infrastructure.Concretes
{
    public class MailService : IMailService
    {
        readonly IConfiguration _configuration;
        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendMailAsync(string to, string subject, string body, bool isBodyHtml = true)
        {
            await SendMailAsync(new[] { to },subject, body, isBodyHtml);
        }

        public async Task SendMailAsync(string[] to, string subject, string body, bool isBodyHtml = true)
        {
            MailMessage mail = new();
            SmtpClient  smtp = new();

            foreach(var item in to)
                 mail.To.Add(item);

            //Gönderilicek maili oluşturma
            mail.Subject     = subject;
            mail.IsBodyHtml  = isBodyHtml;
            mail.Body        = body;
            mail.From        = new(_configuration["SelfMail"], "Rezervation Site", Encoding.UTF8);

            //Gönderilicek kanalı oluşturma
            smtp.Credentials = new NetworkCredential(_configuration["SelfMail"],
                                                     _configuration["MailPass"]);
            smtp.Port        = Convert.ToInt32(_configuration["Mail:Port"]);
            smtp.EnableSsl   = true;
            smtp.Host        = _configuration["Mail:Host"];
            
            await smtp.SendMailAsync(mail);
        }
    }
}
