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
        pokemonBattle.DeleteBattle();
    }
    
    [Fact]
    public void AttackWithPokemonOne()
    {
        var pokemon = pokemonList.Find(pokemon => pokemon.Id == 1);
        var pokemon2 = pokemonList.Find(pokemon => pokemon.Id == 2);
        var expectedHealth = pokemon2.Stats["HP"];
        
        var pokemonBattle = new PokemonBattle();
        pokemonBattle.CreateBattle(pokemon, pokemon2);
        pokemonBattle.Combat();

        pokemonBattle.SelectedPokemon[1].Stats["HP"].Should().BeLessThan(expectedHealth);
    }
    
    [Fact]
    public void AttackWithPokemonTwo()
    {
        var pokemon = pokemonList.Find(pokemon => pokemon.Id == 1);
        var pokemon2 = pokemonList.Find(pokemon => pokemon.Id == 2);
        var expectedHealth = pokemon.Stats["HP"];
        
        var pokemonBattle = new PokemonBattle();
        pokemonBattle.CreateBattle(pokemon, pokemon2);
        pokemonBattle.Combat();

        pokemonBattle.SelectedPokemon[0].Stats["HP"].Should().BeLessThan(expectedHealth);
    }
    
    [Fact]
    public void MakeACheck()
    {
        var pokemon = pokemonList.Find(pokemon => pokemon.Id == 1);
        var pokemon2 = pokemonList.Find(pokemon => pokemon.Id == 2);
        
        var pokemonBattle = new PokemonBattle();
        pokemonBattle.CreateBattle(pokemon, pokemon2);
        pokemonBattle.Combat();

        pokemonBattle.CombatStatus.Should().Be($"{pokemon.Name["english"]}: {pokemon.Stats["HP"]} HP | {pokemon2.Name["english"]}: {pokemon2.Stats["HP"]} HP");
    }
    
    [Fact]
    public void LetPokemonOneWinWhenPokemonTwoDies()
    {
        var pokemon = pokemonList.Find(pokemon => pokemon.Id == 1);
        var pokemon2 = pokemonList.Find(pokemon => pokemon.Id == 2);
        pokemon2.Stats["HP"] = 0;
        
        var pokemonBattle = new PokemonBattle();
        pokemonBattle.CreateBattle(pokemon, pokemon2);
        pokemonBattle.Combat();

        pokemonBattle.CombatStatus.Should().Be($"{pokemon.Name["english"]} is the WINNER");
        pokemonBattle.CombatWinner.Should().Be($"{pokemon.Name["english"]}");
    }
    
    [Fact]
    public void LetPokemonTwoWinWhenPokemonOneDies()
    {
        var pokemon = pokemonList.Find(pokemon => pokemon.Id == 1);
        var pokemon2 = pokemonList.Find(pokemon => pokemon.Id == 2);
        pokemon.Stats["HP"] = 0;
        
        var pokemonBattle = new PokemonBattle();
        pokemonBattle.CreateBattle(pokemon, pokemon2);
        pokemonBattle.Combat();

        pokemonBattle.CombatStatus.Should().Be($"{pokemon2.Name["english"]} is the WINNER");
        pokemonBattle.CombatWinner.Should().Be($"{pokemon2.Name["english"]}");
    }
    
    [Fact]
    public void DeleteJson()
    {
        var pokemon = pokemonList.Find(pokemon => pokemon.Id == 1);
        var pokemon2 = pokemonList.Find(pokemon => pokemon.Id == 2);

        var pokemonBattle = new PokemonBattle();
        pokemonBattle.CreateBattle(pokemon, pokemon2);
        pokemonBattle.Combat();
        pokemonBattle.DeleteBattle();
        
        var path = AppDomain.CurrentDomain.BaseDirectory;
        File.Exists(Path.Combine(path, $"{pokemon.Id}vs{pokemon2.Id}.json")).Should().BeFalse();
    }
    
    [Fact]
    public void LoadBattleFromJson()
    {
        var pokemon = pokemonList.Find(pokemon => pokemon.Id == 1);
        var pokemon2 = pokemonList.Find(pokemon => pokemon.Id == 2);
        
        var initialPokemonBattle = new PokemonBattle();
        initialPokemonBattle.CreateBattle(pokemon, pokemon2);
        initialPokemonBattle.Combat();
        initialPokemonBattle.SaveBattle(); 
        
        var pokemonBattle = new PokemonBattle();
        pokemonBattle.CreateBattle(pokemon, pokemon2);

        var path = AppDomain.CurrentDomain.BaseDirectory;
        var jsonContent = File.ReadAllText(Path.Combine(path, $"{pokemon.Id}vs{pokemon2.Id}.json"));
        var expectedBattle = JsonSerializer.Deserialize<PokemonBattle>(jsonContent);
        pokemonBattle.Should().BeEquivalentTo(expectedBattle);
    }
}