using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;

namespace DeployAzureFunctionFromGithub
{


    public class Function1
    {
        private static HttpClient httpClient = new HttpClient();
        private readonly string _apiUrl;


        public Function1(IConfiguration configuration)
        {
            _apiUrl = configuration["apiUrl"];
        }

        [FunctionName("Function1")]
        public void Run([TimerTrigger("0 */5 * * * *")] TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            httpClient.PostAsync(_apiUrl, new StringContent("test"));
        }
    }
}
