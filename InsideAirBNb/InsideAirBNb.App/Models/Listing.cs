using InsideAirBNB.App.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace InsideAirBNB.App.Models
{
    [Serializable]
    public class Listing : NamedEntity
    {
        public Listing()
        {
            Calendar = new HashSet<Calendar>();
            Reviews = new HashSet<Review>();
        }
        
        public string ListingUrl { get; set; }
        public double ScrapeId { get; set; }
        public DateTime LastScraped { get; set; }
        public string Summary { get; set; }
        public string Space { get; set; }
        public string Description { get; set; }
        public string ExperiencesOffered { get; set; }
        public string NeighborhoodOverview { get; set; }
        public string Notes { get; set; }
        public string Transit { get; set; }
        public string Access { get; set; }
        public string Interaction { get; set; }
        public string HouseRules { get; set; }

        #region Images
        public string ThumbnailUrl { get; set; }
        public string MediumUrl { get; set; }
        public string PictureUrl { get; set; }
        public string XlPictureUrl { get; set; }
        #endregion

        #region HostInfo
        public int HostId { get; set; }
        public virtual Host Host { get; set; }
        #endregion

        #region Location
        public string Street { get; set; }
        public string Neighbourhood { get; set; }
        public string NeighbourhoodCleansed { get; set; }
        public string NeighbourhoodGroupCleansed { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string Market { get; set; }
        public string SmartLocation { get; set; }
        public string CountryCode { get; set; }
        public string Country { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string IsLocationExact { get; set; }
        #endregion

        #region PropertyInformation
        public string PropertyType { get; set; }

        public int RoomTypeId { get; set; }
        public virtual RoomType RoomType { get; set; }
        
        public int? Accommodates { get; set; }
        public double? Bathrooms { get; set; }
        public int? Bedrooms { get; set; }
        public int? Beds { get; set; }
        public string BedType { get; set; }
        public string Amenities { get; set; }
        public string SquareFeet { get; set; }
        [Display(Name = "Price (one night)")]
        public string Price { get; set; }
        [Display(Name = "Weekly price")]
        public string WeeklyPrice { get; set; }
        [Display(Name = "Monthly price")]
        public string MonthlyPrice { get; set; }
        [Display(Name = "Securitydeposit")]
        public string SecurityDeposit { get; set; }
        [Display(Name = "Cleaning fee")]
        public string CleaningFee { get; set; }
        public int? GuestsIncluded { get; set; }
        [Display(Name = "Price extra people (pp)")]
        public string ExtraPeople { get; set; }
        public int? MinimumNights { get; set; }
        public int? MaximumNights { get; set; }
        #endregion

        #region Availability
        public string CalendarUpdated { get; set; }
        public string HasAvailability { get; set; }
        public int? Availability30 { get; set; }
        public int? Availability60 { get; set; }
        public int? Availability90 { get; set; }
        public int? Availability365 { get; set; }
        public DateTime? CalendarLastScraped { get; set; }
        #endregion

        #region Reviews
        public int? NumberOfReviews { get; set; }
        public DateTime? FirstReview { get; set; }
        public DateTime? LastReview { get; set; }
        public int? ReviewScoresRating { get; set; }
        public int? ReviewScoresAccuracy { get; set; }
        public int? ReviewScoresCleanliness { get; set; }
        public int? ReviewScoresCheckin { get; set; }
        public int? ReviewScoresCommunication { get; set; }
        public int? ReviewScoresLocation { get; set; }
        public int? ReviewScoresValue { get; set; }

        public ICollection<Review> Reviews { get; set; }
        #endregion

        public string RequiresLicense { get; set; }
        public string License { get; set; }
        public string JurisdictionNames { get; set; }
        public string InstantBookable { get; set; }
        public string IsBusinessTravelReady { get; set; }
        public string CancellationPolicy { get; set; }
        public string RequireGuestProfilePicture { get; set; }
        public string RequireGuestPhoneVerification { get; set; }
        public int CalculatedHostListingsCount { get; set; }
        public double? ReviewsPerMonth { get; set; }

        public ICollection<Calendar> Calendar { get; set; }

        public double PriceAsDouble()
        {
            string price_string = Price.Replace("$", "").Replace(",","").Replace(".",",");
            double price = Double.Parse(price_string, NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands | NumberStyles.AllowCurrencySymbol);
            return price;
        }
    }
}
