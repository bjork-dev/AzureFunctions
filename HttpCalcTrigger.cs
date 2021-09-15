using System.Linq;
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace liam.calc
{
    public static class HttpCalcTrigger
    {
        [FunctionName("HttpCalcTrigger")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req, ILogger log)
        {
            string[] numbers = req.Query["numbers"].ToString().Split(' ');
            try
            {
                int n1 = int.Parse(numbers[0]);
                int n2 = int.Parse(numbers[1]);
                int result = n1 + n2;
                log.LogInformation($"C# HTTP trigger function processed {n1} + {n2} and returned {result} .");
                return new OkObjectResult(result);
            }
            catch
            {
                return new BadRequestObjectResult("Numbers were incorrectly supplied.");
            }
        }
    }
}
