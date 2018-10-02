using InsideAirBNB.App.Models;
using System;
using System.Collections.Generic;

namespace InsideAirBNB.App.Data.Interfaces
{
    public interface IListingRepository : IRepository<Listing>
    {
        Listing GetByIdWithHost(int id);
        List<Listing> GetAllWithHost();
        List<Listing> FindWithHost(Func<Listing, bool> predicate);
        Listing GetByIdWithAllRefs(int id);
        List<SummaryListing> GetAllSummary();

    }
}
