using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsideAirBNB.App.Controllers.Base;
using InsideAirBNB.App.Data.Interfaces;
using InsideAirBNB.App.Models;
using InsideAirBNB.App.ViewModels.Hosts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace InsideAirBNB.App.Controllers
{
    [Authorize]
    public class HostController : CacheController
    {
        private readonly IHostRepository HostRepository;

        public HostController(IHostRepository hostRepository, IDistributedCache distributedCache) : base(distributedCache)
        {
            HostRepository = hostRepository;
        }

        [HttpGet]
        public IActionResult Index(int page = 1)
        {
            return View(new HostOverviewVM(GetHostsFromCache(), page, 60));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(GetHostFromCache(id));
        }

        private List<Host> GetHostsFromCache()
        {
            List<Host> hosts;
            try
            {
                byte[] fromRedisCache = _distributedCache.Get("AllSummaryHost");
                if (fromRedisCache != null)
                {
                    hosts = (List<Host>)ByteArrayToObject(fromRedisCache);
                }
                else
                {
                    hosts = HostRepository.GetAll();
                    byte[] toRedisCache = ObjectToByteArray(hosts);
                    _distributedCache.Set("AllSummaryHost", toRedisCache);
                }
            }
            catch
            {
                hosts = HostRepository.GetAll();
            }
            return hosts;
        }

        private Host GetHostFromCache(int id)
        {
            Host host;
            try
            {
                byte[] fromRedisCache = _distributedCache.Get(string.Format("Host_{0}", id));
                if (fromRedisCache != null)
                {
                    host = (Host)ByteArrayToObject(fromRedisCache);
                }
                else
                {
                    host = HostRepository.GetByIdWithListings(id);
                    byte[] toRedisCache = ObjectToByteArray(host);
                    _distributedCache.Set(string.Format("Host_{0}", id), toRedisCache);
                }
            }
            catch
            {
                host = HostRepository.GetByIdWithListings(id);
            }
            return host;
        }
    }
}