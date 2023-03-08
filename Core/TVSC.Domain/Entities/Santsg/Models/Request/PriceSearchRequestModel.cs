using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVSC.Domain.Entities.Santsg.Models.Request
{
    public class PriceSearchRequestModel
    {
        public bool checkAllotment { get; set; }
        public bool checkStopSale { get; set; }
        public bool getOnlyDiscountedPrice { get; set; }
        public bool getOnlyBestOffers { get; set; }
        public int productType { get; set; }
        public List<ArrivalLocation> arrivalLocations { get; set; }
        public List<RoomCriterion> roomCriteria { get; set; }
        public string nationality { get; set; }
        public string checkIn { get; set; }
        public int night { get; set; }
        public string currency { get; set; }
        public string culture { get; set; }
    }

    public class ArrivalLocation
    {
        public string id { get; set; }
        public int type { get; set; }
    }

    public class RoomCriterion
    {
        public int adult { get; set; }
        public List<int> childAges { get; set; }
    }

}
