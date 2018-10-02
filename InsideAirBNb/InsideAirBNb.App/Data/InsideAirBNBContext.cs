using InsideAirBNB.App.Models;
using InsideAirBNB.App.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InsideAirBNB.App.Data
{
    public partial class InsideAirBNBContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Calendar> Calendars { get; set; }
        public virtual DbSet<Listing> Listings { get; set; }
        public virtual DbSet<Neighbourhood> Neighbourhoods { get; set; }
        public virtual DbSet<NeighbourhoodGroup> NeighbourhoodGroups { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<SummaryListing> SummaryListings { get; set; }
        public virtual DbSet<SummaryReview> SummaryReviews { get; set; }
        public virtual DbSet<RoomType> RoomTypes { get; set; }
        public virtual DbSet<Host> Hosts { get; set; }

        public InsideAirBNBContext(DbContextOptions<InsideAirBNBContext> options) : base(options)
        {
            Database.SetCommandTimeout(300);
        }
    }
}

