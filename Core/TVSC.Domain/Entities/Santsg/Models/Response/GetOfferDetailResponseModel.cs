using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVSC.Domain.Entities.Santsg.Models.Response
{
    public class GetOfferDetailResponseModel
    {
        public Body body { get; set; }
        public Header header { get; set; }

        public class Body
        {
            public List<OfferDetail> offerDetails { get; set; }
        }

        public class CancellationPolicy
        {
            public string roomNumber { get; set; }
            public DateTime beginDate { get; set; }
            public DateTime dueDate { get; set; }
            public Price price { get; set; }
            public int provider { get; set; }
        }

        public class Header
        {
            public string requestId { get; set; }
            public bool success { get; set; }
            public DateTime responseTime { get; set; }
            public List<Message> messages { get; set; }
        }

        public class Message
        {
            public int id { get; set; }
            public string code { get; set; }
            public int messageType { get; set; }
            public string message { get; set; }
        }

        public class OfferDetail
        {
            public DateTime expiresOn { get; set; }
            public string offerId { get; set; }
            public DateTime checkIn { get; set; }
            public DateTime checkOut { get; set; }
            public bool isSpecial { get; set; }
            public bool isAvailable { get; set; }
            public bool isRefundable { get; set; }
            public Price price { get; set; }
            public List<object> hotels { get; set; }
            public List<CancellationPolicy> cancellationPolicies { get; set; }
            public List<PriceBreakdown> priceBreakdowns { get; set; }
            public int provider { get; set; }
            public ReservableInfo reservableInfo { get; set; }
        }

        public class Price
        {
            public double oldAmount { get; set; }
            public int percent { get; set; }
            public double amount { get; set; }
            public string currency { get; set; }
        }

        public class PriceBreakdown
        {
            public string roomNumber { get; set; }
            public DateTime date { get; set; }
            public Price price { get; set; }
        }

        public class ReservableInfo
        {
            public bool reservable { get; set; }
        }
    }
}
