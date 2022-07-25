using System;
using System.Collections.Generic;
using Domain;
using FluentAssertions;
using Infrastructure;
using NSubstitute;
using NSubstitute.ReceivedExtensions;
using Xunit;

namespace Application.Test;

public class PokedexShould
{
    [Fact]
    public void ReturnPokemonById()
    {
        // Arrange
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
        
        var pokemonList = new List<Pokemon>
        {
            fakePokemon
        };
        
        var db = Substitute.For<IPokemonDb>();
        var pokedex = new Pokedex(db);

        db.ReadPokemon().Returns(pokemonList);
        
        //Act
        var pokemon = pokedex.FindPokemonById(1);
        
        //Assert
        pokemon.Should().BeSameAs(fakePokemon);
        db.Received(1).ReadPokemon();
    }

    [Fact]
    public void ReturnPokemonListFromTypeGrass()
    {
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
        var pokemonTwo = new Pokemon(4,
            new Dictionary<string, string>
            {
                {"english", "Charmander"},
                {"japanese", "ヒトカゲ"},
                {"chinese", "小火龙"},
                {"french", "Salamèche"}
            },
            new List<string>
            {
                "Fire"
            },
            new Dictionary<string, int>
            {
                {"HP", 39},
                {"Attack", 52 },
                {"Defense", 43},
                {"Sp. Attack", 60},
                {"Sp. Defense", 50},
                {"Speed", 65}
            }
        );
        #endregion

        var pokemonList = new List<Pokemon>()
        {
            pokemonOne,
            pokemonTwo
        };

        var pokemonExpected = new List<Pokemon>()
        {
            pokemonOne
        };
        
        var db = Substitute.For<IPokemonDb>();
        var pokedex = new Pokedex(db);

        db.ReadPokemon().Returns(pokemonList);
        
        //Act
        var pokemon = pokedex.FindPokemonByType("Grass");
        
        //Assert
        pokemon.Should().BeEquivalentTo(pokemonExpected);
        db.Received(1).ReadPokemon();
    }

    [Fact]
    public void ReturnAllPokemon()
    {
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
        var pokemonTwo = new Pokemon(4,
            new Dictionary<string, string>
            {
                {"english", "Charmander"},
                {"japanese", "ヒトカゲ"},
                {"chinese", "小火龙"},
                {"french", "Salamèche"}
            },
            new List<string>
            {
                "Fire"
            },
            new Dictionary<string, int>
            {
                {"HP", 39},
                {"Attack", 52 },
                {"Defense", 43},
                {"Sp. Attack", 60},
                {"Sp. Defense", 50},
                {"Speed", 65}
            }
        );
        #endregion

        var pokemonList = new List<Pokemon>()
        {
            pokemonOne,
            pokemonTwo
        };

        var db = Substitute.For<IPokemonDb>();
        var pokedex = new Pokedex(db);

        db.ReadPokemon().Returns(pokemonList);
        
        //Act
        var pokemon = pokedex.FindAllPokemon();
        
        //Assert
        pokemon.Should().BeSameAs(pokemonList);
        db.Received(1).ReadPokemon();
    }
    
    [Fact]
    public void DeletePokemonById()
    {
        // Arrange
        var db = Substitute.For<IPokemonDb>();
        var pokedex = new Pokedex(db);

        var id = 1;

        // Act
        pokedex.DeletePokemonById(id);

        // Assert
        db.Received(1).DeletePokemon(id);
    }

    [Fact]
    public void UpdatePokemonStatsWhenExists()
    {
        // Arrange
        var db = Substitute.For<IPokemonDb>();
        var pokedex = new Pokedex(db);

        var id = 1;
        var key = "HP";
        var change = 20;

        // Act
        pokedex.ModifyPokemonById(id, key, change);

        // Assert
        db.Received(1).UpdatePokemon(id, key, change);
    }
}