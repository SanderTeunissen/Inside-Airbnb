using System;
using InsideAirBNB.App.Models.Base;

namespace InsideAirBNB.App.Models
{
    [Serializable]
    public class SummaryReview : Entity
    {
        public int ListingId { get; set; }
        public DateTime Date { get; set; }
    }
}
