using Orleans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Turret
{
    public interface ISmartTurretGrain : IGrainWithStringKey
    {
        const string Key = "singleton";
    }
}
