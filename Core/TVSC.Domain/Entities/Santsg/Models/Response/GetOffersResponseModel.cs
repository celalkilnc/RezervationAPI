using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVSC.Domain.Entities.Santsg.Models.Response
{
    public class GetOffersResponseModel
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class BoardGroup
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Body
        {
            public List<Offer> offers { get; set; }
            public Information information { get; set; }
            public string productId { get; set; }
        }

        public class CancellationPolicy
        {
            public string roomNumber { get; set; }
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

        public class Information
        {
            public int total { get; set; }
        }

        public class Message
        {
            public int id { get; set; }
            public string code { get; set; }
            public int messageType { get; set; }
            public string message { get; set; }
        }

        public class Offer
        {
            public int night { get; set; }
            public bool isAvailable { get; set; }
            public int availability { get; set; }
            public List<Room> rooms { get; set; }
            public bool isRefundable { get; set; }
            public List<CancellationPolicy> cancellationPolicies { get; set; }
            public List<PriceBreakdown> priceBreakdowns { get; set; }
            public Supplier supplier { get; set; }
            public bool thirdPartyOwnOffer { get; set; }
            public List<object> restrictions { get; set; }
            public List<object> warnings { get; set; }
            public DateTime expiresOn { get; set; }
            public string offerId { get; set; }
            public DateTime checkIn { get; set; }
            public Price price { get; set; }
        }

        public class Price
        {
            public double amount { get; set; }
            public string currency { get; set; }
        }

        public class PriceBreakdown
        {
            public int productType { get; set; }
            public List<PriceBreakdown> priceBreakdowns { get; set; }
            public string roomNumber { get; set; }
            public DateTime date { get; set; }
            public Price price { get; set; }
        }

        public class Room
        {
            public string roomId { get; set; }
            public string roomName { get; set; }
            public string boardId { get; set; }
            public string boardName { get; set; }
            public List<BoardGroup> boardGroups { get; set; }
            public int stopSaleGuaranteed { get; set; }
            public int stopSaleStandart { get; set; }
            public List<Traveller> travellers { get; set; }
            public ThirdPartyInformation thirdPartyInformation { get; set; }
        }

            public Body body { get; set; }
            public Header header { get; set; }
        
        public class Supplier
        {
            public string name { get; set; }
        }

        public class ThirdPartyInformation
        {
            public List<object> infos { get; set; }
        }

        public class Traveller
        {
            public int type { get; set; }
            public int age { get; set; }
            public string nationality { get; set; }
        }


    }
}
