using BOI_SmartToolWorkerService.Interface;
using System.Diagnostics;
using System.Net.NetworkInformation;

namespace BOI_SmartToolWorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                try
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        ////////////////////////////////////////////////
                        ///Start the Smart Bot.
                        var service = scope.ServiceProvider.GetRequiredService<IInitiateBaseProcess>();
                        
                        await service.Start();

                        ////////////////////////////////////////////////
                    }
                    //    ProcessStartInfo startInfo = new ProcessStartInfo();
                    //startInfo.FileName = "WINWORD.EXE";
                    //startInfo.Arguments = "";
                    //startInfo.WorkingDirectory = "";
                    //startInfo.Domain = "";
                    ////startInfo.Password = new System.Security.SecureString();
                    //startInfo.UserName = "";
                    //startInfo.PasswordInClearText = "";
                    //Process.Start(startInfo);

                    //Process.Start("C:\\McSmart\\stop-bonita.bat");



                    await Task.Delay(1000, stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError("Error happened at: {time}", DateTimeOffset.Now);
                    _logger.LogError("Error message", ex.ToString());
                    _logger.LogError("Error happened at: {time}", DateTimeOffset.Now);
                  
                }
                
            }
        }
    }
}