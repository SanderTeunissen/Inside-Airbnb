using System;
using System.Collections.Generic;
using System.Text;

namespace InsideAirBNB.App.Models.Support.Geo
{
    public class Geometry
    {
        public string type { get; set; }
        public List<double> coordinates { get; set; }
    }
}
