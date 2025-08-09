using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra
{
    public interface IEndpoints
    {
        void Register(IEndpointRouteBuilder routeBuilder);
    }
   public static class WebApplicationExtensions
    {
        public static void RegisterEndpoints(this WebApplication app, params Type[] endpointTypes)
        {
            foreach (var endpointsType  in endpointTypes)
            {
                ((IEndpoints)ActivatorUtilities.CreateInstance(app.Services, endpointsType)).Register(app);
            }
        }
    }
}
