using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using InsideAirBNB.App.Controllers.Base;
using InsideAirBNB.App.Data.Interfaces;
using InsideAirBNB.App.Data.Repositories;
using InsideAirBNB.App.Models;
using InsideAirBNB.App.Models.Support.Geo;
using InsideAirBNB.App.Services.Filter;
using InsideAirBNB.App.ViewModels;
using InsideAirBNB.App.ViewModels.Listings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace InsideAirBNB.App.Controllers
{
    [Authorize]
    public class ListingController : CacheController
    {
        private readonly IListingRepository ListingRepository;
        private readonly IRepository<Neighbourhood> NeighbourhoodRepository;

        public ListingController(
            IListingRepository listingRepository,
            IRepository<Neighbourhood> neighbourhoodRepository,
            IDistributedCache distributedCache) : base(distributedCache)
        {
            ListingRepository = listingRepository;
            NeighbourhoodRepository = neighbourhoodRepository;
        }

        [HttpGet]
        public IActionResult Index(int page = 1)
        {
            if (page < 1)
            {
                page = 1;
            }
            return View(new ListingOverviewVM(GetSummaryListingsFromCache(), page,60));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(GetListingFromCache(id));
        }

        [HttpGet]
        public IActionResult MapOverview(int? minPrice = null, int? maxPrice = null, int? nrOfReviews = null, string neighbourhoodName = null)
        {
            return View(new MapOverviewVM(
                GetSummaryListingsFromCache(),
                GetNeighbourhoodsFromCache(),
                new ListingsFilter(minPrice, maxPrice, neighbourhoodName, nrOfReviews)));
        }

        private List<SummaryListing> GetSummaryListingsFromCache()
        {
            List<SummaryListing> listings;
            try
            {
                byte[] fromRedisCache = _distributedCache.Get("AllSummaryListing");
                if (fromRedisCache != null)
                {
                    listings = (List<SummaryListing>)ByteArrayToObject(fromRedisCache);
                }
                else
                {
                    listings = ListingRepository.GetAllSummary();
                    byte[] toRedisCache = ObjectToByteArray(listings);
                    _distributedCache.Set("AllSummaryListing", toRedisCache);
                }
            }
            catch
            {
                listings = ListingRepository.GetAllSummary();
            }
            return listings;
        }

        private List<Neighbourhood> GetNeighbourhoodsFromCache()
        {
            List<Neighbourhood> neighbourhoods;
            try
            {
                byte[] fromRedisCache = _distributedCache.Get("AllNeighbourhoods");
                if (fromRedisCache != null)
                {
                    neighbourhoods = (List<Neighbourhood>)ByteArrayToObject(fromRedisCache);
                }
                else
                {
                    neighbourhoods = NeighbourhoodRepository.GetAll();
                    byte[] toRedisCache = ObjectToByteArray(neighbourhoods);
                    _distributedCache.Set("AllNeighbourhoods", toRedisCache);
                }
            }
            catch
            {
                neighbourhoods = NeighbourhoodRepository.GetAll();
            }
            return neighbourhoods;
        }

        private Listing GetListingFromCache(int id)
        {
            Listing listing;
            try
            {
                byte[] fromRedisCache = _distributedCache.Get(string.Format("Listing_{0}", id));
                if (fromRedisCache != null)
                {
                    listing = (Listing)ByteArrayToObject(fromRedisCache);
                }
                else
                {
                    listing = ListingRepository.GetByIdWithAllRefs(id);
                    byte[] toRedisCache = ObjectToByteArray(listing);
                    _distributedCache.Set(string.Format("Listing_{0}", id), toRedisCache);
                }
            }
            catch
            {
                listing = ListingRepository.GetByIdWithAllRefs(id);
            }
            return listing;
        }
    }
}