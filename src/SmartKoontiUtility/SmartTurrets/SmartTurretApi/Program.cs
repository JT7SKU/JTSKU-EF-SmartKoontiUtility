
using Microsoft.AspNetCore.Builder;
using Orleans.Configuration;

namespace SmartTurretApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.AddServiceDefaults();

        // Add services to the container.
        builder.Services.AddAuthorization();
        builder.AsOrleansSilo(silo =>
        {
            silo.Configure<SiloOptions>(options =>
             options.SiloName = $"SmartTurret_{Path.GetFileNameWithoutExtension(Path.GetRandomFileName())}");
        });
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        var app = builder.Build();

        app.MapDefaultEndpoints();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

       

        app.Run();
    }
}
