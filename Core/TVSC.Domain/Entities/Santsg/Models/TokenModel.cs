using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVSC.Domain.Entities.Santsg.Models
{
    public class TokenModel
    {
        public string token { get; set; }
        public DateTime expiresOn { get; set; }
        public int tokenId { get; set; }
    }
}
