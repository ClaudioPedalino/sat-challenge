using NBomber.Contracts;
using NBomber.CSharp;
using NBomber.Plugins.Http.CSharp;
using System;
using System.Net.Http;

namespace Sat.Recruitment.LoadTesting
{
    static class Program
    {
        static void Main(string[] args)
        {
            const int warmup = 5;
            const int seconds = 30;
            const int keep = 12;
            const int inject = 100;

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-ClientId", "dev-id-2");
            client.DefaultRequestHeaders.Add("SatApiKey", "let-me-pass");

            var httpFactory = HttpClientFactory.Create(httpClient: client);

            var name = $"sat-challenge-api";
            var url = $"https://localhost:7000/api/users/get-all?bypassCache=true";

            IStep step = CreateStep(httpFactory, name, url);
            RunScenario(warmup, seconds, inject, keep, name, step);
        }

        private static void RunScenario(int warmup, int seconds, int inject, int keep, string name, IStep step)
        {
            var scenario = ScenarioBuilder
                .CreateScenario(name, step)
                .WithWarmUpDuration(TimeSpan.FromSeconds(warmup))
                //.WithLoadSimulations(Simulation.InjectPerSec(inject, TimeSpan.FromSeconds(seconds)));
                .WithLoadSimulations(Simulation.KeepConstant(keep, TimeSpan.FromSeconds(seconds)));

            NBomberRunner.RegisterScenarios(scenario).Run();
        }

        private static IStep CreateStep(IClientFactory<HttpClient> httpFactory, string name, string url)
        {
            return Step.Create(name, httpFactory, async context =>
            {
                var response = await context.Client.GetAsync(url, context.CancellationToken);

                return response.IsSuccessStatusCode
                    ? Response.Ok(statusCode: (int)response.StatusCode)
                    : Response.Fail(statusCode: (int)response.StatusCode);
            });
        }
    }
}
