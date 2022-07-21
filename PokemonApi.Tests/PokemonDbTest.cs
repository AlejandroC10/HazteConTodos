using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json;
using Domain;
using Infrastructure;

namespace PokemonApiTests.Controllers;

public class PokemonDbTest : IPokemonDb
{
    public List<Pokemon> ReadPokemon()
    {
        var path = AppDomain.CurrentDomain.BaseDirectory;
        
        var jsonString = File.ReadAllText(Path.Combine(path,"pokedexFalsa.json"));

        var pokemonList = JsonSerializer.Deserialize<List<Pokemon>>(jsonString);
        
        if (pokemonList == null)
        {
            throw new ArgumentException("Json can't be empty");
        }
        return pokemonList;
    }

    public void DeletePokemon(int id)
    {
        var db = ReadPokemon();
        var pokemonToDelete = db.Find(pokemon => pokemon.Id == 1);
        if (pokemonToDelete == null)
        {
            throw new ArgumentNullException(nameof(id));
        }
        
        db.Remove(pokemonToDelete);
        
        
        var jsonContent = JsonSerializer.Serialize<List<Pokemon>>(db);
        
        var path = Assembly.GetExecutingAssembly().Location;
        File.WriteAllText(Path.Combine(path,"pokedexFalsa.json"), jsonContent);
    }
}