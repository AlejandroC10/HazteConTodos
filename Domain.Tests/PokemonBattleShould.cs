using System.Text.Json;
using FluentAssertions;
using Xunit;

namespace Domain.Tests;

public class PokemonBattleShould
{
    private List<Pokemon> pokemonList { get; set; }
    public PokemonBattleShould()
    {
        var path = AppDomain.CurrentDomain.BaseDirectory;
        var jsonContent = File.ReadAllText(Path.Combine(path, "pokedex.json"));
        pokemonList = JsonSerializer.Deserialize<List<Pokemon>>(jsonContent);
    }
    
    [Fact]
    public void CreateANewBattle()
    {
        var pokemon = pokemonList.Find(pokemon => pokemon.Id == 1);
        var pokemon2 = pokemonList.Find(pokemon => pokemon.Id == 2);
        var expectedList = new List<Pokemon>()
        {
            pokemon, pokemon2
        };

        var pokemonBattle = new PokemonBattle();
        pokemonBattle.CreateBattle(pokemon, pokemon2);

        pokemonBattle.SelectedPokemon.Should().BeEquivalentTo(expectedList);
    }
    
    [Fact]
    public void SaveBattleToJson()
    {
        var pokemon = pokemonList.Find(pokemon => pokemon.Id == 1);
        var pokemon2 = pokemonList.Find(pokemon => pokemon.Id == 2);
        
        var pokemonBattle = new PokemonBattle();
        pokemonBattle.CreateBattle(pokemon, pokemon2);
        pokemonBattle.SaveBattle();

        var path = AppDomain.CurrentDomain.BaseDirectory;
        var jsonContent = File.ReadAllText(Path.Combine(path, $"{pokemon.Id}vs{pokemon2.Id}.json"));
        var expectedBattle = JsonSerializer.Deserialize<PokemonBattle>(jsonContent);
        pokemonBattle.Should().BeEquivalentTo(expectedBattle);
    }
    
    [Fact]
    public void AttackWithPokemonOne()
    {
        var pokemon = pokemonList.Find(pokemon => pokemon.Id == 1);
        var pokemon2 = pokemonList.Find(pokemon => pokemon.Id == 2);
        
        var pokemonBattle = new PokemonBattle();
        pokemonBattle.CreateBattle(pokemon, pokemon2);
        pokemonBattle.Combat();
        pokemonBattle.SaveBattle();

        pokemonBattle.SelectedPokemon[1].Stats["HP"].Should().BeLessThan(pokemon2.Stats["HP"]);
    }
}