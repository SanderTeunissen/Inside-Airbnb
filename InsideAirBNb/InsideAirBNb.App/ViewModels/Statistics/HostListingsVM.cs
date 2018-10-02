using InsideAirBNB.App.Models;
using InsideAirBNB.App.Services.Filter;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InsideAirBNB.App.ViewModels.Statistics
{
    public class HostListingsVM
    {
        public int HostSingleListing { get; set; }
        public int HostMultipleListings { get; set; }
        public double HostSingleListingPerc { get; set; }
        public double HostMultipleListingsPerc { get; set; }

        public HostListingsVM(IEnumerable<SummaryListing> listings)
        {
            var nrOfListingsPerHost = from l in listings
                                      group l by l.HostId into h
                                      select h.Count();
            var nrOfListings = listings.Count();
            HostSingleListing = nrOfListingsPerHost.Where(x => x == 1).Count();
            HostMultipleListings = nrOfListingsPerHost.Where(x => x > 1).Count();
            HostSingleListingPerc = Math.Round((double)HostSingleListing / nrOfListings * 100, 2);
            HostMultipleListingsPerc = Math.Round((double)HostMultipleListings / nrOfListings * 100, 2);
        }
    }
}
