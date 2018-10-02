using System;
using InsideAirBNB.App.Models.Base;

namespace InsideAirBNB.App.Models
{
    [Serializable]
    public class Review : Entity
    {
        public int ListingId { get; set; }
        public virtual Listing Listing { get; set; }

        public DateTime Date { get; set; }
        public int ReviewerId { get; set; }
        public string ReviewerName { get; set; }
        public string Comments { get; set; }
    }
}
