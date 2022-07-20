using System.Text.Json;
using Domain;
using System.IO;
using System.Reflection;
using Json.Interfaces;

namespace Json;

public class PokemonDb: IPokemonDb
{
    public List<Pokemon> ReadPokemon()
    {
        var assembly = Assembly.GetExecutingAssembly();
        var fileName = assembly.GetManifestResourceStream("Json.pokedex.json");
        var sb = new StreamReader(fileName);
        var jsonString = sb.ReadToEnd();
        var pokemonList = JsonSerializer.Deserialize<List<Pokemon>>(jsonString);
        
        if (pokemonList == null)
        {
            throw new ArgumentException("Json can't be empty");
        }
        return pokemonList;
    }

    public void DeletePokemon(int id, List<Pokemon> db)
    {
        var pokemonToDelete = db.Find(pokemon => pokemon.Id == 1);
        if (pokemonToDelete == null)
        {
            throw new ArgumentNullException(nameof(id));
        }
        
        db.Remove(pokemonToDelete);
        
        var assembly = Assembly.GetExecutingAssembly();
        var fileName = assembly.GetManifestResourceStream("Json.pokedex.json");
        var sb = new StreamWriter(fileName);
        var jsonContent = JsonSerializer.Serialize<List<Pokemon>>(db);
        sb.Write(jsonContent);
    }
}