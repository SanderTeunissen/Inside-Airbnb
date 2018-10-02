using System;
using System.Collections.Generic;
using System.Text;

namespace InsideAirBNB.App.Models.Support.Geo
{
    public class GeoJson
    {
        public string type { get; set; }
        public List<Feature> features { get; set; }

        public GeoJson()
        {
            features = new List<Feature>();
        }

        public static GeoJson GenerateFromListings(IEnumerable<SummaryListing> listings)
        {
            var GeoJson = new GeoJson
            {
                type = "FeatureCollection"
            };
            foreach (var x in listings)
            {
                string Popup_ListingInfo = string.Format("<a href=\"/Listing/Details/{0}\" class=\"mapbox-popup-id\">{0}</a><br/><h4 class=\"mapbox-popup-title\">{1}</h4>{2}<br/>{3}", x.Id, x.Name, x.Neighbourhood, x.RoomType.Name);
                string Popup_HostInfo = string.Format("<a href=\"/Host/Details/{0}\" class=\"mapbox-popup-title\">{1}</a><br/>({2})", x.HostId, x.HostName, x.CalculatedHostListingsCount <= 1 ? "No other listings" : (x.CalculatedHostListingsCount - 1).ToString() + " other listings");
                string Popup_PriceInfo = string.Format("Avg monthly income: {0}<br/>Avg nr of bookings per month:{1}", x.Price,x.NumberOfReviews);
                if (x.Latitude.HasValue && x.Longitude.HasValue)
                {
                    var feature = new Feature
                    {
                        type = "Feature",
                        properties = new Property
                        {
                            backgroundColor = x.RoomType.Color,
                            description = string.Format("{0}<hr/>{1}<hr/>{2}<hr/><a href=\"/Listing/Details/{3}\">More info</a>", Popup_ListingInfo, Popup_HostInfo, Popup_PriceInfo, x.Id)
                        },
                        geometry = new Geometry
                        {
                            type = "Point",
                            coordinates = new List<double> { x.Longitude.Value, x.Latitude.Value }
                        }
                    };
                    GeoJson.features.Add(feature);
                }
            }
            return GeoJson;
        }
    }
}
