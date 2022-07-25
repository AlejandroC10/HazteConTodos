using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Domain;
using FluentAssertions;
using Xunit;

namespace Infrastructure.Tests;

public class PokemonDbShould
{
    [Fact]
    public void ReadPokemonReturnAPokemonList()
    {
        var pokemonDb = new PokemonDb();
        var pokemonList = pokemonDb.ReadPokemon();
        
        var path = AppDomain.CurrentDomain.BaseDirectory;
        var jsonContent = File.ReadAllText(Path.Combine(path, "pokedex.json"));
        var expectedList = JsonSerializer.Deserialize<List<Pokemon>>(jsonContent);

        pokemonList.Should().BeEquivalentTo(expectedList);
    }
    
    [Fact]
    public void DeletePokemonById()
    {
        var pokemonDb = new PokemonDb();
        var pokemonList = pokemonDb.ReadPokemon();
        var pokemon = pokemonList.Find(pokemon => pokemon.Id == 1);
        
        pokemonDb.DeletePokemon(1);
        var finalList = pokemonDb.ReadPokemon();
        
        finalList.Should().NotContain(pokemon);
    }
    
    [Fact]
    public void UpdatePokemonById()
    {
        var pokemonDb = new PokemonDb();
        var pokemonList = pokemonDb.ReadPokemon();
        var ogPokemon = pokemonList.Find(pokemon => pokemon.Id == 1);
        
        pokemonDb.UpdatePokemon(1,"HP",20);
        
        var finalList = pokemonDb.ReadPokemon();
        var finalPokemon = finalList.Find(pokemon => pokemon.Id == 1);
        
        finalPokemon.Stats["HP"].Should().NotBe(ogPokemon.Stats["HP"]);
    }
}