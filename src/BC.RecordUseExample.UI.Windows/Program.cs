using BC.RecordUseExample.Backend.App.Services;
using BC.RecordUseExample.Backend.App;
using BC.RecordUseExample.Backend.Domain.Commands;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BC.RecordUseExample.Backend.Infrastructure.Setup;
using Microsoft.Extensions.Logging;

namespace BC.RecordUseExample.UI.Windows
{
    internal static class Program
    {
        public static IServiceProvider? ServiceProvider { get; private set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var host = CreateHostBuilder().Build();
            
            ServiceProvider = host.Services;

            Application.Run(ServiceProvider.GetRequiredService<frmMain>());
        }
        
        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                   
                    services.AddLogging(builder => builder.AddConsole());
                    services.AddSqlPersistence(context.Configuration, context.HostingEnvironment.IsDevelopment());
                    services.AddScoped<IEmployeeService, EmployeeService>();

                    // Get all implementations of ICommandHandler and add them to the DI
                    var types = typeof(SystemCommands).Assembly.DefinedTypes;
                    var handlers = types
                        .Where(x => !x.IsAbstract && x.IsClass && !x.IsInterface && x.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICommandHandler<>)))
                        .ToList();

                    handlers.ForEach((handler) =>
                    {
                        foreach (var implementedInterface in handler.ImplementedInterfaces)
                        {
                            services.AddScoped(implementedInterface, handler);
                        }
                    });

                    services.AddScoped<SystemCommands>();
                    services.AddScoped<frmMain>();
                });
        }
    }
}