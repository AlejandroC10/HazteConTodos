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
    
    [Fact]
    public void DeleteBattle()
    {
        var pokemon = pokemonList.Find(pokemon => pokemon.Id == 1);
        var pokemon2 = pokemonList.Find(pokemon => pokemon.Id == 2);
        var pokemonAttacker = Substitute.For<IPokemonAttacker>();
        var pokemonBattle = new PokemonBattle(pokemonAttacker);
        var pokemonBattleDb = new PokemonBattleDb();
        
        pokemonBattle.CreateBattle(pokemon, pokemon2);
        pokemonBattleDb.DeleteBattle(pokemonBattle);
        var path = AppDomain.CurrentDomain.BaseDirectory;
        
        File.Exists(Path.Combine(path, $"{pokemon.Id}vs{pokemon2.Id}.json")).Should().BeFalse();
    }
    
    [Fact]
    public void LoadBattleIfExists()
    {
        var pokemon = pokemonList.Find(pokemon => pokemon.Id == 1);
        var pokemon2 = pokemonList.Find(pokemon => pokemon.Id == 2);
        var pokemonAttacker = Substitute.For<IPokemonAttacker>();
        var pokemonBattle = new PokemonBattle(pokemonAttacker);
        var pokemonBattleDb = new PokemonBattleDb();
        pokemonAttacker.CalculateDamage(pokemon.Stats["Attack"]).Returns(5);
        
        pokemonBattle.CreateBattle(pokemon, pokemon2);
        pokemonBattle.Combat();
        pokemonBattleDb.SaveBattle(pokemonBattle);
        
        var pokemonBattleTwo = new PokemonBattle(pokemonAttacker);
        pokemonBattleTwo.CreateBattle(pokemon, pokemon2);
        pokemonBattleDb.LoadBattle(pokemonBattleTwo);
        
        var path = AppDomain.CurrentDomain.BaseDirectory;
        var jsonContent = File.ReadAllText(Path.Combine(path, $"{pokemon.Id}vs{pokemon2.Id}.json"));
        var expectedBattle = JsonSerializer.Deserialize<PokemonBattleInfo>(jsonContent);
        pokemonBattle.PokemonBattleInfo.Should().BeEquivalentTo(expectedBattle);
    }
}