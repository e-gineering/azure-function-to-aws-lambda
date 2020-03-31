using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Egineering.Function
{
    public static class FunctionDemo
    {
        [FunctionName("FunctionDemo")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            int value = string.IsNullOrWhiteSpace(req.Query["value"]) ?
                DateTime.Now.Year :
                int.Parse(req.Query["value"]);

            var output = new { value = value, factors = GetFactors(value) };

            return (ActionResult)new OkObjectResult(output);
        }

        private static int[] GetFactors(int value)
        {
            return Enumerable.Range(1, value).Where(i => value % i == 0).ToArray();
        }
    }
}
