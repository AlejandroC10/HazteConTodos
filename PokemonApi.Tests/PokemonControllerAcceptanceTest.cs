using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Domain;
using FluentAssertions;
using Infrastructure;
using Newtonsoft.Json;
using Xunit;
using VerifyXunit;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace PokemonApi.Tests;

[UsesVerify]
public class PokemonControllerAcceptanceTestShould: IClassFixture<CustomWepApplicationFactory<Program>>
{
    
    private List<Pokemon> pokemonList { get; set; }
    private readonly HttpClient client;
    private IPokemonDb pokemonDbTest = new PokemonDbTest();

    public PokemonControllerAcceptanceTestShould(CustomWepApplicationFactory<Program> factory)
    {
        client = factory.CreateClient();
        (pokemonDbTest as PokemonDbTest).CopyPokedexJson();
        var path = AppDomain.CurrentDomain.BaseDirectory;
        var jsonContent = File.ReadAllText(Path.Combine(path, "pokedex.test.json"));
        pokemonList = JsonSerializer.Deserialize<List<Pokemon>>(jsonContent);
    }
    
    [Fact]
    public async Task FindPokemonById()
    {
        var response = await client.GetAsync("/Pokemon/1");
        var responseContent = await response.Content.ReadAsStringAsync();
        var foundPokemon = JsonConvert.DeserializeObject<Pokemon>(responseContent);
        var fakePokemon = pokemonList.Find(pokemon => pokemon.Id == 1);

        foundPokemon.Should().BeEquivalentTo(fakePokemon);
    }
    
    [Fact]
    public async Task FindPokemonByCategory()
    {
        var response = await client.GetAsync("/Pokemon/Type/Ghost");
        var responseContent = await response.Content.ReadAsStringAsync();
        
        await Verifier.VerifyJson(responseContent);
    }

    [Fact]
    public async Task ShowAllPokemon()
    {
        var response = await client.GetAsync("/Pokemon");
        var responseContent = await response.Content.ReadAsStringAsync();
        await Verifier.VerifyJson(responseContent);
    }

    [Fact]
    public async Task DeletePokemon()
    {
        var fakePokemon = pokemonList.Find(pokemon => pokemon.Id == 1);
        
        var response = await client.DeleteAsync("/Pokemon/1");

        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var updatedPokemonList = pokemonDbTest.ReadPokemon();
        updatedPokemonList.Should().NotContain(fakePokemon);
    }
    
    [Fact]
    public async Task ModifyPokemon()
    {
        var fakePokemon = pokemonList.Find(pokemon => pokemon.Id == 1);

        var response = await client.PutAsync("/Pokemon/1?key=HP&change=20", null);

        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var updatedPokemonList = pokemonDbTest.ReadPokemon();
        var finalPokemon = updatedPokemonList.Find(pokemon => pokemon.Id == 1);
        finalPokemon.Stats.Should().NotBeSameAs(fakePokemon.Stats);
    }
    
    [Fact]
    public async Task PokemonBattle()
    {
        var path = AppDomain.CurrentDomain.BaseDirectory;
        File.Delete(Path.Combine(path, "1vs2.json"));
        var response = await client.GetAsync("/Pokemon/Combat?pkOne=1&pkTwo=2");
        var responseContent = await response.Content.ReadAsStringAsync();
        
        responseContent.Should().Match($"Bulbasaur: * HP | Ivysaur: * HP");
    }
}