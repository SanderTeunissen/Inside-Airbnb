using InsideAirBNB.App.Data.Interfaces;
using InsideAirBNB.App.Models;
using InsideAirBNB.App.Services.Filter;
using System.Collections.Generic;
using System.Linq;

namespace InsideAirBNB.App.ViewModels.Statistics
{
    public class RoomTypesVM
    {
        public readonly string[] RoomTypeLabels;
        public readonly int[] RoomTypeValues;
        public readonly string[] RoomTypeColors;

        public RoomTypesVM(List<SummaryListing> listings)
        {
            var roomtypes = from l in listings
                            orderby l.RoomTypeId
                            group l by l.RoomTypeId into g
                            select new {
                                Name = g.Select(x => x.RoomType.Name).FirstOrDefault(),
                                Count = g.Count(),
                                Color = g.Select(x => x.RoomType.Color).FirstOrDefault()
                            };
            RoomTypeLabels = roomtypes.Select(x => x.Name).ToArray();
            RoomTypeValues = roomtypes.Select(x => x.Count).ToArray();
            RoomTypeColors = roomtypes.Select(x => x.Color).ToArray();
        }
    }
}
