

using System.Text.Json;
using FluentAssertions;

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
}