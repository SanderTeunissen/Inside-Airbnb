using InsideAirBNB.App.Data.Interfaces;
using InsideAirBNB.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsideAirBNB.App.ViewModels.Hosts
{
    public class HostOverviewVM
    {
        private readonly List<Host> AllHosts;

        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        private int ListStartPos;
        private int ListEndPos;

        public HostOverviewVM(List<Host> hosts, int pageIndex, int pageSize)
        {
            AllHosts = hosts;
            TotalPages = (int)Math.Ceiling(hosts.Count() / (double)pageSize);
            if (pageIndex <= 0)
            {
                PageIndex = 1;
            }
            else if (pageIndex > TotalPages)
            {
                PageIndex = TotalPages;
            }
            else
            {
                PageIndex = pageIndex;
            }
            ListStartPos = pageSize * (pageIndex - 1);
            ListEndPos = pageSize * pageIndex;
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }

        public IEnumerable<Host> Hosts
        {
            get { return AllHosts.Skip(ListStartPos).Take(ListEndPos); }
        }
    }
}
