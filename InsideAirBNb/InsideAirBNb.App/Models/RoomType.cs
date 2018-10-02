using InsideAirBNB.App.Models.Base;
using System;
using System.Collections.Generic;

namespace InsideAirBNB.App.Models
{
    [Serializable]
    public class RoomType : NamedEntity
    {
        public string Color { get; set; }
        public virtual List<Listing> Listings { get; set; }
        public virtual List<SummaryListing> SummaryListings { get; set; }
    }
}
