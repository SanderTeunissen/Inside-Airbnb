using InsideAirBNB.App.Models.Base;
using System;

namespace InsideAirBNB.App.Models
{
    [Serializable]
    public class Calendar : Entity
    {
        public int ListingId { get; set; }
        public DateTime Date { get; set; }
        public string Available { get; set; }
        public string Price { get; set; }
        public Listing Listing { get; set; }
    }
}
