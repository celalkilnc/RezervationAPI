using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVSC.Domain.Entities.Santsg.Models.Response
{
    public class ProductInfoResponseModel
    {

        public Body body { get; set; }

        public Header header { get; set; }

        public class Body
        {
            public Hotel hotel { get; set; }
        }

        public class Header
        {
            public string requestId { get; set; }
            public bool success { get; set; }
            public DateTime responseTime { get; set; }
            public List<Message> messages { get; set; }
        }

        public class Address
        {
            public City city { get; set; }
            public List<string> addressLines { get; set; }
            public string street { get; set; }
            public string streetNumber { get; set; }
            public string zipCode { get; set; }
            public Geolocation geolocation { get; set; }
        }

        public class City
        {
            public string name { get; set; }
            public int provider { get; set; }
            public bool isTopRegion { get; set; }
            public string latitude { get; set; }
            public string longitude { get; set; }
            public string id { get; set; }
        }

        public class Country
        {
            public string name { get; set; }
            public int provider { get; set; }
            public bool isTopRegion { get; set; }
            public string id { get; set; }
        }

        public class Description
        {
            public string text { get; set; }
        }

        public class Geolocation
        {
            public string longitude { get; set; }
            public string latitude { get; set; }
        }

        public class GiataInfo
        {
            public string hotelId { get; set; }
            public string destinationId { get; set; }
        }

        public class Hotel
        {
            public Address address { get; set; }
            public string faxNumber { get; set; }
            public string phoneNumber { get; set; }
            public int stopSaleGuaranteed { get; set; }
            public int stopSaleStandart { get; set; }
            public List<object> handicaps { get; set; }
            public Geolocation geolocation { get; set; }
            public int stars { get; set; }
            public int rating { get; set; }
            public List<object> themes { get; set; }
            public Location location { get; set; }
            public Country country { get; set; }
            public City city { get; set; }
            public GiataInfo giataInfo { get; set; }
            public int provider { get; set; }
            public Description description { get; set; }
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Location
        {
            public string name { get; set; }
            public string latitude { get; set; }
            public string longitude { get; set; }
            public int provider { get; set; }
            public bool isTopRegion { get; set; }
            public string id { get; set; }
        }

        public class Message
        {
            public int id { get; set; }
            public string code { get; set; }
            public int messageType { get; set; }
            public string message { get; set; }
        }

    }
}
