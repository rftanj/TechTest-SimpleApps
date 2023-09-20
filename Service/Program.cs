using Microsoft.EntityFrameworkCore;
using Service;
using TechnicalTest.Models.DBContext;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddScoped<AppDBContext>();
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
