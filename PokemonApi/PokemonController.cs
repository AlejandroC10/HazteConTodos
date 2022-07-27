using Application;
using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace PokemonApi;

[ApiController]
[Route("[controller]")]
public class PokemonController : ControllerBase
{
    private IPokemonDb pokemonDataBase;

    public PokemonController(IPokemonDb pokemonDb)
    {
        pokemonDataBase = pokemonDb;
    }

    [HttpGet]
    public List<Pokemon> Get()
    {
        var pokedex = new Pokedex(pokemonDataBase);
        return pokedex.FindAllPokemon();
    }
    
    [HttpGet]
    [Route("{id}")]
    public Pokemon Get(int id)
    {
        var pokedex = new Pokedex(pokemonDataBase);
        return pokedex.FindPokemonById(id);
    }
    
    [HttpGet]
    [Route("Type/{type}")]
    public List<Pokemon> Get(string type)
    {
        var pokedex = new Pokedex(pokemonDataBase);
        return pokedex.FindPokemonByType(type);
    }
    
    [HttpDelete]
    [Route("{id}")]
    public IActionResult Delete(int id)
    {
        var pokedex = new Pokedex(pokemonDataBase);
        pokedex.DeletePokemonById(id);
        
        return Ok();
    }
    
    [HttpPut]
    [Route("{id}")]
    public IActionResult Put(int id, string key, int change)
    {
        var pokedex = new Pokedex(pokemonDataBase);
        pokedex.ModifyPokemonById(id, key, change);
        
        return Ok();
    }
}