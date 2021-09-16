#r "Newtonsoft.Json"

using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

public static async Task<IActionResult> Run(HttpRequest req, ILogger log)
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
