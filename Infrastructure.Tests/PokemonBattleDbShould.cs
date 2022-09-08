using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Domain;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Infrastructure.Tests;

public class PokemonBattleDbShould
{
    private List<Pokemon> pokemonList { get; set; }
    public PokemonBattleDbShould()
    {
        var path = AppDomain.CurrentDomain.BaseDirectory;
        var jsonContent = File.ReadAllText(Path.Combine(path, "pokedex.json"));
        pokemonList = JsonSerializer.Deserialize<List<Pokemon>>(jsonContent)!;
    }
    
    [Fact]
    public void SaveBattleInfoToJson()
    {
        var pokemon = pokemonList.Find(pokemon => pokemon.Id == 1);
        var pokemon2 = pokemonList.Find(pokemon => pokemon.Id == 2);
        var pokemonAttacker = Substitute.For<IPokemonAttacker>();
        var pokemonBattle = new PokemonBattle(pokemonAttacker);
        var pokemonBattleDb = new PokemonBattleDb();
        
        pokemonBattle.CreateBattle(pokemon, pokemon2);
        pokemonBattleDb.SaveBattle(pokemonBattle);

        var path = AppDomain.CurrentDomain.BaseDirectory;
        var jsonContent = File.ReadAllText(Path.Combine(path, $"{pokemon.Id}vs{pokemon2.Id}.json"));
        var expectedBattle = JsonSerializer.Deserialize<PokemonBattleInfo>(jsonContent);
        pokemonBattle.PokemonBattleInfo.Should().BeEquivalentTo(expectedBattle);
    }
}