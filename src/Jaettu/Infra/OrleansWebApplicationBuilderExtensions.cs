using Microsoft.Extensions.Hosting;
using Orleans.Configuration;
using Orleans.Runtime;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Microsoft.AspNetCore.Builder
{
    public static class OrleansWebApplicationBuilderExtensions
    {
        public static WebApplicationBuilder AsOrleansSilo(this WebApplicationBuilder builder,
            Action<ISiloBuilder>? siloBuilderCallback = null)
        {
            var Invariant = "NpSQL";
           builder.AddKeyedNpgsqlDataSource("klustering");
            builder.AddKeyedNpgsqlDataSource("ryyniTila");
            
            builder.UseOrleans(silo =>
            {
                silo.Configure<ClusterMembershipOptions>(o =>
                {
                    o.IAmAliveTablePublishTimeout = TimeSpan.FromSeconds(30);
                    o.NumMissedTableIAmAliveLimit = 4;
                });
                silo.UseAdoNetClustering(option =>
                {
                    option.Invariant = Invariant;
                });
                silo.AddAdoNetGrainStorage("GrainStorage", options =>
                {
                    options.Invariant = Invariant;
                });
                if (siloBuilderCallback is not null)
                {
                    siloBuilderCallback(silo);
                }
            });

            return builder;
        }

        public static WebApplicationBuilder AsOrleansAsiakas(this WebApplicationBuilder builder)
        {
            var Invariant = "NpSQL";
            builder.AddKeyedNpgsqlDataSource("klustering");

            /*builder.AddKeyedAzureTableClient("clustering");*/
            builder.UseOrleansClient(asiakas =>
            {
                asiakas.Configure<GatewayOptions>(o =>
                {
                    o.GatewayListRefreshPeriod = TimeSpan.FromSeconds(30);
                });
                asiakas.UseAdoNetClustering(option =>
                {
                    option.Invariant = Invariant;
                });
                
            });

            return builder;
        }
    }
}
