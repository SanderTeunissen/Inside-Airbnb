using System;
using System.Collections.Generic;
using InsideAirBNB.App.Models.Base;

namespace InsideAirBNB.App.Models
{
    [Serializable]
    public class Host : NamedEntity
    {
        public string About { get; set; }
        public DateTime? Since { get; set; }

        public string Url { get; set; }
        public string ThumbnailUrl { get; set; }
        public string HasProfilePic { get; set; }
        public string PictureUrl { get; set; }

        public string ResponseTime { get; set; }
        public string ResponseRate { get; set; }

        public string Location { get; set; }
        public string Neighbourhood { get; set; }

        public string IdentityVerified { get; set; }
        public string Verifications { get; set; }

        public string AcceptanceRate { get; set; }

        public string IsSuperhost { get; set; }

        public int? ListingsCount { get; set; }
        public int? TotalListingsCount { get; set; }

        public virtual List<Listing> Listings { get; set; }

        public int NrOfListings()
        {
            if (Listings == null)
            {
                return 0;
            }
            return Listings.Count;
        }
    }
}
