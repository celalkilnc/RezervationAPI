using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVSC.Domain.Entities.Santsg.Models.Request
{
    public class ProductInfoRequestModel
    {
        public int productType { get; set; }
        public int ownerProvider { get; set; }
        public string product { get; set; }
        public string culture { get; set; }
    }
}
