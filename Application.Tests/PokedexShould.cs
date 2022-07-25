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
        
    [Fact]
    public void ReturnPokemonById()
    {
        // Arrange
        var fakePokemon = pokemonList.Find(pokemon => pokemon.Id == 1);

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
        var fakePokemon = pokemonList.FindAll(pokemon => pokemon.Type.Contains("Grass"));
        
        var db = Substitute.For<IPokemonDb>();
        var pokedex = new Pokedex(db);

        db.ReadPokemon().Returns(pokemonList);
        
        //Act
        var pokemon = pokedex.FindPokemonByType("Grass");
        
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