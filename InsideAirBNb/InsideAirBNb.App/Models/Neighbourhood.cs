using InsideAirBNB.App.Models.Base;
using System;

namespace InsideAirBNB.App.Models
{
    [Serializable]
    public class Neighbourhood : NamedEntity
    {
        public int? NeighbourhoodGroupID { get; set; }
        public virtual NeighbourhoodGroup NeighbourhoodGroup { get; set; }
    }
}
