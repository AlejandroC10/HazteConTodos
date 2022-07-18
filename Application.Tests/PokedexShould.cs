using System.Collections.Generic;
using Application.Interfaces;
using Domain;
using FluentAssertions;
using Json.Interfaces;
using NSubstitute;
using Xunit;

namespace Application.Test;

public class PokedexShould
{
    [Fact]
    public void ReturnPokemonWithId1()
    {
        var pokedex = Substitute.For<IPokedex>();

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
        
        pokedex.FindPokemonById(1).Returns(fakePokemon);
    }
    
    [Fact]
    public void ReturnPokemonWithId2()
    {
        var pokedex = Substitute.For<IPokedex>();

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

        pokedex.FindPokemonById(2).Returns(fakePokemon);
    }
    
    [Fact]
    public void ReturnPokemonWithId3()
    {
        var pokedex = Substitute.For<IPokedex>();

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

        pokedex.FindPokemonById(3).Returns(fakePokemon);
    }

    [Fact]
    public void ReturnPokemonListFromType()
    {
        var pokedex = Substitute.For<IPokedex>();
        
        #region pokemones
        var pokemonOne = new Pokemon(1,
            new Dictionary<string, string>
            {
                {"english", "Ivysaur"},
                {"japanese", "フシギソウ"},
                {"chinese", "妙蛙草"},
                {"french", "Herbizarre"}
            },
            new List<string>
            {
                "Grass",
                "Poison"
            },
            new Dictionary<string, int>
            {
                {"HP", 60},
                {"Attack", 62},
                {"Defense", 63},
                {"Sp. Attack", 80},
                {"Sp. Defense", 80},
                {"Speed", 60}
            }
        );
        
        var pokemonTwo = new Pokemon(2,
            new Dictionary<string, string>
            {
                {"english", "Bulbasaur"},
                {"japanese", "フシギダネ"},
                {"chinese", "妙蛙种子"},
                {"french", "Bulbizarre"}
            },
            new List<string>
            {
                "Grass",
                "Poison"
            },
            new Dictionary<string, int>
            {
                {"HP", 45},
                {"Attack", 49},
                {"Defense", 49},
                {"Sp. Attack", 65},
                {"Sp. Defense", 65},
                {"Speed", 45}
            }
        );
        #endregion

        var pokemonList = new List<Pokemon>()
        {
            pokemonOne,
            pokemonTwo
        };
        
        pokedex.FindByType("Grass").Returns(pokemonList);
    }

    [Fact]
    public void ReturnAllPokemon()
    {
        var pokedex = Substitute.For<IPokedex>();
        
        #region pokemones
        var pokemonOne = new Pokemon(1,
            new Dictionary<string, string>
            {
                {"english", "Ivysaur"},
                {"japanese", "フシギソウ"},
                {"chinese", "妙蛙草"},
                {"french", "Herbizarre"}
            },
            new List<string>
            {
                "Grass",
                "Poison"
            },
            new Dictionary<string, int>
            {
                {"HP", 60},
                {"Attack", 62},
                {"Defense", 63},
                {"Sp. Attack", 80},
                {"Sp. Defense", 80},
                {"Speed", 60}
            }
        );
        
        var pokemonTwo = new Pokemon(2,
            new Dictionary<string, string>
            {
                {"english", "Bulbasaur"},
                {"japanese", "フシギダネ"},
                {"chinese", "妙蛙种子"},
                {"french", "Bulbizarre"}
            },
            new List<string>
            {
                "Grass",
                "Poison"
            },
            new Dictionary<string, int>
            {
                {"HP", 45},
                {"Attack", 49},
                {"Defense", 49},
                {"Sp. Attack", 65},
                {"Sp. Defense", 65},
                {"Speed", 45}
            }
        );
        #endregion

        var pokemonList = new List<Pokemon>()
        {
            pokemonOne,
            pokemonTwo
        };
        
        pokedex.GetAll().Returns(pokemonList);
    }
}