using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVSC.Domain.Entities.Santsg;

namespace TVSC.Infrastructure.Santsg.Model
{
    public class LoginModel
    {
        public string Agency { get; set; }

        public string User { get; set; }

        public string Password { get; set; }
    }
}
