using System.Text.Json;
using Domain;
using System.IO;
using System.Reflection;
using System.Xml;

namespace Infrastructure;

public class PokemonDb: IPokemonDb
{
    public List<Pokemon> ReadPokemon()
    {
        var path = AppDomain.CurrentDomain.BaseDirectory;
        var jsonContent = File.ReadAllText(Path.Combine(path, "pokedex.json"));
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
        File.WriteAllText(Path.Combine(path, "pokedex.json"), jsonContent);
    }

    public void UpdatePokemon(int id, string key, int change)
    {
        var database = ReadPokemon();
        var pokemonToUpdate = database.Find(pokemon => pokemon.Id == id);
        if (pokemonToUpdate == null)
        {
            throw new ArgumentNullException(nameof(id));
        }
    }
}