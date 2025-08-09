using Infra;
using Smart_Gate;

namespace SmartGateApi
{
    public class SmartGateEndpoints(IClusterClient klusteri) : IEndpoints
    {

        readonly ISmartGateGrain smartGate = klusteri.GetGrain<ISmartGateGrain>(ISmartGateGrain.Key)

        public void Register(IEndpointRouteBuilder routeBuilder)
        {
            var group = routeBuilder.MapGroup("/smartgate").WithTags("SmartGate");
        }
    }
}
