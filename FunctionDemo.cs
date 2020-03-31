using System;
using System.Linq;
using Amazon.Lambda.Core;

namespace Egineering.Function
{
    public static class FunctionDemo
    {
        [LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
        public static object FunctionHandler(ILambdaContext context)
        {
            int value = DateTime.Now.Year;
            var output = new { value = value, factors = GetFactors(value) };
            return output;
        }

        private static int[] GetFactors(int value)
        {
            return Enumerable.Range(1, value).Where(i => value % i == 0).ToArray();
        }
    }
}
