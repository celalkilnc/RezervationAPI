using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVSC.Domain.Entities.Santsg.Models.Response
{
    public class PriceSearchResponseModel
    {
        public class BoardGroup
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Body
        {
            public string searchId { get; set; }
            public DateTime expiresOn { get; set; }
            public List<Hotel> hotels { get; set; }
            public List<Tour> tours { get; set; }
            public Details details { get; set; }
        }

        public class City
        {
            public string name { get; set; }
            public string latitude { get; set; }
            public string longitude { get; set; }
            public int provider { get; set; }
            public bool isTopRegion { get; set; }
            public string id { get; set; }
        }

        public class Details
        {
            public bool enablePaging { get; set; }
        }

        public class DistanceFromSea
        {
            public int value { get; set; }
            public int unitType { get; set; }
        }

        public class Facility
        {
            public bool isPriced { get; set; }
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Geolocation
        {
            public string longitude { get; set; }
            public string latitude { get; set; }
        }

        public class GiataInfo
        {
            public string hotelId { get; set; }
        }

        public class Header
        {
            public string requestId { get; set; }
            public bool success { get; set; }
            public DateTime responseTime { get; set; }
            public List<Message> messages { get; set; }
        }

        public class HolidayPackage
        {
            public string name { get; set; }
            public string id { get; set; }
            public string code { get; set; }
        }

        public class Hotel
        {
            public string id { get; set; }
            public string name { get; set; }
            public double stars { get; set; } 
            public Location location { get; set; }
            public City city { get; set; }
            public List<Offer> offers { get; set; }
            public string address { get; set; }
            public List<BoardGroup> boardGroups { get; set; }
            public HotelCategory hotelCategory { get; set; }
            public DistanceFromSea distanceFromSea { get; set; }
            public string code { get; set; }
            public int provider { get; set; }
            //public GiataInfo giataInfo { get; set; }
            //public Geolocation geolocation { get; set; }
            //public bool? hasThirdPartyOwnOffer { get; set; }
            //public List<Facility> facilities { get; set; }
        }

        public class HotelCategory
        {
            public string id { get; set; }
            public string name { get; set; }
            public string code { get; set; }
        }

        public class Location
        {
            public string id { get; set; }
            public string name { get; set; }
            //public string latitude { get; set; }
            //public string longitude { get; set; }
            public string countryId { get; set; }
            public int provider { get; set; }
            public bool isTopRegion { get; set; }
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
            public string offerId { get; set; }
            public int night { get; set; }
            public bool isAvailable { get; set; }
            public int availability { get; set; }
            public List<Room> rooms { get; set; }
            public bool isRefundable { get; set; }
            public HolidayPackage holidayPackage { get; set; }
            public List<string> holidayPackageBadges { get; set; }
            public DateTime accomodationCheckIn { get; set; }
            public int accomodationNight { get; set; }
            public DateTime expiresOn { get; set; }
            public DateTime checkIn { get; set; }
            public Price price { get; set; }
            public bool ownOffer { get; set; }
            public int provider { get; set; }
            public List<object> cancellationPolicies { get; set; }

            //public Supplier supplier { get; set; }
            public bool? thirdPartyOwnOffer { get; set; }
            public List<object> restrictions { get; set; }
            public List<object> warnings { get; set; }
        }

        public class Price
        {
            public double oldAmount { get; set; }
            public int percent { get; set; }
            public double amount { get; set; }
            public string currency { get; set; }
        }

        public class PriceList
        {
            public int id { get; set; }
            public SalePeriod salePeriod { get; set; }
        }

        public class Room
        {
            public string roomId { get; set; }
            public string roomName { get; set; }
            public List<object> roomGroups { get; set; }
            public string accomId { get; set; }
            public string accomName { get; set; }
            public string boardId { get; set; }
            public string boardName { get; set; }
            public List<BoardGroup> boardGroups { get; set; }
            public int allotment { get; set; }
            public int stopSaleGuaranteed { get; set; }
            public int stopSaleStandart { get; set; }
            public PriceList priceList { get; set; }
            public Price price { get; set; }
            public List<Traveller> travellers { get; set; }
            //public List<Service> services { get; set; }
            //public ThirdPartyInformation thirdPartyInformation { get; set; }
        }

            public Body body { get; set; }
            public Header header { get; set; }

        public class SalePeriod
        {
            public DateTime from { get; set; }
            public DateTime to { get; set; }
        }

        public class Tour
        {
            public string code { get; set; }
            public string id { get; set; }
            public string name { get; set; }
            public List<string> holidayPackageBadges { get; set; }
        }

        public class Traveller
        {
            public int type { get; set; }
            public double? minAge { get; set; }
            public double? maxAge { get; set; }
            public int? age { get; set; }
            public string nationality { get; set; }
        }
    }
}