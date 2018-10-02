using System;

namespace InsideAirBNB.App.Models.Base
{
    [Serializable]
    public class NamedEntity : Entity
    {
        public string Name { get; set; }
    }
}
