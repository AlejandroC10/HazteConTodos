using Application;
using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace PokemonApi.Controllers;

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
        return pokedex.GetAll();
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
        return pokedex.FindByType(type);
    }
    
    [HttpDelete]
    [Route("{id}")]
    public IActionResult Delete(int id)
    {
        var pokedex = new Pokedex(pokemonDataBase);
        pokedex.DeleteById(id);
        
        return Ok();
    }
    
}