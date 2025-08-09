using JT7SKU.Smart.Koonti.Utility.Kontraktit.SmartDroneUnit;
using System.Collections.Immutable;

namespace Smart_Drone_Unit
{
    public interface ISmartDroneUnitGrain : IGrainWithStringKey
    {
        const string Key = "singleton";
        Task<string> CreateWorld(Worlds worlds);
        Task<ImmutableArray<Worlds>> GetWorlds();
        Task<ImmutableArray<Worlds>> GetWorld(ImmutableArray<string> world);
    }
}
