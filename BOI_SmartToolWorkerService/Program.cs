using BOI_SmartToolWorkerService;
using BOI_SmartToolWorkerService.ConfigurationModels;
using BOI_SmartToolWorkerService.Context;
using BOI_SmartToolWorkerService.Interface;
using BOI_SmartToolWorkerService.Service;
using Microsoft.EntityFrameworkCore;




using Serilog;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext,services) =>
    {
        IConfiguration configuration = hostContext.Configuration;

       //Add connection strings settings
        services.AddDbContext<BOIDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("BOIApplicationConnectionString"));
        });

        //Add Services Registrations here
        services.AddScoped<IInitiateBaseProcess, InitiateBaseProcess>();
        services.AddScoped<IBaseEmailSender, BaseEmailSender>();
        services.AddScoped<IEmailSender, EmailSender>();

        services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
        services.Configure<SmartBotSettings>(configuration.GetSection("SmartBotSettings"));

        services.AddHostedService<Worker>();
    })
    .UseSerilog(Logging.ConfigureLogger)
    .UseWindowsService()
    .Build();

await host.RunAsync();
