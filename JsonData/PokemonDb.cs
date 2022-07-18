using System.Text.Json;
using Domain;

namespace Json;

public class PokemonDb
{
    public List<Pokemon> ReadPokemon()
    {
        var fileName = "../../../../JsonData/pokedex.json";
        var jsonString = File.ReadAllText(fileName);
        var pokemonList = JsonSerializer.Deserialize<List<Pokemon>>(jsonString);
        
        if (pokemonList == null)
        {
            throw new ArgumentException("Json can't be empty");
        }
        return pokemonList;
    }
}