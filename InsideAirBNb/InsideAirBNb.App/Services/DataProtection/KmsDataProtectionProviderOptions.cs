using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsideAirBNB.App.Services.DataProtection
{
    public class KmsDataProtectionProviderOptions
    {
        public string ProjectId { get; set; }
        public string Location { get; set; } = "global";
        public string KeyRing { get; set; }
    }
}
