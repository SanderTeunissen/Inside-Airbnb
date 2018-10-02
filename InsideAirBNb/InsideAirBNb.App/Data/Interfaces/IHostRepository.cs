using InsideAirBNB.App.Models;
using System;
using System.Collections.Generic;

namespace InsideAirBNB.App.Data.Interfaces
{
    public interface IHostRepository : IRepository<Host>
    {
        int CountWithListings(Func<Host, bool> predicate);
        Host GetByIdWithListings(int id);
        List<Host> GetAllWithListings();
        List<Host> FindWithListings(Func<Host, bool> predicate);
    }
}
