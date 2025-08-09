using Aspire.Hosting;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = DistributedApplication.CreateBuilder(args);

        //var klusteritable = "";

        var orleans = builder.AddOrleans("orleans").WithClusterId("thing");
            //.WithClustering(klusteritable)
            //.WithGrainStorage(name:"default", provider: null ).WithGrainStorage(name:"streamingstorage", provider: null)
            //.WithStreaming("streamingprovider");


        builder.AddProject<Projects.SmartDroneUnitAPI>("smartdroneunitapi")
            .WithReference(orleans)
            .WithReplicas(3);

        builder.AddProject<Projects.SmartGateApi>("smartgateapi")
            .WithReference(orleans)
            .WithReplicas(3);

        builder.AddProject<Projects.SmartStorageUnitApi>("smartstorageunitapi")
            .WithReference(orleans)
            .WithReplicas(3);

        builder.AddProject<Projects.SmartTurretApi>("smartturretapi")
            .WithReference(orleans)
            .WithReplicas(3);

        builder.Build().Run();
    }
}