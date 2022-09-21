using BOI_SmartToolWorkerService.ConfigurationModels;
using BOI_SmartToolWorkerService.Interface;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace BOI_SmartToolWorkerService.Service
{
    public class InitiateBaseProcess : IInitiateBaseProcess
    {
        private readonly SmartBotSettings _botSettings;
        private readonly ILogger<InitiateBaseProcess> _logger;
        private readonly IEmailSender _emailSender;

        public InitiateBaseProcess(IOptions<SmartBotSettings> options,ILogger<InitiateBaseProcess> logger, IEmailSender emailSender)
        {           
            _botSettings = options.Value;
            _logger = logger;
            _emailSender = emailSender;
        }

        public async Task<bool> Start()
        {
            try
            {
               
                var url = _botSettings.BonitaURL;
                var ipAddress = _botSettings.BonitaServerIP;

                if(url != null)
                {
                    //Keep Checking if the URL is not Up
                    while (!CheckIfURLisUP(url))
                    {
                        //Log it in the Database with Time that URL is not UP
                        //Send Email to some users
                        await _emailSender.SendEmailBonitaURLDownAsync(url);
                        
                        if (ipAddress != null)
                        {
                            //If URL is not up the Keep checking is the Server is not UP
                            while (!CheckIfServerIsUp(ipAddress))
                            {
                                //Log it in the Database with Time that Server is not UP
                                //Send Email to some users
                                await _emailSender.SendEmailBonitaServerDownAsync(ipAddress);

                                //delay for sometime 
                                int checkServerTime = _botSettings.checkServerTime; // in mills
                                Task.Delay(checkServerTime * 60000).Wait();
                            }
                        }
                        int checkURLTime = _botSettings.checkURLTime; // in mills
                        Task.Delay(checkURLTime * 60000).Wait();
                    }
                    int restTime = _botSettings.restTime; // in mills
                    Task.Delay(restTime * 60000).Wait();
                }
                
                
                
                return true;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static bool CheckIfURLisUP(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = 15000;
            request.Method = "HEAD"; // As per Lasse's comment
            try
            {
                bool success = false;
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {  
                    success = true;
                    return success;                   
                }
                
            }
            catch (Exception)
            {
                              
                return false;
            }
        }

        public static bool CheckIfServerIsUp(string ipAddress)
        {
            try
            {
                bool success = false;
                Ping pingSender = new Ping();
                PingReply reply = pingSender.Send(ipAddress);
                Console.WriteLine("Status of Host: {0}", ipAddress);
                if (reply.Status == IPStatus.Success)
                {
                    Console.WriteLine("IP Address: {0}", reply.Address.ToString());
                    Console.WriteLine("RoundTrip time: {0}", reply.RoundtripTime);
                    Console.WriteLine("Time to live: {0}", reply.Options.Ttl);
                    Console.WriteLine("Don't fragment: {0}", reply.Options.DontFragment);
                    Console.WriteLine("Buffer size: {0}", reply.Buffer.Length);
                    success = true;
                    return success;
                }
                else
                {
                    Console.WriteLine(reply.Status);
                    success = false;
                    return success;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
