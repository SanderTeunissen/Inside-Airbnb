using InsideAirBNB.App.Data.Interfaces;
using InsideAirBNB.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsideAirBNB.App.ViewModels.Statistics
{
    public class ActivityDetailsVM
    {
        public readonly List<SummaryListing> FilteredListings;
        public int NrOfReviews { get; private set; }
        public double AvgMonthlyReviews { get; private set; }
        public double AvgNightsAvailableEachMonth { get; private set; }
        public double AvgPricePerNight { get; private set; }
        public double AvgMonthlyIncome { get; private set; }

        public ActivityDetailsVM(List<SummaryListing> filteredListings)
        {
            FilteredListings = filteredListings;
            double NrOfListings = filteredListings.Count();
            double TotalPrice = 0;
            double TotalNightsAvailablePerYear = 0;
            NrOfReviews = 0;
            filteredListings.ForEach(x =>
            {
                if (x.NumberOfReviews.HasValue)
                {
                    NrOfReviews += x.NumberOfReviews.Value;
                }
                if (x.Price.HasValue)
                {
                    TotalPrice += x.Price.Value;
                }
                if (x.Availability365.HasValue)
                {
                    TotalNightsAvailablePerYear += x.Availability365.Value;
                }
            });
            AvgMonthlyReviews = Math.Round((double)NrOfReviews / NrOfListings / 12.00, 0);
            AvgPricePerNight = Math.Round(TotalPrice / NrOfListings, 2);
            AvgNightsAvailableEachMonth = Math.Round(TotalNightsAvailablePerYear / NrOfListings / 12.00, 0);
            AvgMonthlyIncome = Math.Round(AvgPricePerNight * AvgNightsAvailableEachMonth, 2);
        }
    }
}
