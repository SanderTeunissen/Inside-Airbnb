using InsideAirBNB.App.Data.Interfaces;
using InsideAirBNB.App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsideAirBNB.App.Data.Repositories
{
    public class HostRepository : Repository<Host>, IHostRepository
    {
        public HostRepository(InsideAirBNBContext context) : base(context) {}

        public int CountWithListings(Func<Host, bool> predicate)
        {
            return _context.Set<Host>().Include(x => x.Listings).Where(predicate).Count();
        }

        public List<Host> FindWithListings(Func<Host, bool> predicate)
        {
            return _context.Set<Host>().Include(x => x.Listings).Where(predicate).ToList();
        }

        public List<Host> GetAllWithListings()
        {
            return _context.Set<Host>().Include(x => x.Listings).ToList();
        }

        public Host GetByIdWithListings(int id)
        {
            return _context.Set<Host>().Include(x => x.Listings).ThenInclude(listing => listing.RoomType).FirstOrDefault(x => x.Id == id);
        }
    }
}
