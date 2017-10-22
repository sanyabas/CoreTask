using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SimpleApp
{
    public class SimpleTimeMeasurer
    {
        private readonly RequestDelegate _next;

        public SimpleTimeMeasurer(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var sw = Stopwatch.StartNew();
            await _next.Invoke(context);
            await context.Response.WriteAsync($"Class: elapsed {sw.ElapsedMilliseconds} ms<br>");
        }
    }
}