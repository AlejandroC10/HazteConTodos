using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace PokemonApiTests;

public class CustomWepApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
        
}