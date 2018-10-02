using InsideAirBNB.App.Models;
using System.Collections.Generic;
using System.Linq;

namespace InsideAirBNB.App.Services.Filter
{
    public class ListingsFilter
    {
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public string NeighbourhoodName { get; set; }
        public int? NrOfReviews { get; set; }

        public ListingsFilter(int? minPrice, int? maxPrice, string neighbourhoodName, int? nrOfReviews)
        {
            MinPrice = minPrice;
            MaxPrice = maxPrice;
            NrOfReviews = nrOfReviews;
            NeighbourhoodName = neighbourhoodName;
        }

        public List<Listing> ApplyFilters(IEnumerable<Listing> items)
        {
            if (MinPrice.HasValue)
            {
                items = items.Where(x => x.PriceAsDouble() >= MinPrice);
            }
            if (MaxPrice.HasValue)
            {
                items = items.Where(x => x.PriceAsDouble() <= MaxPrice);
            }
            if (NrOfReviews.HasValue)
            {
                items = items.Where(x => x.NumberOfReviews >= NrOfReviews);
            }
            if (!string.IsNullOrEmpty(NeighbourhoodName))
            {
                items = items.Where(x => x.NeighbourhoodCleansed == NeighbourhoodName);
            }
            return items.ToList();
        }

        public List<SummaryListing> ApplyFilters(IEnumerable<SummaryListing> items)
        {
            if (MinPrice.HasValue)
            {
                items = items.Where(x => x.Price >= MinPrice);
            }
            if (MaxPrice.HasValue)
            {
                items = items.Where(x => x.Price <= MaxPrice);
            }
            if (NrOfReviews.HasValue)
            {
                items = items.Where(x => x.NumberOfReviews >= NrOfReviews);
            }
            if (!string.IsNullOrEmpty(NeighbourhoodName))
            {
                items = items.Where(x => x.Neighbourhood == NeighbourhoodName);
            }
            return items.ToList();
        }
    }
}
