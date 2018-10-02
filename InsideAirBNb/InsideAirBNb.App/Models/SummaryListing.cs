using System;
using InsideAirBNB.App.Models.Base;

namespace InsideAirBNB.App.Models
{
    [Serializable]
    public class SummaryListing : NamedEntity
    {
        public int HostId { get; set; }
        public string HostName { get; set; }
        public string NeighbourhoodGroup { get; set; }
        public string Neighbourhood { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public int RoomTypeId { get; set; }
        public virtual RoomType RoomType { get; set; }
        public int? Price { get; set; }
        public int? MinimumNights { get; set; }
        public int? NumberOfReviews { get; set; }
        public DateTime? LastReview { get; set; }
        public double? ReviewsPerMonth { get; set; }
        public int? CalculatedHostListingsCount { get; set; }
        public int? Availability365 { get; set; }
        public string PictureUrl { get; set; }
    }
}
