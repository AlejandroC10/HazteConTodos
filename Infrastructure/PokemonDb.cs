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
        var jsonString = File.ReadAllText("pokedex.json");

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
        File.WriteAllText("pokedex.json", jsonContent);

    }
}