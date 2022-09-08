using System.Linq;
using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace PokemonApi.Tests;

public class CustomWepApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
                builder.ConfigureServices(services =>
                {
                        var pokemonDb = services.SingleOrDefault(serviceDescriptor => serviceDescriptor.ServiceType == typeof(IPokemonDb));
                        services.Remove(pokemonDb);
                        services.AddScoped<IPokemonDb, PokemonDbTest>();
                        
                        var pokemonBattle = services.SingleOrDefault(serviceDescriptor => serviceDescriptor.ServiceType == typeof(IPokemonBattle));
                        services.Remove(pokemonBattle);
                        services.AddScoped<IPokemonBattle, PokemonBattleTest>();
                        
                        var pokemonAttacker = services.SingleOrDefault(serviceDescriptor => serviceDescriptor.ServiceType == typeof(IPokemonAttacker));
                        services.Remove(pokemonAttacker);
                        services.AddScoped<IPokemonAttacker, PokemonAttackerTest>();
                });
        }
}