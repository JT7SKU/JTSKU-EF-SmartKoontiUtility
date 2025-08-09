using Infra;
using SmartStorageUnitKontrakti;

namespace SmartStorageUnitApi
{
    public class SmartStorageUnitEndpoints(IClusterClient klusteri) : IEndpoints
    {

        readonly ISmartStorageUnitGrain smartStorageUnit = klusteri.GetGrain<ISmartStorageUnitGrain>(ISmartStorageUnitGrain.Key);

        public void Register(IEndpointRouteBuilder routeBuilder)
        {
            var group = routeBuilder.MapGroup("/smartstorageunit").WithTags("SmartStorage");
        }
    }
}
