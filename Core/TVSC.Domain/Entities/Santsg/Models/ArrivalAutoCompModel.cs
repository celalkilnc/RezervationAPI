using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVSC.Domain.Entities.Santsg.Models
{
    public class ArrivalAutoCompModel : SantsgBase
    {
        public int    ProductType { get; set; }
        public string Query { get; set; }
        public string Culture { get; set; }
    }
}
