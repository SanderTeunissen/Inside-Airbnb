using InsideAirBNB.App.Data.Interfaces;
using InsideAirBNB.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InsideAirBNB.App.ViewModels.Statistics
{
    public class AvailabilityDetailsVM
    {
        public int LowAvailable { get; set; }
        public int HighAvailable { get; set; }
        public double LowAvailablePerc { get; set; }
        public double HighAvailablePerc { get; set; }

        public AvailabilityDetailsVM(IEnumerable<SummaryListing> availabilities)
        {
            LowAvailable = availabilities.Where(x => x.Availability365 <= 60).Count();
            HighAvailable = availabilities.Where(x => x.Availability365 > 60).Count();
            LowAvailablePerc = Math.Round((double)LowAvailable / (double)availabilities.Count() * 100,2);
            HighAvailablePerc = Math.Round((double)HighAvailable / (double)availabilities.Count() * 100,2);
        }
    }
}
