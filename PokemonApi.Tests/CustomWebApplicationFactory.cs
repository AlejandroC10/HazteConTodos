using System.Linq;
using Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Writers;
using PokemonApiTests.Controllers;
using Xunit;

namespace PokemonApiTests;

public class CustomWepApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
                builder.ConfigureServices(services =>
                {
                        var pokemonDb = services.SingleOrDefault(serviceDescriptor => serviceDescriptor.ServiceType == typeof(IPokemonDb));
                        services.Remove(pokemonDb);
                        services.AddScoped<IPokemonDb, PokemonDbTest>();
                });
        }
}