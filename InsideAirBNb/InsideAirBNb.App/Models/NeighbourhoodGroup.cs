using InsideAirBNB.App.Models.Base;
using System;
using System.Collections.Generic;

namespace InsideAirBNB.App.Models
{
    [Serializable]
    public class NeighbourhoodGroup : NamedEntity
    {
        public virtual List<Neighbourhood> Neighbourhoods { get; set; }
    }
}
