using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVSC.Domain.Entities.Santsg.Models.Request
{
    public class GetOffersRequestModel
    {
        public string searchId { get; set; }
        public string offerId { get; set; }
        public int productType { get; set; }
        public string productId { get; set; }
        public string currency { get; set; }
        public string culture { get; set; }
        public bool getRoomInfo { get; set; }
    }
}
