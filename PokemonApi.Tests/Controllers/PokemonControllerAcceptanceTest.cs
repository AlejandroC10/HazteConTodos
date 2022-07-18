using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Domain;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;
using PokemonApi;

namespace PokemonApiTests.Controllers;

public class PokemonControllerAcceptanceTestShould: IClassFixture<CustomWepApplicationFactory<Program>>
{
    private readonly HttpClient client;

    public PokemonControllerAcceptanceTestShould(CustomWepApplicationFactory<Program> factory)
    {
        client = factory.CreateClient();
    }
    
    [Fact]
    public async Task FindPokemonById()
    {
        var response = await client.GetAsync("/Pokemon/1");
        var responseContent = await response.Content.ReadAsStringAsync();
        var foundedPokemon = JsonConvert.DeserializeObject<Pokemon>(responseContent);

        var fakeNames = new Dictionary<string, string>
        {
            {"english", "Bulbasaur"},
            {"japanese", "フシギダネ"},
            {"chinese", "妙蛙种子"},
            {"french", "Bulbizarre"}
        };
        var fakeStats = new Dictionary<string, int>
        {
            {"HP", 45},
            {"Attack", 49},
            {"Defense", 49},
            {"Sp. Attack", 65},
            {"Sp. Defense", 65},
            {"Speed", 45}
        };
        var fakeTypes = new List<string>
        {
            "Grass",
            "Poison"
        };
        var fakePokemon = new Pokemon(1,fakeNames,fakeTypes,fakeStats);

        foundedPokemon.Should().BeEquivalentTo(fakePokemon);
    }
    
    [Fact]
    public async Task FindPokemonByCategory()
    {
        var response = await client.GetAsync("/Pokemon/Type/Ghost");
        var responseContent = await response.Content.ReadAsStringAsync();
        var foundedPokemon = JsonConvert.DeserializeObject<List<Pokemon>>(responseContent);

        foundedPokemon.Count.Should().Be(43);
    }
    
    
    [Fact]
    public async Task ShowPokemones()
    {
        var response = await client.GetAsync("/Pokemon");
        var responseContent = await response.Content.ReadAsStringAsync();
        var foundedPokemon = JsonConvert.DeserializeObject<List<Pokemon>>(responseContent);

        foundedPokemon.Count.Should().Be(809);
    }
}