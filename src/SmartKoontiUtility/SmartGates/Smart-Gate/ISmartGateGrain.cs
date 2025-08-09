using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Gate
{
    public interface ISmartGateGrain : IGrainWithStringKey
    {
        const string Key = "singleton";

    }
}
