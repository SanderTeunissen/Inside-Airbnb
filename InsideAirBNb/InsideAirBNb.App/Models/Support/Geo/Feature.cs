using System;
using System.Collections.Generic;
using System.Text;

namespace InsideAirBNB.App.Models.Support.Geo
{
    public class Feature
    {
        public string type { get; set; }
        public Geometry geometry { get; set; } 
        public Property properties { get; set; }
    }
}
