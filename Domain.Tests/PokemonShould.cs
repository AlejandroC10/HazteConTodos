using System.Text.Json;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Domain.Tests;

public class PokemonShould
{
    private List<Pokemon> pokemonList { get; set; }
    public PokemonShould()
    {
        var path = AppDomain.CurrentDomain.BaseDirectory;
        var jsonContent = File.ReadAllText(Path.Combine(path, "pokedex.json"));
        pokemonList = JsonSerializer.Deserialize<List<Pokemon>>(jsonContent);
    }
    
    [Fact]
    public void ReceiveDamage()
    {
        var pokemon = pokemonList.Find(pokemon => pokemon.Id == 1);

        pokemon.TakeDamage(5);

        pokemon.Stats["HP"].Should().Be(40);
    }
    
    [Fact]
    public void CalculateDamageNeutral()
    {
        var pokemon = pokemonList.Find(pokemon => pokemon.Id == 1);
        var pokemon2 = pokemonList.Find(pokemon => pokemon.Id == 25);
        var pokemonAttacker = Substitute.For<IPokemonAttacker>();
        pokemonAttacker.CalculateDamage(pokemon.Stats["Attack"]).Returns(12);
        
        var damage = pokemon.CalculateDamage(pokemon2.Type, pokemonAttacker.CalculateDamage(pokemon.Stats["Attack"]));

        damage.Should().Be(12);
    }
    
    [Fact]
    public void CalculateDamageNotEffective()
    {
        var pokemon = pokemonList.Find(pokemon => pokemon.Id == 1);
        var pokemon2 = pokemonList.Find(pokemon => pokemon.Id == 4);
        var pokemonAttacker = Substitute.For<IPokemonAttacker>();
        pokemonAttacker.CalculateDamage(pokemon.Stats["Attack"]).Returns(12);
        
        var damage = pokemon.CalculateDamage(pokemon2.Type, pokemonAttacker.CalculateDamage(pokemon.Stats["Attack"]));

        damage.Should().Be(6);
    }
    
    [Fact]
    public void CalculateDamageSuperEffective()
    {
        var pokemon = pokemonList.Find(pokemon => pokemon.Id == 1);
        var pokemon2 = pokemonList.Find(pokemon => pokemon.Id == 7);
        var pokemonAttacker = Substitute.For<IPokemonAttacker>();
        pokemonAttacker.CalculateDamage(pokemon.Stats["Attack"]).Returns(12);
        
        var damage = pokemon.CalculateDamage(pokemon2.Type, pokemonAttacker.CalculateDamage(pokemon.Stats["Attack"]));

        damage.Should().Be(24);
    }
    
    [Fact]
    public void CalculateDamageImmune()
    {
        var pokemon = pokemonList.Find(pokemon => pokemon.Id == 607);
        var pokemon2 = pokemonList.Find(pokemon => pokemon.Id == 263);
        var pokemonAttacker = Substitute.For<IPokemonAttacker>();
        pokemonAttacker.CalculateDamage(pokemon.Stats["Attack"]).Returns(12);
        
        var damage = pokemon.CalculateDamage(pokemon2.Type, pokemonAttacker.CalculateDamage(pokemon.Stats["Attack"]));

        damage.Should().Be(0);
    }
}