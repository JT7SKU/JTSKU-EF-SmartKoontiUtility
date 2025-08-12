using Aspire.Hosting;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = DistributedApplication.CreateBuilder(args);
        var pg = builder.AddPostgres("postgress").WithDataVolume();
        var klusteritable = pg.AddDatabase("klustering");
        var ryyniVarasto = pg.AddDatabase("ryynit");
        var muistutusTable = pg.AddDatabase("muistutusvarasto");
        var striimausVarasto = pg.AddDatabase("striimausvarasto");
        var striimausLinjasto = pg.AddDatabase("striimauslinjasto");

        var orleans = builder.AddOrleans("orleans")
            .WithClusterId("thing").WithClustering(klusteritable)
            .WithReminders(muistutusTable)
            .WithGrainStorage("default",ryyniVarasto)
            .WithGrainStorage("striimausVault",striimausVarasto)
            .WithStreaming("streamingprovider",striimausLinjasto);


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