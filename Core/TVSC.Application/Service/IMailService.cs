using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVSC.Application.Service
{
    public interface IMailService
    {
        public Task SendMailAsync(string to, string subject, string body, bool isBodyHtml = true);
        public Task SendMailAsync(string[] to, string subject, string body, bool isBodyHtml = true);
    }
}
