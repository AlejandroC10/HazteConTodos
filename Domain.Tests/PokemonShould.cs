using System.Text.Json;
using FluentAssertions;
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
        var pokemon2 = pokemonList.Find(pokemon => pokemon.Id == 2);
        
        var damage = pokemon.CalculateDamage(pokemon2.Type);

        damage.Should().BeLessOrEqualTo(pokemon.Stats["Attack"]);
    }
    
    [Fact]
    public void CalculateDamageNotEffective()
    {
        var pokemon = pokemonList.Find(pokemon => pokemon.Id == 1);
        var pokemon2 = pokemonList.Find(pokemon => pokemon.Id == 4);
        
        var damage = pokemon.CalculateDamage(pokemon2.Type);

        damage.Should().BeLessOrEqualTo(pokemon.Stats["Attack"] / 2);
    }
}