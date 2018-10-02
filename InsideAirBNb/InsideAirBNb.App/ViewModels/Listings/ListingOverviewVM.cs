using InsideAirBNB.App.Data.Interfaces;
using InsideAirBNB.App.Data.Repositories;
using InsideAirBNB.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InsideAirBNB.App.ViewModels.Listings
{
    [Serializable]
    public class ListingOverviewVM
    {
        private readonly List<SummaryListing> AllListings;

        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        private int ListStartPos;
        private int ListEndPos;

        public ListingOverviewVM(List<SummaryListing> listings, int pageIndex, int pageSize)
        {
            AllListings = listings;
            TotalPages = (int)Math.Ceiling(listings.Count() / (double)pageSize);
            if (pageIndex <= 0)
            {
                PageIndex = 1;
            }
            else if (pageIndex > TotalPages)
            {
                PageIndex = TotalPages;
            }
            else
            {
                PageIndex = pageIndex;
            }
            ListStartPos = pageSize * (pageIndex - 1);
            ListEndPos = pageSize * pageIndex;
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }

        public IEnumerable<SummaryListing> Listings
        {
            get { return AllListings.Skip(ListStartPos).Take(ListEndPos); }
        }
    }
}
