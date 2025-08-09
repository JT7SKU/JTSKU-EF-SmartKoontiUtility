using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStorageUnitKontrakti
{
    public interface ISmartStorageUnitGrain : IGrainWithStringKey
    {
        const string Key = "singleton";
    }
}
