using InsideAirBNB.App.Data.Interfaces;
using InsideAirBNB.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace InsideAirBNB.App.Data.Repositories
{
    public class ListingRepository : Repository<Listing>, IListingRepository
    {
        public ListingRepository(InsideAirBNBContext context) : base(context)
        {

        }

        public new List<Listing> Find(Func<Listing, bool> predicate)
        {
            return _context.Set<Listing>().Include(x => x.RoomType).Where(predicate).ToList();
        }

        public new List<Listing> GetAll()
        {
            return _context.Set<Listing>().Include(x => x.RoomType).ToList();
        }

        public new Listing GetById(int id)
        {
            return _context.Set<Listing>().Include(x => x.RoomType).FirstOrDefault(x => x.Id == id);
        }

        public List<Listing> FindWithHost(Func<Listing, bool> predicate)
        {
            return _context.Set<Listing>().Include(x => x.Host).Include(x => x.RoomType).Where(predicate).ToList();
        }

        public List<Listing> GetAllWithHost()
        {
            return _context.Set<Listing>().Include(x => x.Host).Include(x => x.RoomType).ToList();
        }

        public Listing GetByIdWithHost(int id)
        {
            return _context.Set<Listing>().Include(x => x.Host).Include(x => x.RoomType).FirstOrDefault(x => x.Id == id);
        }

        public Listing GetByIdWithAllRefs(int id)
        {
            return _context.Set<Listing>().Include(x => x.Host).Include(x => x.RoomType).Include(x => x.Reviews).Include(x => x.Calendar).FirstOrDefault(x => x.Id == id);
        }

        public List<SummaryListing> GetAllSummary()
        {
            return _context.Set<SummaryListing>().Include(x => x.RoomType).ToList();
        }
    }
}
