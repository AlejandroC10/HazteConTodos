using System;
using System.Collections.Generic;
using Domain;
using FluentAssertions;
using Infrastructure;
using NSubstitute;
using Xunit;

namespace Application.Test;

public class PokedexShould
{
    [Fact]
    public void ReturnPokemonWithId1()
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
    public void ReturnPokemonWithId2()
    {
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
        
        var pokemonList = new List<Pokemon>
        {
            fakePokemon
        };
        
        var db = Substitute.For<IPokemonDb>();
        var pokedex = new Pokedex(db);

        db.ReadPokemon().Returns(pokemonList);
        
        //Act
        var pokemon = pokedex.FindPokemonById(2);
        
        //Assert
        pokemon.Should().BeSameAs(fakePokemon);
        db.Received(1).ReadPokemon();
    }
    
    [Fact]
    public void ReturnPokemonWithId3()
    {
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

        var pokemonList = new List<Pokemon>
        {
            fakePokemon
        };
        
        var db = Substitute.For<IPokemonDb>();
        var pokedex = new Pokedex(db);

        db.ReadPokemon().Returns(pokemonList);
        
        //Act
        var pokemon = pokedex.FindPokemonById(3);
        
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
    public void DeletePokemonWithId1()
    {
        // Arrange
        #region pokemones
        var pokemonOne = new Pokemon(1,
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
                {"Attack", 52},
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
        pokedex.DeletePokemonById(1);
        
        pokemonList.Remove(pokemonOne);
        db.ReadPokemon().Returns(pokemonList);
        
        var finalPokemonList = pokedex.FindAllPokemon();

        //Assert
        finalPokemonList.Should().NotContain(pokemonOne);
        db.Received(1).DeletePokemon(1);
        db.Received(1).ReadPokemon();
    }

    [Fact]
    public void ThrowErrorWhenPokemonDoesntExist()
    {
        // Arrange
        #region pokemones
        var pokemonOne = new Pokemon(1,
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
                {"Attack", 52},
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
        
        var pokemonDb = db.ReadPokemon();
        var id = 810;
        var key = "HP";
        var change = 20;
        
        // Act
        db.When(dataBase => dataBase.UpdatePokemon(id, key, change)).Do(dataBaseFunction =>
        {
            var database = pokemonDb;
            var pokemonToUpdate = database.Find(pokemon => pokemon.Id == id);
            if (pokemonToUpdate == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
        });
        Action act = () => pokedex.ModifyPokemonById(id, key, change);
        
        // Assert
        act.Should().Throw<ArgumentNullException>().WithParameterName(nameof(id));
    }
    
    [Theory]
    [InlineData("HP", 45)]
    [InlineData("Attack", 49)]
    [InlineData("Defense", 49)]
    [InlineData("Sp. Attack", 65)]
    [InlineData("Sp. Defense", 65)]
    [InlineData("Speed", 45)]
    public void UpdatePokemonStatsWhenExists(string keyToChange, int oldStatValue)
    {
        // Arrange
        #region pokemones
        var pokemonOne = new Pokemon(1,
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
                {"Attack", 52},
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
        
        var pokemonDb = db.ReadPokemon();
        var id = 1;
        var key = keyToChange;
        var change = 20;

        // Act
        db.When(dataBase => dataBase.UpdatePokemon(id, key, change)).Do(dataBaseFunction =>
        {
            var database = pokemonDb;
            var pokemonToUpdate = database.Find(pokemon => pokemon.Id == id);
            if (pokemonToUpdate == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            pokemonToUpdate.Stats[key] = change;
        });
        db.UpdatePokemon(id, key, change);
        var pokemon = pokedex.FindPokemonById(1);
        
        // Assert
        pokemon.Stats[key].Should().NotBe(oldStatValue);
    }
}