using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Domain;
using FluentAssertions;
using Infrastructure;
using NSubstitute;
using NSubstitute.ReceivedExtensions;
using Xunit;

namespace Application.Test;

public class PokedexShould
{
    private List<Pokemon> pokemonList { get; set; }

    public PokedexShould()
    {
        var path = AppDomain.CurrentDomain.BaseDirectory;
        var jsonContent = File.ReadAllText(Path.Combine(path, "testPokedex.json"));
        pokemonList = JsonSerializer.Deserialize<List<Pokemon>>(jsonContent);
    }
        
    [Theory]
    [InlineData(1)]
    [InlineData(4)]
    [InlineData(6)]
    public void ReturnPokemonById(int id)
    {
        // Arrange
        var fakePokemon = pokemonList.Find(pokemon => pokemon.Id == id);

        var db = Substitute.For<IPokemonDb>();
        var pokedex = new Pokedex(db);

        db.ReadPokemon().Returns(pokemonList);
        
        //Act
        var pokemon = pokedex.FindPokemonById(id);
        
        //Assert
        pokemon.Should().BeSameAs(fakePokemon);
        db.Received(1).ReadPokemon();
    }

    [Theory]
    [InlineData("Grass")]
    [InlineData("Ghost")]
    [InlineData("Bug")]
    public void ReturnPokemonListFromType(string type)
    {
        var fakePokemon = pokemonList.FindAll(pokemon => pokemon.Type.Contains(type));
        
        var db = Substitute.For<IPokemonDb>();
        var pokedex = new Pokedex(db);

        db.ReadPokemon().Returns(pokemonList);
        
        //Act
        var pokemon = pokedex.FindPokemonByType(type);
        
        //Assert
        pokemon.Should().BeEquivalentTo(fakePokemon);
        db.Received(1).ReadPokemon();
    }

    [Fact]
    public void ReturnAllPokemon()
    {
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