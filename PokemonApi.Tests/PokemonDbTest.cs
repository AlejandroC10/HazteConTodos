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
        var jsonContent = File.ReadAllText(Path.Combine(path, "pokedex.test.json"));
        var pokemonList = JsonSerializer.Deserialize<List<Pokemon>>(jsonContent);
        
        if (pokemonList == null)
        {
            throw new ArgumentException("Json can't be empty");
        }
        return pokemonList;
    }

    public void DeletePokemon(int id)
    {
        var database = ReadPokemon();
        var pokemonToDelete = database.Find(pokemon => pokemon.Id == id);
        if (pokemonToDelete == null)
        {
            throw new ArgumentNullException(nameof(id));
        }
        
        database.Remove(pokemonToDelete);

        var jsonContent = JsonSerializer.Serialize<List<Pokemon>>(database);
        var path = AppDomain.CurrentDomain.BaseDirectory;
        File.WriteAllText(Path.Combine(path, "pokedex.test.json"), jsonContent);
    }

    public void UpdatePokemon(int id, string key, int change)
    {

    }

    public void CopyPokedexJson()
    {
        var path = AppDomain.CurrentDomain.BaseDirectory;
        File.Copy(Path.Combine(path, "pokedex.json"), Path.Combine(path, "pokedex.test.json"), true);
    }
}