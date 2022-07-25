using Application.Interfaces;
using Domain;
using Infrastructure;

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

    public List<Pokemon> FindPokemonByType(string type)
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

    public List<Pokemon> FindAllPokemon()
    {
        var pokemonList = pokemonDb.ReadPokemon();
        return pokemonList;
    }

    public void DeletePokemonById(int id)
    {
        pokemonDb.DeletePokemon(id);
    }

    public void ModifyPokemonById(int id, string key, int change)
    {
        pokemonDb.UpdatePokemon(id, key, change);
    }
}