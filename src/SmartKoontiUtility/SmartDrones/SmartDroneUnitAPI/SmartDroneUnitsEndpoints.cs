using Infra;
using Smart_Drone_Unit;

namespace SmartDroneUnitAPI
{
    public class SmartDroneUnitsEndpoints(IClusterClient orlklusteri) : IEndpoints
    {

        readonly ISmartDroneUnitGrain smartDroneUnit = orlklusteri.GetGrain<ISmartDroneUnitGrain>(ISmartDroneUnitGrain.Key);
        public void Register(IEndpointRouteBuilder routeBuilder)
        {
            var group = routeBuilder.MapGroup("/smartdroneunit").WithTags("SmartDrone");
        }
    }
}
