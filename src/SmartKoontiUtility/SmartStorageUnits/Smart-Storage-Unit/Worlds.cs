using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JT7SKU.Smart.Koonti.Utility.Kontraktit.SmartStorageUnit
{
    [GenerateSerializer,Immutable]
    public record Worlds (
        [property: Id(0)]
        string Address,
        [property: Id(1)]
        int? BlockNumber);
  
}
