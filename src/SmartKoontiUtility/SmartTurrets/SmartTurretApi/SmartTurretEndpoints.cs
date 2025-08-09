using Infra;
using Smart_Turret;

namespace SmartTurretApi
{
    public class SmartTurretEndpoints(IClusterClient klusteri) : IEndpoints
    {

        readonly ISmartTurretGrain smartTurret = klusteri.GetGrain<ISmartTurretGrain>(ISmartTurretGrain.Key);

        public void Register(IEndpointRouteBuilder routeBuilder)
        {
            var group = routeBuilder.MapGroup("/smartturret").WithTags("SmartTurret");
        }
    }
}
