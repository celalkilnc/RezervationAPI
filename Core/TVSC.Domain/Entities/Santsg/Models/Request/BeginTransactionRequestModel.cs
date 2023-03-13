using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVSC.Domain.Entities.Santsg.Models.Request
{
    public class BeginTransactionRequestModel
    {
        public List<string> offerIds { get; set; }
        public string currency { get; set; }
        public string culture { get; set; }
    }
}
