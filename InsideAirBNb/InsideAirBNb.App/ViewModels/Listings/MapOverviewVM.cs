using InsideAirBNB.App.Data.Interfaces;
using InsideAirBNB.App.Models;
using InsideAirBNB.App.Models.Support.Geo;
using InsideAirBNB.App.Services.Filter;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace InsideAirBNB.App.ViewModels.Listings
{
    public class MapOverviewVM
    {
        public readonly List<Neighbourhood> Neighbourhoods;
        public readonly ListingsFilter Filter;
        public readonly List<SummaryListing> FilteredListings;
        public GeoJson GeoJson { get; set; }
        public int NrOfListings { get; set; }

        public MapOverviewVM(List<SummaryListing> listings, List<Neighbourhood> neighbourhoods, ListingsFilter filter)
        {
            Neighbourhoods = neighbourhoods;
            Filter = filter;
            FilteredListings = filter.ApplyFilters(listings);
            GeoJson = GeoJson.GenerateFromListings(FilteredListings);
        }
    }
}
