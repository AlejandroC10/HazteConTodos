using Application.Interfaces;
using Domain;
using Json;
using Json.Interfaces;

namespace Application;

public class Pokedex : IPokedex
{
    private readonly IPokemonDb pokemonDb;

    public Pokedex(IPokemonDb pokemonDb)
    {
        this.pokemonDb = pokemonDb;
    }
    
    public Pokemon FindPokemonById(int id)
    {
        var pokemonList = pokemonDb.ReadPokemon();

        foreach (var pokemon in pokemonList)
        {
            if (pokemon.Id == id)
            {
                return pokemon;
            }   
        }

        throw new ArgumentOutOfRangeException(nameof(id));
    }

    public List<Pokemon> FindByType(string type)
    {
        var pokemonList = pokemonDb.ReadPokemon();

        var matchPokemon = new List<Pokemon>();
        
        foreach (var pokemon in pokemonList)
        {
            if (pokemon.Type.Contains(type))
            {
                matchPokemon.Add(pokemon);
            }   
        }
        
        return matchPokemon;
    }

    public List<Pokemon> GetAll()
    {
        var pokemonList = pokemonDb.ReadPokemon();
        return pokemonList;
    }

    public void DeleteById(int id)
    {
        
    }
}