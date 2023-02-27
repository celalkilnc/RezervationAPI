using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVSC.Domain.Entities.Common;

namespace TVSC.Domain.Entities
{
    public class Rezervation:BaseEntity
    {
        //Number of person
        public int Adult { get; set; }
        public int? Child { get; set; }

        //Place Information
        public string HotelName { get; set; }
        public string RoomNum { get; set; }

        //Traveller Information
        public string TravellerName { get; set; }
        public string? TravellerEmail { get; set; }

        //Dates
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
        //Total Price
        public float HolidayPrice { get; set; }
    }
}
