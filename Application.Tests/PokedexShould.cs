using System.Collections.Generic;
using Domain;
using FluentAssertions;
using Xunit;

namespace Application.Test;

public class PokedexShould
{
    [Fact]
    public void ReturnPokemonWithId1()
    {
        var pokedex = new Pokedex();
        var actualPokemon = pokedex.FindPokemonById(1);
        
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
        var fakePokemon = new Pokemon(1, fakeNames, fakeTypes, fakeStats);

        actualPokemon.Should().BeEquivalentTo(fakePokemon);
    }
    
    [Fact]
    public void ReturnPokemonWithId2()
    {
        var pokedex = new Pokedex();
        var actualPokemon = pokedex.FindPokemonById(2);
        
        var fakeNames = new Dictionary<string, string>
        {
            {"english", "Ivysaur"},
            {"japanese", "フシギソウ"},
            {"chinese", "妙蛙草"},
            {"french", "Herbizarre"}
        };
        var fakeStats = new Dictionary<string, int>
        {
            {"HP", 60},
            {"Attack", 62},
            {"Defense", 63},
            {"Sp. Attack", 80},
            {"Sp. Defense", 80},
            {"Speed", 60}
        };
        var fakeTypes = new List<string>
        {
            "Grass",
            "Poison"
        };
        var fakePokemon = new Pokemon(2, fakeNames, fakeTypes, fakeStats);

        actualPokemon.Should().BeEquivalentTo(fakePokemon);
    }
    
    [Fact]
    public void ReturnPokemonWithId3()
    {
        var pokedex = new Pokedex();
        var actualPokemon = pokedex.FindPokemonById(3);

        var fakeNames = new Dictionary<string, string>
        {
            {"english", "Venusaur"},
            {"japanese", "フシギバナ"},
            {"chinese", "妙蛙花"},
            {"french", "Florizarre"}
        };
        var fakeStats = new Dictionary<string, int>
        {
            {"HP", 80},
            {"Attack", 82},
            {"Defense", 83},
            {"Sp. Attack", 100},
            {"Sp. Defense", 100},
            {"Speed", 80}
        };
        var fakeTypes = new List<string>
        {
            "Grass",
            "Poison"
        };
        var fakePokemon = new Pokemon(3, fakeNames, fakeTypes, fakeStats);

        actualPokemon.Should().BeEquivalentTo(fakePokemon);
    }

    [Fact]
    public void ReturnPokemonListFromType()
    {
        var pokedex = new Pokedex();
        var actualPokemon = pokedex.FindByType("Grass");

        actualPokemon.Should().NotBeEmpty();
    }

    [Theory]
    [InlineData("Ghost", 43)]
    [InlineData("Grass", 97)]
    public void ReturnPokemonListFromSpecificType(string type, int total)
    {
        var pokedex = new Pokedex();
        var actualPokemon = pokedex.FindByType(type);

        actualPokemon.Count.Should().Be(total);
    }
    
    [Fact]
    public void ReturnAllPokemons()
    {
        var pokedex = new Pokedex();
        var actualPokemon = pokedex.GetAll();

        actualPokemon.Count.Should().Be(809);
    }
}